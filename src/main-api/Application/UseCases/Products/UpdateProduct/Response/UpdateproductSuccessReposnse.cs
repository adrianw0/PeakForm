using Application.UseCases.Products.GetProducts.Response;
using Domain.Models;

namespace Application.UseCases.Products.UpdateProduct.Response;
public class UpdateProductSuccessResponse : UpdateProductResponse
{
    public Product Product { get; set; }
}
