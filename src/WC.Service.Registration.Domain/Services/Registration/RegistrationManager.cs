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

namespace WC.Service.Registration.Domain.Services.Registration;

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

    public async Task<AuthenticationLoginResponseModel?> Register(
        RegistrationModel registration,
        CancellationToken cancellationToken = default)
    {
        Validate<RegistrationModel, IDomainCreateValidator>(registration, cancellationToken);

        await ExecuteWithErrorHandlingAsync(
            async () => await _employeesClient.Create(new EmployeeCreateRequestModel
            {
                Name = registration.Name,
                Surname = registration.Surname,
                Patronymic = registration.Patronymic ?? string.Empty,
                PositionId = registration.PositionId,
                Email = registration.Email,
                Password = registration.Password
            }, cancellationToken), ex => throw new RegistrationFailedException($"Registration error: {ex.Message}"));

        return await ExecuteWithErrorHandlingAsync(
            async () => await _authenticationClient.GetLoginResponse(
                new AuthenticationLoginRequestModel
                {
                    Email = registration.Email,
                    Password = registration.Password
                }, cancellationToken),
            ex => throw new AuthenticationFailedException($"Authentication failed: {ex.Message}"));

        async Task<T?> ExecuteWithErrorHandlingAsync<T>(
            Func<Task<T>> func,
            Func<Exception, T?> errorHandler)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                return errorHandler(ex);
            }
        }
    }
}
