using Core.Interfaces;

namespace Core.Models;
public class Product : IEntity, IFoodItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Dictionary<Nutrient, double>> Nutrients { get; set; } = new();
}
