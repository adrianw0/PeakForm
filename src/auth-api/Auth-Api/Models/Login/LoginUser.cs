using System.ComponentModel.DataAnnotations;

namespace Auth_Api.Models.Login;

public class LoginUser
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
}
