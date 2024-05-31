using WC.Library.Web.Models;

namespace WC.Service.Registration.API.Models;

/// <summary>
/// The person responsible for some object processing or the one who is currently executing some task.
/// </summary>
public class EmployeeRegistrationDto : DtoBase
{
    /// <summary>
    /// The email address of the employee.
    /// </summary>
    public string Email { get; init; } = string.Empty;

    /// <summary>
    /// The password of the employee.
    /// </summary>
    public string Password { get; init; } = string.Empty;

    /// <summary>
    /// The role of the employee.
    /// </summary>
    public string Role { get; init; } = string.Empty;

    /// <summary>
    /// The date and time when the employee registration were created.
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// The last update date and time of the employee credentials.
    /// </summary>
    public DateTime? UpdatedAt { get; init; }
}