#pragma warning disable
using Domain.Models;
using Newtonsoft.Json;

namespace Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;

public class Root
{
    public List<Product> Products { get; set; }
    public Product product { get; set; }
}
public class Nutriments
{
    public double carbohydrates_100g { get; set; }
    public double carbohydrates_value { get; set; }
    public double energy { get; set; }

    [JsonProperty("energy-kcal_100g")]
    public double energykcal_100g { get; set; }

    [JsonProperty("energy-kcal_value")]
    public double energykcal_value { get; set; }

    [JsonProperty("energy-kj_100g")]
    public double energykj_100g { get; set; }

    [JsonProperty("energy-kj_value")]
    public double energykj_value { get; set; }
    public double fat_100g { get; set; }
    public double fat_value { get; set; }

    public double proteins_100g { get; set; }
    public double proteins_value { get; set; }
    public double salt_100g { get; set; }
    public double salt_value { get; set; }

    [JsonProperty("saturated-fat_100g")]
    public double saturatedfat_100g { get; set; }

    [JsonProperty("saturated-fat_value")]
    public double saturatedfat_value { get; set; }
    public double sodium_100g { get; set; }
    public double sodium_value { get; set; }
    public double sugars_100g { get; set; }
    public double sugars_value { get; set; }
}
public class Product
{
    public string _id { get; set; }
    public string brands { get; set; }
    public string code { get; set; }
    public string id { get; set; }
    public string labels { get; set; }
    public Nutriments nutriments { get; set; }
    public object popularity_key { get; set; }
    public string product_name { get; set; }
    public string product_name_en { get; set; }
    public string product_name_pl { get; set; }

}

#pragma warning enable