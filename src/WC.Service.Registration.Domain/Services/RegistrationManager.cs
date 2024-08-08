using FluentValidation;
using WC.Library.Domain.Models;
using WC.Library.Domain.Services.Validators;
using WC.Library.Domain.Validators;
using WC.Library.Employee.Shared.Exceptions;
using WC.Service.Authentication.gRPC.Client.Clients;
using WC.Service.Authentication.gRPC.Client.Models;
using WC.Service.Employees.gRPC.Client.Clients;
using WC.Service.Employees.gRPC.Client.Models.Employee;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public class RegistrationManager
    : ValidatorBase<ModelBase>,
        IRegistrationManager
{
    private readonly IGreeterAuthenticationClient _authenticationClient;
    private readonly IGreeterEmployeesClient _employeesClient;

    public RegistrationManager(
        IEnumerable<IValidator> validators,
        IGreeterEmployeesClient employeesClient,
        IGreeterAuthenticationClient authenticationClient)
        : base(validators)
    {
        _employeesClient = employeesClient;
        _authenticationClient = authenticationClient;
    }

    public async Task<AuthenticationLoginResponseModel> Register(
        RegistrationModel registration,
        CancellationToken cancellationToken = default)
    {
        Validate<RegistrationModel, IDomainCreateValidator>(registration, cancellationToken);

        try
        {
            await _employeesClient.Create(new EmployeeCreateRequestModel
            {
                Name = registration.Name,
                Surname = registration.Surname,
                Patronymic = registration.Patronymic ?? string.Empty,
                PositionName = registration.Position,
                Email = registration.Email,
                Password = registration.Password
            }, cancellationToken);

            var loginResponse = await _authenticationClient.GetLoginResponse(
                new AuthenticationLoginRequestModel
                {
                    Email = registration.Email,
                    Password = registration.Password
                }, cancellationToken);

            return loginResponse;
        }
        catch (Exception)
        {
            throw new RegistrationFailedException("An error occurred during the employee registration process.");
        }
    }
}
