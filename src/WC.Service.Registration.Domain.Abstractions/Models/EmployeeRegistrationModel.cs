using WC.Library.Domain.Models;

namespace WC.Service.Registration.Domain.Models;

public class EmployeeRegistrationModel : ModelBase
{
    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string Role { get; init; } = "User";
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}