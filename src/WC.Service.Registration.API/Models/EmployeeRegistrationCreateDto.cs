using System.ComponentModel.DataAnnotations;

namespace WC.Service.Registration.API.Models;

/// <summary>
/// The person responsible for some object processing or the one who is currently executing some task.
/// </summary>
public class EmployeeRegistrationCreateDto
{
    /// <summary>
    /// The first name of the employee.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The surname of the employee.
    /// </summary>
    [Required]
    public string Surname { get; set; } = string.Empty;

    /// <summary>
    /// The patronymic of the employee (optional).
    /// </summary>
    public string? Patronymic { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the employee.
    /// </summary>
    [Required]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The password of the employee.
    /// </summary>
    [Required]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// The position of the employee within the organization.
    /// </summary>
    [Required]
    public string Position { get; set; } = string.Empty;
}