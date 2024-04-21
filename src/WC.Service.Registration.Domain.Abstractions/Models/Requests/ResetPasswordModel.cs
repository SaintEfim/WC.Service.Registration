namespace WC.Service.Registration.Domain.Models.Requests;

public class ResetPasswordModel
{
    public string Email { get; init; } = string.Empty;

    public string Password { get; init; } = string.Empty;

    public string NewPassword { get; init; } = string.Empty;
}