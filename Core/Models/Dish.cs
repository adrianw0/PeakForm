
using Core.Interfaces;

namespace Core.Models;
public class Dish : IEntity, IFoodItem, IVisibilityControl
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public User? Owner { get; set; }
    public bool IsGloballyVisible { get; set; }
}
