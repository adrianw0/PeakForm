using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models;
public class Product
{
    public string Name { get; set; } = null!;
    public string Ean { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public List<Dictionary<Nutrient, double>> Nutrients { get; set; } = new();

}
