namespace WC.Service.Registration.Domain.Models;

public class RegistrationRequestModel
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}