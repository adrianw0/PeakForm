using Domain.Models;

namespace Application.UseCases.MealHistory.AddMeal.Request;
public class AddMealRequest : UseCases.Request
{
    public List<MealFoodItems> FoodItems { get; set; } = new();
    public DateTime Date { get; set; }
}
