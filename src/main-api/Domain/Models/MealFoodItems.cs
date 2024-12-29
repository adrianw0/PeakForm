using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class MealFoodItems
{
    [Required]
    public required IFoodItem FoodItem { get; set; }
    [Required]
    public required double Weight { get; set; }
    [Required]
    public required Unit WeightUnit { get; set; }

}
