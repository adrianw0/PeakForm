using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Dish : IEntity, IFoodItem, IVisibilityControl
{
    public Guid Id { get; init; }
    [Required]
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = new();
    public string OwnerId { get; set; } = string.Empty;
    public bool IsGloballyVisible { get; set; } = false;
}
