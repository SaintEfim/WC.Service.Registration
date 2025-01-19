using WC.Library.Domain.Models;

namespace WC.Service.Registration.Domain.Services;

public class RegistrationCreatePayloadModel : ModelBase
{
    public required string Name { get; set; }

    public required string Surname { get; set; }

    public string? Patronymic { get; set; }

    public required string Email { get; set; }

    public required string Password { get; set; }

    public required Guid PositionId { get; set; }
}
