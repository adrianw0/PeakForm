using Domain.Models;
using System;
using System.Collections.Generic;
namespace Application.Providers.Products;
public interface IExternalProductsProvider
{
    public Task<List<Product>> GetProductsAsync(string searchParams);
}
