using System.ComponentModel.DataAnnotations;

namespace Auth_Api.Models.Singup;

public class RegisterUser
{
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    [EmailAddress]
    public string EmailAddress { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;

}
