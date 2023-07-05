using Application.Providers.Products;
using Application.UseCases.Products.GetProducts.Request;
using Application.UseCases.Products.GetProducts.Response;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.UseCases.Products.GetProducts;
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

    public async Task<GetProductsResponse> Execute(GetProductsRequest request)
    {
        Expression<Func<Product, bool>> predicate = p=>
        (p.Name.Contains(request.SearchParams) || p.Ean.Contains(request.SearchParams)) 
        && (p.OwnerId.Equals(_userProvider.UserId) || p.IsGloballyVisible);

        var products = new List<Product>();

        var dbProduct = await _productReadRepository
            .FindAsync(predicate, request.PagingParams.Page, request.PagingParams.PageSize);

        var externalProduct = await _externalProductProvider.GetProductsAsync(request.SearchParams);

        products.AddRange(dbProduct);
        products.AddRange(externalProduct);


        return new GetProductsSuccessResponse { Products = products.ToList() };
    }
}
