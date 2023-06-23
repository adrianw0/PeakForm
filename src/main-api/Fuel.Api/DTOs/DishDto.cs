using Core.Models;

namespace Fuel.Api.DTOs;

public class DishDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
