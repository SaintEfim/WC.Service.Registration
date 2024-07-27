using WC.Library.Domain.Models;

namespace WC.Service.Registration.Domain.Models;

public class EmployeeRegistrationModel : ModelBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string Position { get; set; } = string.Empty;
}
