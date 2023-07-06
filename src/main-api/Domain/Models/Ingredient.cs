using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;
public class Ingredient
{
    [Required]
    public required Product Product { get; set; }
    [Required]
    public required double Weight { get; set; }
    [Required]
    public required Unit Unit { get; set; }
}
