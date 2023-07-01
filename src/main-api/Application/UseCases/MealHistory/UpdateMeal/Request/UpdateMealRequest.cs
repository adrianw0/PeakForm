using Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MealHistory.UpdateMeal.Request;
public class UpdateMealRequest : UseCases.Request
{
    [Required]
    public required Guid Id { get; set; }
    public List<MealFoodItems> FoodItems { get; set; } = new();
}
