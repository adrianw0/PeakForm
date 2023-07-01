using Application.UseCases.Products.GetProducts.Request;
using Application.UseCases.Products.GetProducts.Response;


namespace Application.UseCases.Products.GetProducts;
public interface IGetProductsUseCase : IUseCase<GetProductsRequest, GetProductsResponse>
{
}
