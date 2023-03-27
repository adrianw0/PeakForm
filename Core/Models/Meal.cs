using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;
public class Meal
{
    public Guid Id { get; set; }
    List<Dictionary<IFoodItem, double>> FoodItems { get; set; } = new();
    public DateTime Date { get; set; }
}
