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
    public GetProductsUseCase(IReadRepository<Product> productReadRepository, IUserProvider userProvider)
    {
        _productReadRepository = productReadRepository;
        _userProvider = userProvider;

    }

    public async Task<GetProductsResponse> Execute(GetProductsRequest request)
    {
        Expression<Func<Product, bool>> predicate = p=>
        (p.Name.Contains(request.SearchParams) || p.Ean.Contains(request.SearchParams)) 
        && (p.OwnerId.Equals(_userProvider.UserId) || p.IsGloballyVisible);

        var products = await _productReadRepository
            .FindAsync(predicate, request.PagingParams.Page, request.PagingParams.PageSize);

        return new GetProductsSuccessResponse { Products = products.ToList() };
    }
}
