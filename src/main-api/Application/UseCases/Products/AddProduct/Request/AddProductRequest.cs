using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Products.AddProduct.Request;
public class AddProductRequest : UseCases.Request
{
    [Required]
    public required string Name { get; set; }
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<NutrientValue> Nutrients { get; set; } = new();
    public List<UnitWeight> UnitWeights { get; set; }
    public Unit BaseUnit { get; set; }
}
