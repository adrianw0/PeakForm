using Domain.Models;

namespace Application.UseCases.MealHistory.AddMeal.Response;
public class AddMealSuccessReposnse : AddMealReposnse
{
    public Meal Meal { get; set; } = null!;
}
