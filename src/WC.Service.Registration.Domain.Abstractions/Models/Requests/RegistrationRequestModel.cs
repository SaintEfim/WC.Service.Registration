namespace WC.Service.Registration.Domain.Models.Requests;

public class RegistrationRequestModel
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string? Role { get; init; }
}