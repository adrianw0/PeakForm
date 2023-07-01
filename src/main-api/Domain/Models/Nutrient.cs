using System.ComponentModel.DataAnnotations;

namespace Domain.Models;
public class Nutrient : IEntity
{
    public Guid Id { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required Unit Unit { get; set; }
}
