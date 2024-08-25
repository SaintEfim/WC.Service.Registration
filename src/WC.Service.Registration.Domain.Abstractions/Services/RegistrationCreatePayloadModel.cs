using WC.Library.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public class RegistrationCreatePayloadModel : ModelBase
{
    public string Name { get; set; } = string.Empty;

    public string Surname { get; set; } = string.Empty;

    public string? Patronymic { get; set; }

    public string Email { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public Guid PositionId { get; set; }
}
