using Application.UseCases.Products.GetProducts.Response;
using Domain.Models;

namespace Application.UseCases.Products.GetProducts.Response;
public class GetProductsSuccessResponse : GetProductsResponse
{
    public List<Product> Products { get; set; } = new();
}
