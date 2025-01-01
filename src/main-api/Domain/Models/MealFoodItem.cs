using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class MealFoodItem
{
    [Required]
    public required IFoodItem FoodItem { get; set; }
    [Required]
    public required decimal Weight { get; set; }
    [Required]
    public required Unit WeightUnit { get; set; }

}
