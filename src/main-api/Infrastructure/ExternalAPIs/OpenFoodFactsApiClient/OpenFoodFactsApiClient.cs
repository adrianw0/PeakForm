using Infrastructure.ExternalAPIs.OpenFoodFactsApiClient.Extensions;
using Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;



namespace Infrastructure.ExternalAPIs.OpenFoodFactsApiClient;
public class OpenFoodFactsApiClient(HttpClient httpClient, ILogger<OpenFoodFactsApiClient> logger) : IExternalProductApiClient
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly ILogger<OpenFoodFactsApiClient> _logger = logger;

    //split because those are returned differently...
    private async Task<List<Product>> GetProductsFromResponseByName(string request, string searchParam, int pageNumber, int pageSize)
    {
        var req = string.Format(request, searchParam, pageNumber, pageSize);
        HttpResponseMessage response;

        try
        {
            _logger.LogInformation("calling OpenFoodFacts, req: {request}", req);
            response = await _httpClient.GetAsync(req);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception ex)
        {
            _logger.LogError("Open food api call failed: {ex}", ex);
            return [];
        }

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<Root>(responseContent)?.Products;

        return result ?? [];
    }

    private async Task<Product?> GetProductFromResponseByCodeAsync(string request, string searchParam)
    {
        var req = string.Format(request, searchParam);
        HttpResponseMessage response;

        try
        {
            _logger.LogInformation("calling OpenFoodFacts, req: {request}", req);
            response = await _httpClient.GetAsync(req);
            response.EnsureSuccessStatusCode();

        }
        catch (Exception ex)
        {
            _logger.LogError("Open food api call failed: {ex}", ex);
            return null;
        }

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<Root>(responseContent);
        return result?.product;
    }

    public async Task<List<Domain.Models.Product>> GetProductsByNameAsync(string searchParam, int pageNumber, int pageSize)
    {
        var searchResult = await GetProductsFromResponseByName(Constants.SearchByNameRequest, searchParam, pageNumber, pageSize);

        return searchResult.Count == 0 ? [] : searchResult.Select(p => p.MapToDomain()).ToList();
    }
    public async Task<Domain.Models.Product?> GetProductByCodeAsync(string searchParam)
    {
        var searchResult = await GetProductFromResponseByCodeAsync(Constants.SearchByCodeRequest, searchParam);

        return searchResult?.MapToDomain();
    }
}
