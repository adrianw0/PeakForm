using Core.Params;
using Domain.Models;
using System;
using System.Collections.Generic;
namespace Application.Providers.Products;
public interface IExternalProductsProvider
{
    public Task<List<Product>> GetProductsByNameAsync(string searchParams, PagingParams pagingParams);
    public Task<Product?> GetProductByCodeAsync(string searchParams);
}
