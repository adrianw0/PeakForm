using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.MealHistory.UpdateMeal.Request;
public class UpdateMealRequest : UseCases.Request
{
    [Required]
    public required Guid Id { get; set; }
    public List<MealFoodItems> FoodItems { get; set; } = [];
}
