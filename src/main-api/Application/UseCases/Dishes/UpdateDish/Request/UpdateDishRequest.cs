using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Dishes.UpdateDish.Request;
public class UpdateDishRequest : UseCases.Request
{
    [Required]
    public required Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = [];
}
