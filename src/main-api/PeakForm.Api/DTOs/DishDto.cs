using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace PeakForm.Api.DTOs;

public class DishDto
{
    public Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<Ingredient> Ingredients { get; set; } = [];
}
