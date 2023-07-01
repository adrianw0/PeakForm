using Application.UseCases.Products.GetProducts.Request;
using Application.UseCases.Products.GetProducts.Response;
using Core.Common;
using Core.Interfaces.Repositories;
using Core.Params;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.GetProducts;
public class GetProductsUseCase : IGetProductsUseCase
{
    private readonly IReadRepository<Product> _productReadRepository;
    public GetProductsUseCase(IReadRepository<Product> productReadRepository)
    {
        _productReadRepository = productReadRepository;
    }

    public async Task<GetProductsResponse> Execute(GetProductsRequest request)
    {

        var products = await _productReadRepository
            .FindAsync(p => p.Name.Contains(request.SearchParams) || p.Ean.Contains(request.SearchParams), request.PagingParams.Page, request.PagingParams.PageSize);

        return new GetProductsSuccessResponse { Products = products.ToList() };
    }
}
