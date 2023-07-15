using Domain.Models;
using Domain.Models.Constants;
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
            NutrientsPer1G = externalProduct.nutriments.MapToDomainNutrients(),
            IsGloballyVisible = true
        };
    }

    private static List<NutrientValue> MapToDomainNutrients(this Nutriments externalNutriment)
    {
        var gramUnit = new Unit { Code = UnitsConstants.GramCode, Name = UnitsConstants.GramName };

        var values = new List<NutrientValue>
        {
            new() { Nutrient =  new Nutrient { Name = NutrientNames.Proteins, Unit = gramUnit }, Value = externalNutriment.proteins_100g },
            new() { Nutrient =  new Nutrient { Name = NutrientNames.Carbohydrates, Unit = gramUnit }, Value = externalNutriment.carbohydrates_100g },
            new() { Nutrient =  new Nutrient { Name = NutrientNames.Fats, Unit = gramUnit }, Value = externalNutriment.fat_100g },
            new() { Nutrient =  new Nutrient { Name = NutrientNames.Sugar, Unit = gramUnit }, Value = externalNutriment.sugars_100g }
        };

        return values;
    } 
}

