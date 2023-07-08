using System.ComponentModel.DataAnnotations;
using Domain.Models;

namespace Application.UseCases.MealHistory.UpdateMeal.Response;
public class UpdateMealSuccessResponse : UpdateMealResponse
{
    [Required]
    public required Meal Meal { get; set; }
}
