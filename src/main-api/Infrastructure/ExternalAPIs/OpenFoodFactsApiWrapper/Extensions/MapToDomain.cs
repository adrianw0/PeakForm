using Core.Models.Constants;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper.Extensions;
public static class ProductMapper
{
    internal static Product MapToDomain(this OpenFoodFactsProduct externalProduct)
    {
        return new Product
        {
            Name = externalProduct.ProductName,
            Ean = externalProduct.Code,
            OwnerId = string.Empty,
            Nutrients = externalProduct.Nutriments.MapToDomainNutrients()
        };
    }

    internal static List<NutrientValues> MapToDomainNutrients(this Nutriments externalNutriment)
    {
        var gramUnit = new Unit { Code = UnitsContants.GramCode, Name = UnitsContants.GramName };

        var values = new List<NutrientValues>
        {
            new NutrientValues{ Nutrient =  new Nutrient { Name = NutrientNames.Proteins, Unit = gramUnit }, Value = externalNutriment.proteins_100g },
            new NutrientValues{ Nutrient =  new Nutrient { Name = NutrientNames.Carbohydrates, Unit = gramUnit }, Value = externalNutriment.carbohydrates_100g },
            new NutrientValues{ Nutrient =  new Nutrient { Name = NutrientNames.Fats, Unit = gramUnit }, Value = externalNutriment.fat_100g },
            new NutrientValues{ Nutrient =  new Nutrient { Name = NutrientNames.Sugar, Unit = gramUnit }, Value = externalNutriment.sugars_100g },
            new NutrientValues{ Nutrient =  new Nutrient { Name = NutrientNames.Fibre, Unit = gramUnit }, Value = externalNutriment.fiber_100g}
        };

        return values;
    } //TODO: automate this...
}

