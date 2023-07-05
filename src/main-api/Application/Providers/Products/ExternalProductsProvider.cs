using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Providers.Products;
public class ExternalProductsProvider : IExternalProductsProvider
{
    private readonly IExternalProductApiWrapper _externalProductApiWrapper;
    public ExternalProductsProvider(IExternalProductApiWrapper externalProductApiWrapper)
    {
        _externalProductApiWrapper = externalProductApiWrapper;
    }
    public async Task<List<Product>> GetProductsAsync(string searchParams)
    {
        return await _externalProductApiWrapper.GetProductsAsync(searchParams);
    }
}
