using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;
public class Ingredient
{
    public Product Product { get; set; } = null!;
    public decimal Weight { get; set; }
    public Unit Unit { get; set; } = null!;
}
