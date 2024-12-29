using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Dishes.AddDish.Request;
public class AddDishRequest : UseCases.Request
{
    [Required]
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = [];
}
