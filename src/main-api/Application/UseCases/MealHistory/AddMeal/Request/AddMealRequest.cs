using Domain.Models;

namespace Application.UseCases.MealHistory.AddMeal.Request;
public class AddMealRequest : UseCases.Request
{
    public List<MealFoodItem> FoodItems { get; set; } = [];
    public DateTime Date { get; set; }
}
