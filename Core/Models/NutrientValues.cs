using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;
public class NutrientValues
{
    public Nutrient Nutrient { get; set; } = null!;
    public decimal Value { get; set; } = 0;
}
