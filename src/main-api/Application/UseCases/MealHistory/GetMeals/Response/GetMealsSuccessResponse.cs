using Domain.Models;

namespace Application.UseCases.MealHistory.GetMeals.Response;
public class GetMealsSuccessResponse : GetMealsResponse
{
    public List<Meal> Meals { get; set; } = new();
}
