using Domain.Models;

namespace Infrastructure.Interfaces;
public interface IExternalProductApiWrapper
{
    public Task<Product?> GetProductByCodeAsync(string searchParam);
    public Task<List<Product>> GetProductsByNameAsync(string searchParam, int pageNumber, int pageSize);
}
