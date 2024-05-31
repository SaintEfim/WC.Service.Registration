namespace WC.Service.Registration.gRPC.Models;

public class EmployeeRegistrationRequestModel
{
    public Guid Id { get; set; }
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string Role { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}