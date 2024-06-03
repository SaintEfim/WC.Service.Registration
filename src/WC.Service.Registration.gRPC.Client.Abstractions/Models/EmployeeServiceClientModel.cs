namespace WC.Service.Registration.gRPC.Models;

public class EmployeeServiceClientModel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}