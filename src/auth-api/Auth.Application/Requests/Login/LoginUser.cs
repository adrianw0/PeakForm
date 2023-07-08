using System.ComponentModel.DataAnnotations;

namespace Auth.Application.Requests.Login;

public class LoginUser
{
    [Required]
    [EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
}