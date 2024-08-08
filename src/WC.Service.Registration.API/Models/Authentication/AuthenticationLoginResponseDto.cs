using System.ComponentModel.DataAnnotations;

namespace WC.Service.Registration.API.Models.Authentication;

public class AuthenticationLoginResponseDto
{
    [Required]
    public required string TokenType { get; init; }

    [Required]
    public required string AccessToken { get; init; }

    [Required]
    public int ExpiresIn { get; init; }

    [Required]
    public required string RefreshToken { get; init; }
}
