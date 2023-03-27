namespace Core.Models;
public class Nutrient
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public Unit Unit { get; set; } = null!; 
}
