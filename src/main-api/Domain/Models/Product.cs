using Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public record Product : IEntity, IFoodItem, IVisibilityControl
{
    public Guid Id { get; init; }
    [Required]
    public required string Name { get; set; }
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<NutrientValue> NutrientsPer1G { get; set; } = new();
    public List<UnitWeight> UnitWeights { get; set; } = new();
    public string OwnerId { get; init; } = string.Empty;
    public bool IsGloballyVisible { get; set; }
}