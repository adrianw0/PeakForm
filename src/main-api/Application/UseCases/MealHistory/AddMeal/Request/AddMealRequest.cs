using Domain.Models;

namespace Application.UseCases.MealHistory.AddMeal.Request;
public class AddMealRequest : UseCases.Request
{
    public List<MealFoodItems> FoodItems { get; set; } = [];
    public DateTime Date { get; set; }
}
