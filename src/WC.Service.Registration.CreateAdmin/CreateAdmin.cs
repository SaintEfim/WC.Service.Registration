using Microsoft.Extensions.Logging;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.Domain.Services;

namespace WC.Service.Registration.CreateAdmin;

public class CreateAdmin
{
    private readonly IRegistrationManager _registrationManager;
    private readonly ILogger<CreateAdmin> _logger;
    private readonly AdminSettingsOptions _options;

    public CreateAdmin(
        ILogger<CreateAdmin> logger,
        IRegistrationManager registrationManager,
        AdminSettingsOptions options)
    {
        _registrationManager = registrationManager;
        _logger = logger;
        _options = options;
    }

    public async Task Create(
        CancellationToken cancellationToken = default)
    {
        var emailLocalPart = _options.AdminEmailLocalPart ?? "admin";
        var emailDomain = _options.AdminEmailDomain ?? "admin.com";

        var registrationPayload = new RegistrationModel
        {
            Name = _options.AdminRegistrationName ?? "Админ",
            Surname = _options.AdminRegistrationSurname ?? "Админ",
            Patronymic = _options.AdminRegistrationPatronymic,
            Email = $"{emailLocalPart}@{emailDomain}",
            Password = _options.AdminRegistrationPassword ?? "Admin@12345678",
            PositionId = _options.AdminPositionId
        };

        try
        {
            var response = await _registrationManager.Register(registrationPayload, cancellationToken);

            _logger.LogInformation("Registration successful");

            _logger.LogInformation(
                $"AccessToken: {response?.AccessToken}\nRefreshToken: {response?.RefreshToken}\nExpiresIn: {response!.ExpiresIn}");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
            throw;
        }
    }
}
