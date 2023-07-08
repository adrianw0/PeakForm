using System.ComponentModel.DataAnnotations;

namespace Auth.Infrastructure.Models.DTOs;

public class AuthUserDto
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
    [Required]
    public required string UserId { get; set; }
}