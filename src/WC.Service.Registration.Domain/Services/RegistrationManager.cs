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

        await ExecuteWithErrorHandlingAsync(
            async () => await _employeesClient.Create(
                new EmployeeCreateRequestModel
                {
                    Name = registrationCreatePayload.Name,
                    Surname = registrationCreatePayload.Surname,
                    Patronymic = registrationCreatePayload.Patronymic ?? string.Empty,
                    PositionId = registrationCreatePayload.PositionId,
                    Email = registrationCreatePayload.Email,
                    Password = registrationCreatePayload.Password
                }, cancellationToken),
            ex => throw new RegistrationFailedException($"Registration error: {ex.Message}"));

        return (await ExecuteWithErrorHandlingAsync(
            async () => await _authenticationClient.GetLoginResponse(
                new AuthenticationLoginRequestModel
                {
                    Email = registrationCreatePayload.Email,
                    Password = registrationCreatePayload.Password
                }, cancellationToken), ex =>
            {
                Console.WriteLine($"Authentication error: {ex.Message}");
                return new AuthenticationLoginResponseModel
                {
                    TokenType = null!,
                    AccessToken = null!,
                    ExpiresIn = 0,
                    RefreshToken = null!
                };
            }))!;

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
