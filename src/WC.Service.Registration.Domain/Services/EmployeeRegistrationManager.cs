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

public class EmployeeRegistrationManager
    : ValidatorBase<ModelBase>,
        IEmployeeRegistrationManager
{
    private readonly IGreeterAuthenticationClient _authenticationClient;
    private readonly IGreeterEmployeesClient _employeesClient;

    public EmployeeRegistrationManager(
        IEnumerable<IValidator> validators,
        IGreeterEmployeesClient employeesClient,
        IGreeterAuthenticationClient authenticationClient)
        : base(validators)
    {
        _employeesClient = employeesClient;
        _authenticationClient = authenticationClient;
    }

    public async Task<LoginResponseModel> Register(
        EmployeeRegistrationModel employeeRegistration,
        CancellationToken cancellationToken = default)
    {
        Validate<EmployeeRegistrationModel, IDomainCreateValidator>(employeeRegistration, cancellationToken);

        try
        {
            await _employeesClient.Create(new EmployeeCreateRequestModel
            {
                Name = employeeRegistration.Name,
                Surname = employeeRegistration.Surname,
                Patronymic = employeeRegistration.Patronymic ?? string.Empty,
                PositionName = employeeRegistration.Position,
                Email = employeeRegistration.Email,
                Password = employeeRegistration.Password
            }, cancellationToken);

            var loginResponse = await _authenticationClient.GetLoginResponse(
                new LoginRequestModel
                {
                    Email = employeeRegistration.Email,
                    Password = employeeRegistration.Password
                }, cancellationToken);

            return loginResponse;
        }
        catch (Exception)
        {
            throw new RegistrationFailedException("An error occurred during the employee registration process.");
        }
    }
}
