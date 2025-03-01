﻿using Domain.Models;
using Infrastructure.Interfaces;

namespace Application.Providers.Products;
public class ExternalProductsProvider(IExternalProductApiClient externalProductApiWrapper) : IExternalProductsProvider
{
    private readonly IExternalProductApiClient _externalProductApiWrapper = externalProductApiWrapper;

    public async Task<Product?> GetProductByCodeAsync(string searchParams)
    {
        return await _externalProductApiWrapper.GetProductByCodeAsync(searchParams);
    }

    public async Task<List<Product>> GetProductsByNameAsync(string searchParams, int page, int pageSize)
    {
        return await _externalProductApiWrapper.GetProductsByNameAsync(searchParams, page, pageSize);
    }
}
