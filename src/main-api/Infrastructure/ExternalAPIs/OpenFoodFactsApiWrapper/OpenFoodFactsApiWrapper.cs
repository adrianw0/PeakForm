
using Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper.Extensions;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;
public class OpenFoodFactsApiWrapper : IExternalProductApiWrapper
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<OpenFoodFactsApiWrapper> _logger;

    public OpenFoodFactsApiWrapper(HttpClient httpClient, ILogger<OpenFoodFactsApiWrapper> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    //split because those are returned differently...
    private async Task<List<Product>> GetProductsFromResponseByName(string request, string serachParam)
    {
        var req = string.Format(request, serachParam);
        HttpResponseMessage response;

        try 
        { 
            response = await _httpClient.GetAsync(req);
            response.EnsureSuccessStatusCode();

        }catch(Exception ex)
        {
            _logger.LogError("Open food api call failed: ", ex);
            return new();
        }

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<Root>(responseContent)?.Products;

        return result ?? new();
    }

    private async Task<Product?> GetProductFromResponseByCodeAync(string request, string serachParam)
    {
        var req = string.Format(request, serachParam);
        HttpResponseMessage response;

        try
        {
            response = await _httpClient.GetAsync(req);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception ex)
        {
            _logger.LogError("Open food api call failed: ", ex);
            return null;
        }

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<Root>(responseContent);
        if (result is null) return null;
           
        return result.product;

    }

    public async Task<List<Domain.Models.Product>> GetProductsByNameAsync(string searchParam)
    {
        var searchResult = await GetProductsFromResponseByName(Constants.SearchByNameRequest, searchParam);

        if (searchResult is null || !searchResult.Any()) return new();
        return searchResult.Select(p => p.MapToDomain()).ToList();
    }
    public async Task<Domain.Models.Product?> GetProductByCodeAsync(string searchParam)
    {
        var searchResult = await GetProductFromResponseByCodeAync(Constants.SearchByCodeRequest, searchParam);

        return searchResult?.MapToDomain();
    }
}
