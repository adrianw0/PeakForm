using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.UpdateProduct.Request;
public class UpdateProductsRequest : UseCases.Request
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<NutrientValues> Nutrients { get; set; } = new();
}
