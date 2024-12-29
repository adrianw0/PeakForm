
using Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper.Extensions;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;



namespace Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;
public class OpenFoodFactsApiClient : IExternalProductApiClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<OpenFoodFactsApiClient> _logger;

    public OpenFoodFactsApiClient(HttpClient httpClient, ILogger<OpenFoodFactsApiClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

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
            return new List<Product>();
        }

        var responseContent = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<Root>(responseContent)?.Products;

        return result ?? new List<Product>();
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

        return !searchResult.Any() ? new List<Domain.Models.Product>() : searchResult.Select(p => p.MapToDomain()).ToList();
    }
    public async Task<Domain.Models.Product?> GetProductByCodeAsync(string searchParam)
    {
        var searchResult = await GetProductFromResponseByCodeAsync(Constants.SearchByCodeRequest, searchParam);

        return searchResult?.MapToDomain();
    }
}
