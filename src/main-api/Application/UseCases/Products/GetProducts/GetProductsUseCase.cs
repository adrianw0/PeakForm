using Application.Providers.Products;
using Application.UseCases.Products.GetProducts.Request;
using Application.UseCases.Responses.Get;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.UseCases.Products.GetProducts;

//TODO: Better paging
public class GetProductsUseCase : IGetProductsUseCase
{
    private readonly IReadRepository<Product> _productReadRepository;
    private readonly IUserProvider _userProvider;
    private readonly IExternalProductsProvider _externalProductProvider;
    public GetProductsUseCase(IReadRepository<Product> productReadRepository, IUserProvider userProvider, IExternalProductsProvider productsProvider)
    {
        _productReadRepository = productReadRepository;
        _userProvider = userProvider;
        _externalProductProvider = productsProvider;

    }

    public async Task<GetReponse<Product>> Execute(GetProductsRequest request)
    {
        List<Product> products = new();

        products.AddRange(await GetProductsFromDatabase(request));

        var externalProduct = await GetExternalProductByCode(request);

        if (externalProduct is not null)
        {
            products.Add(externalProduct);
            return new GetSuccessReponse<Product> { Entity = products };
        }

        products.AddRange(await GetExternalProductsByName(request));

        return new GetSuccessReponse<Product> { Entity = products };
    }


    private async Task<List<Product>> GetProductsFromDatabase(GetProductsRequest request)
    {
        var pageSize = (int)Math.Ceiling((double)request.PagingParams.PageSize / 2);

        var predicate = GetProductFilter(request);

        return (await _productReadRepository.FindAsync(predicate, request.PagingParams.Page, pageSize)).ToList();
    }

    private Expression<Func<Product, bool>> GetProductFilter(GetProductsRequest request)
    {
        return p => (p.Name.Contains(request.SearchParams) || p.Ean.Contains(request.SearchParams))
                    && (p.OwnerId.Equals(_userProvider.UserId) || p.IsGloballyVisible);
    }

    private async Task<Product?> GetExternalProductByCode(GetProductsRequest request)
    {
        return await _externalProductProvider.GetProductByCodeAsync(request.SearchParams);
    }

    private async Task<List<Product>> GetExternalProductsByName(GetProductsRequest request)
    {
        var pageSize = (int)Math.Ceiling((double)request.PagingParams.PageSize / 2);

        return await _externalProductProvider.GetProductsByNameAsync(request.SearchParams, request.PagingParams.Page, pageSize);
    }
}
