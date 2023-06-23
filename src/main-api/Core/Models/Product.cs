using Core.Interfaces;

namespace Core.Models;
public class Product : IEntity, IFoodItem, IVisibilityControl
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<NutrientValues> Nutrients { get; set; } = new();
    public User? Owner { get; set; }
    public bool IsGloballyVisible { get; set; }
}
