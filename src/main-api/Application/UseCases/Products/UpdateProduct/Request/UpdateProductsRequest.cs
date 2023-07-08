using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.UpdateProduct.Request;
public class UpdateProductsRequest : UseCases.Request
{
    [Required]
    public required Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<NutrientValues> Nutrients { get; set; } = new();
}
