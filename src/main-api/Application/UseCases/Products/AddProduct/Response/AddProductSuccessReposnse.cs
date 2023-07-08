using Domain.Models;

namespace Application.UseCases.Products.AddProduct.Response;
public class AddProductSuccessResponse : AddProductResponse
{
    public Product Product { get; internal set; } = null!;
}
