using Application.UseCases.Products.UpdateProduct.Request;
using Application.UseCases.Responses.Update;
using Domain.Models;

namespace Application.UseCases.Products.UpdateProduct;
public interface IUpdateProductUseCase : IUseCase<UpdateProductsRequest, UpdateResponse<Product>>
{
}
