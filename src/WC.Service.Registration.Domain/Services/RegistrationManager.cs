using FluentValidation;
using WC.Library.Domain.Models;
using WC.Library.Domain.Services.Validators;
using WC.Library.Domain.Validators;
using WC.Library.Employee.Shared.Exceptions;
using WC.Service.Authentication.gRPC.Client.Clients;
using WC.Service.Authentication.gRPC.Client.Models;
using WC.Service.Employees.gRPC.Client.Clients;
using WC.Service.Employees.gRPC.Client.Models.Employee;

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
        RegistrationCreatePayloadModel registrationCreatePayload,
        CancellationToken cancellationToken = default)
    {
        Validate<RegistrationCreatePayloadModel, IDomainCreateValidator>(registrationCreatePayload, cancellationToken);

        try
        {
            await _employeesClient.Create(new EmployeeCreateRequestModel
            {
                Name = registrationCreatePayload.Name,
                Surname = registrationCreatePayload.Surname,
                Patronymic = registrationCreatePayload.Patronymic ?? string.Empty,
                PositionId = registrationCreatePayload.PositionId,
                Email = registrationCreatePayload.Email,
                Password = registrationCreatePayload.Password
            }, cancellationToken);

            var loginResponse = await _authenticationClient.GetLoginResponse(
                new AuthenticationLoginRequestModel
                {
                    Email = registrationCreatePayload.Email,
                    Password = registrationCreatePayload.Password
                }, cancellationToken);

            return loginResponse;
        }
        catch (Exception)
        {
            throw new RegistrationFailedException(
                "An error occurred during the employee registrationCreatePayload process.");
        }
    }
}
