using System.ComponentModel.DataAnnotations;

namespace Auth.Application.Requests.Signup;

public class RegisterUser
{
    [Required]
    public required string UserName { get; set; } 
    [Required]
    [EmailAddress]
    public required string Email { get; set; } 
    [Required]
    public required string Password { get; set; }

}
