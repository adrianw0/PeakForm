using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MealHistory.UpdateMeal.Request;
public class UpdateMealRequest : UseCases.Request
{
    public Guid Id { get; set; }
    public List<MealFoodItems> FoodItems { get; set; } = new();
}
