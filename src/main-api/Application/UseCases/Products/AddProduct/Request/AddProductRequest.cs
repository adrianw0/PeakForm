using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Products.AddProduct.Request;
public class AddProductRequest : UseCases.Request
{
    [Required]
    public required string Name { get; set; }
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<NutrientValue> Nutrients { get; set; } = [];
    public List<UnitWeight> UnitWeights { get; set; } = [];
    public required Unit BaseUnit { get; set; }
}
