using Domain.Models;
namespace Application.Providers.Products;
public interface IExternalProductsProvider
{
    public Task<List<Product>> GetProductsByNameAsync(string searchParams, int page, int pageSize);
    public Task<Product?> GetProductByCodeAsync(string searchParams);
}
