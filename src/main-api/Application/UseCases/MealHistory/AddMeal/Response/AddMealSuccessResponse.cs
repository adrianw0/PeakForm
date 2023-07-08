using Domain.Models;

namespace Application.UseCases.MealHistory.AddMeal.Response;
public class AddMealSuccessResponse : AddMealResponse
{
    public required Meal Meal { get; set; }
}
