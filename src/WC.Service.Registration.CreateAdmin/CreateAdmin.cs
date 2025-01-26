using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WC.Service.Registration.Domain.Services;

namespace WC.Service.Registration.CreateAdmin;

public class CreateAdmin
{
    private readonly IRegistrationManager _registrationManager;
    private readonly ILogger<CreateAdmin> _logger;
    private readonly IConfiguration _configuration;

    public CreateAdmin(
        ILogger<CreateAdmin> logger,
        IRegistrationManager registrationManager,
        IConfiguration configuration)
    {
        _registrationManager = registrationManager;
        _configuration = configuration;
        _logger = logger;
    }

    public async Task Create(
        CancellationToken cancellationToken = default)
    {
        var emailLocalPart = Environment.GetEnvironmentVariable("ADMIN_EMAIL_LOCAL_PART") ?? "admin";
        var emailDomain = Environment.GetEnvironmentVariable("ADMIN_EMAIL_DOMAIN") ?? "admin.com";

        var registrationPayload = new RegistrationCreatePayloadModel
        {
            Name = Environment.GetEnvironmentVariable("ADMIN_REGISTRATION_NAME") ?? "Админ",
            Surname = Environment.GetEnvironmentVariable("ADMIN_REGISTRATION_SURNAME") ?? "Админ",
            Patronymic = Environment.GetEnvironmentVariable("ADMIN_REGISTRATION_PATRONYMIC") ?? null,
            Email = $"{emailLocalPart}@{emailDomain}",
            Password = Environment.GetEnvironmentVariable("ADMIN_REGISTRATION_PASSWORD") ?? "Admin@12345678",
            PositionId = Guid.TryParse(Environment.GetEnvironmentVariable("ADMIN_POSITION_ID"), out var positionId)
                ? positionId
                : Guid.Parse("00000000-0000-0000-0000-000000000001")
        };

        var withAuthentication = _configuration.GetValue<bool>("WithAuthentication");

        try
        {
            var response =
                await _registrationManager.Register(registrationPayload, withAuthentication, cancellationToken);

            _logger.LogInformation("Registration successful");

            _logger.LogInformation(withAuthentication ? "Authentication successful" : "Authentication failed");
            if (withAuthentication)
            {
                _logger.LogInformation(
                    $"AccessToken: {response.AccessToken}\nRefreshToken: {response.RefreshToken}\nExpiresIn: {response.ExpiresIn}");
            }
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}
