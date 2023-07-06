using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;
public class NutrientValues
{
    [Required]
    public required Nutrient Nutrient { get; set; }
    [Required]
    public required double Value { get; set; }
}
