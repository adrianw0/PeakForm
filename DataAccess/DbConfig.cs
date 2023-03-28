using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace DataAccess;

#pragma warning disable
public class DbConfig
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
    public string DishesCollectionName { get; set; }
    public string MealsCollectionName { get; set; }
    public string NutrientsCollectionName { get; set; }
    public string ProductsCollectionName { get; set; }
    public string UnitsCollectionName { get; set; }


}
