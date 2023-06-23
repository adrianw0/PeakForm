 using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;
public class Meal : IEntity
{
    public Guid Id { get; set; }
    public List<MealFoodItems> FoodItems { get; set; } = new();
    public DateTime Date { get; set; }
    public User? Owner { get; set; }
}
