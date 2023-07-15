using System.ComponentModel.DataAnnotations;

namespace Domain.Models;

public class UnitWeight
{
    [Required]
    public required Unit Unit { get; set; }
    [Required]
    public required double Weight { get; set; }
}