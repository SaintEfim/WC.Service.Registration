namespace WC.Service.Registration.API.Models;

/// <summary>
/// The person responsible for some object processing or the one who is currently executing some task.
/// </summary>
public class EmployeeRegistrationDto
{
    /// <summary>
    /// The first name of the employee.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The surname of the employee.
    /// </summary>
    public string Surname { get; set; } = string.Empty;

    /// <summary>
    /// The patronymic of the employee (optional).
    /// </summary>
    public string? Patronymic { get; set; } = string.Empty;

    /// <summary>
    /// The email address of the employee.
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The password of the employee.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// The position of the employee within the organization.
    /// </summary>
    public string Position { get; set; } = string.Empty;
}