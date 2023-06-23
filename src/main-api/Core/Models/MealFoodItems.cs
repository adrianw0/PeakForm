using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;
public class MealFoodItems
{
    IFoodItem FoodItem { get; set; } = null!;
    decimal Weight { get; set; } = 0;
    public Unit WeightUnit { get; set; } = null!;
}
