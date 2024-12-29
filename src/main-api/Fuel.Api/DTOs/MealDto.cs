using Domain.Models;

namespace Fuel.Api.DTOs;

public class MealDto
{
    public Guid Id { get; set; }
    public List<MealFoodItems> FoodItems { get; set; } = [];
    public DateTime Date { get; set; }
}
