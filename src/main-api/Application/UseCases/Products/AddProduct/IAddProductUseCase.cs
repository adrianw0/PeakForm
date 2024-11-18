using Application.UseCases.Products.AddProduct.Request;
using Application.UseCases.Responses.Add;
using Domain.Models;

namespace Application.UseCases.Products.AddProduct;
public interface IAddProductUseCase : IUseCase<AddProductRequest, AddReponse<Product>>
{
}
