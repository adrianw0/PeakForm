using Application.UseCases.Products.GetProducts.Request;
using Application.UseCases.Responses.Get;
using Domain.Models;


namespace Application.UseCases.Products.GetProducts;
public interface IGetProductsUseCase : IUseCase<GetProductsRequest, GetReponse<Product>>
{
}
