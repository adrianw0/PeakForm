using System.ComponentModel.DataAnnotations;

namespace Auth.Application.Requests.Login;

public class LoginUser
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}