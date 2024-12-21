using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class NutrientValue
{
    [Required]
    public required Nutrient Nutrient { get; set; }
    [Required]
    public required double Value { get; set; }
}
