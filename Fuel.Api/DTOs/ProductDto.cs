using Core.Models;

namespace Fuel.Api.DTOs;

public class ProductDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<NutrientValues> Nutrients { get; set; } = new();

    public static ProductDto FromProduct(Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Ean = product.Ean,
            Description = product.Description,
            Nutrients = product.Nutrients,
        };
    }

    public static Product ToProduct(ProductDto productDto)
    {
        return new Product
        {
            Id = productDto.Id,
            Name = productDto.Name,
            Ean = productDto.Ean,
            Description = productDto.Description,
            Nutrients= productDto.Nutrients,
        };
    }

}
