
using Domain.Models;

namespace Fuel.Api.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<NutrientValue> Nutrients { get; set; } = [];
}
