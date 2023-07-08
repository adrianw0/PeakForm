using Domain.Models;
using Fuel.Api.DTOs;

namespace Fuel.Api.Mappers;

public static class DishMapper
{
    public static Dish MapToDomain(this DishDto dto)
    {
        return new Dish
        {
            Id = dto.Id,
            Name = dto.Name,
            Description = dto.Description,
            Ingredients = dto.Ingredients
        };
    }

    public static DishDto MapToDto(this Dish dish)
    {
        return new DishDto
        {
            Id = dish.Id,
            Name = dish.Name,
            Description = dish.Description,
            Ingredients = dish.Ingredients
        };
    }
}
