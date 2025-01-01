using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Ingredient
{
    [Required]
    public required Product Product { get; set; }
    [Required]
    public required decimal Weight { get; set; }
    [Required]
    public required Unit Unit { get; set; }
}
