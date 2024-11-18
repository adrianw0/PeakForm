using Application.UseCases.Products.DeleteProduct.Request;
using Application.UseCases.Responses.Delete;
using Domain.Models;

namespace Application.UseCases.Products.DeleteProduct;
public interface IDeleteProductUseCase : IUseCase<DeleteProductRequest, DeleteResponse<Product>>
{
}
