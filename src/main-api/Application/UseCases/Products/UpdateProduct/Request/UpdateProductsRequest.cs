using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Products.UpdateProduct.Request;
public class UpdateProductsRequest : UseCases.Request
{
    [Required]
    public required Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<NutrientValue> Nutrients { get; set; } = [];
}
