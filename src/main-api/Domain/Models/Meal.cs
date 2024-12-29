namespace Domain.Models;
public class Meal : IEntity
{
    public Guid Id { get; init; }
    public List<MealFoodItems> FoodItems { get; set; } = [];
    public DateTime Date { get; set; } = DateTime.Now;
    public string OwnerId { get; set; } = string.Empty;
}
