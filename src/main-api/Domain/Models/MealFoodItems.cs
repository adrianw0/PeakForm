using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;
public class MealFoodItems
{
    [Required]
    public required IFoodItem FoodItem { get; set; }
    [Required]
    public required decimal Weight { get; set; }
    [Required]
    public required Unit WeightUnit { get; set; }

}
