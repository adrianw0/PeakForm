using Core.Models.Constants;
using Domain.Models;
using OpenFoodFactsProduct = Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper.Product;

namespace Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper.Extensions;
internal static class ProductMapper
{
    internal static Domain.Models.Product MapToDomain(this OpenFoodFactsProduct externalProduct)
    {
        return new Domain.Models.Product
        {
            Name = externalProduct.product_name,
            Ean = externalProduct.code,
            OwnerId = string.Empty,
            Nutrients = externalProduct.nutriments.MapToDomainNutrients(),
            IsGloballyVisible = true
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
            new NutrientValues{ Nutrient =  new Nutrient { Name = NutrientNames.Sugar, Unit = gramUnit }, Value = externalNutriment.sugars_100g }
        };

        return values;
    } 
}

