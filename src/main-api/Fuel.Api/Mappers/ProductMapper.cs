using Domain.Models;
using Fuel.Api.DTOs;

namespace Fuel.Api.Mappers;

public static class ProductMapper
{
    public static Product MapToDomain(this ProductDto dto)
    {
        return new Product
        {
            Id = dto.Id,
            Name = dto.Name,
            Ean = dto.Ean,
            Description = dto.Description,
            NutrientsPer1G = dto.Nutrients
        };
    }

    public static ProductDto MapToDto(this Product product)
    {
        return new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Ean = product.Ean,
            Description = product.Description,
            Nutrients = product.NutrientsPer1G
        };
    }
}
