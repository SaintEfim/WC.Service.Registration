using WC.Library.Domain.Models;

namespace WC.Service.Registration.Domain.Models;

public class UserRegistrationModel : ModelBase
{
    public UserRegistrationModel()
    {
        Role = "user";
    }

    public string Email { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
    public string Role { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
}