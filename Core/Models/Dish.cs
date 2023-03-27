
using Core.Interfaces;

namespace Core.Models;
public class Dish : IFoodItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}
