using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;
public class Meal : IEntity
{
    public Guid Id { get; set; }
    public List<MealFoodItems> FoodItems { get; set; } = new();
    public DateTime Date { get; set; } = DateTime.Now;
    public string OwnerId { get; set; } = string.Empty;
}
