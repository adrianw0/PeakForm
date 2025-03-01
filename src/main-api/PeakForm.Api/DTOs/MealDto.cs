﻿using Domain.Models;

namespace PeakForm.Api.DTOs;

public class MealDto
{
    public Guid Id { get; set; }
    public List<MealFoodItem> FoodItems { get; set; } = [];
    public DateTime Date { get; set; }
}
