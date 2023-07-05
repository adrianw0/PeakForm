
using Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper.Extensions;
using Infrastructure.Interfaces;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using OpenFoodFactsProduct = Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper.Product;

namespace Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;
public class OpenFoodFactsApiWrapper : IExternalProductApiWrapper
{
    private readonly HttpClient _httpClient;

    public OpenFoodFactsApiWrapper(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private async Task<List<OpenFoodFactsProduct>> GetProductsFromRequest(string request, string serachParam)
    {
        var req = string.Format(request, serachParam);

        var response = await _httpClient.GetAsync(req);
        
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Root>(responseContent)?.products ?? new List<OpenFoodFactsProduct>();
        
    }

    public async Task<List<Domain.Models.Product>> GetProductsAsync(string searchParam)
    {
        var byName = GetProductsFromRequest(Constants.SearchByNameRequest, searchParam);
        var byBarcode = GetProductsFromRequest(Constants.SearchByCodeRequest, searchParam);

        
        await Task.WhenAll(byName, byBarcode);

        var byNameResult = byName.Result.Select(p=>p.MapToDomain()).ToList();
        var byBarcodeResult = byBarcode.Result.Select(p=>p.MapToDomain()).ToList();
        

        return byNameResult.Concat(byBarcodeResult).ToList();

    }
}
