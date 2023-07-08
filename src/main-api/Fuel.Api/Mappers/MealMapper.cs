﻿using Domain.Models;
using Fuel.Api.DTOs;

namespace Fuel.Api.Mappers;

public static class MealMapper
{
    public static Meal MapToDomain(this MealDto dto)
    {
        return new Meal
        {
            Id = dto.Id,
            Date = dto.Date,
            FoodItems = dto.FoodItems
        };
    }
    public static MealDto MapToDto(this Meal meal)
    {
        return new MealDto
        {
            Id = meal.Id,
            Date = meal.Date,
            FoodItems = meal.FoodItems
        };
    }
}
