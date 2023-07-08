using System.ComponentModel.DataAnnotations;

namespace Auth.Domain.Models;

public class User
{
    public string Id { get; set; } = string.Empty;
    [Required]
    public required string UserName { get; set; }
    [Required]
    [EmailAddress]
    public required string Email { get; set; }
}