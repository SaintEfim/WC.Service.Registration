using System.ComponentModel.DataAnnotations;

namespace WC.Service.Registration.API.Models;

/// <summary>
///     The person responsible for some object processing or the one who is currently executing some task.
/// </summary>
public class RegistrationCreateDto
{
    /// <summary>
    ///     The first name of the employee.
    /// </summary>
    [Required]
    public required string Name { get; set; }

    /// <summary>
    ///     The surname of the employee.
    /// </summary>
    [Required]
    public required string Surname { get; set; }

    /// <summary>
    ///     The patronymic of the employee (optional).
    /// </summary>
    public string? Patronymic { get; set; }

    /// <summary>
    ///     The email address of the employee.
    /// </summary>
    [Required]
    public required string Email { get; set; }

    /// <summary>
    ///     The password of the employee.
    /// </summary>
    [Required]
    public required string Password { get; set; }

    /// <summary>
    ///     The position of the employee within the organization.
    /// </summary>
    [Required]
    public required Guid PositionId { get; set; }
}
