using Domain.Models;

namespace Application.UseCases.MealHistory.UpdateMeal.Response;
public class UpdateMealSuccessReposnse : UpdateMealReposnse
{
    public Meal Meal { get; set; }
}
