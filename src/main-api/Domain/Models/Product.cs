using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Product : IEntity, IFoodItem, IVisibilityControl
{
    public Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<NutrientValues> Nutrients { get; set; } = new();
    public string OwnerId { get; set; } = string.Empty;
    public bool IsGloballyVisible { get; set; }
}
