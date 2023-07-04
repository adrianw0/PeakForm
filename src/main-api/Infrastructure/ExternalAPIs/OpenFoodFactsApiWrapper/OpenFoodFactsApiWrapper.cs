
using Domain.Models;
using Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper.Extensions;
using Infrastructure.Interfaces;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;
public class OpenFoodFactsApiWrapper : IExternalProductApiWrapper
{
    private readonly HttpClient _httpClient;

    public OpenFoodFactsApiWrapper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }



    private async Task<List<OpenFoodFactsProduct>> GetProductByBarcode(string serachParam)
    {
        var response = await _httpClient.GetStringAsync($"https://world.openfoodfacts.org/api/v0/product/{serachParam}.json=1");

        return JsonConvert.DeserializeObject<List<OpenFoodFactsProduct>>(response) ?? new();
    }
    private async Task<List<OpenFoodFactsProduct>> GetProductByName(string serachParam)
    {
        var response = await _httpClient.GetStringAsync($"https://world.openfoodfacts.org/cgi/search.pl?search_terms={serachParam}&json=1");

        return JsonConvert.DeserializeObject<List<OpenFoodFactsProduct>>(response) ?? new();
    }

    public async Task<List<Product>> GetProducts(string searchParam)
    {
        var byName = GetProductByName(searchParam);
        var byBarcode = GetProductByBarcode(searchParam);

        
        await Task.WhenAll(byName, byBarcode);

        var byNameResult = byName.Result.Select(p=>p.MapToDomain()).ToList();
        var byBarcodeResult = byBarcode.Result.Select(p=>p.MapToDomain()).ToList();
        

        return byNameResult.Concat(byBarcodeResult).ToList();

    }
}
