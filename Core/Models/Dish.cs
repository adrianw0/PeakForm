
using Core.Interfaces;

namespace Core.Models;
public class Dish : IDocument, IFoodItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
}
