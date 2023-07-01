using Application.UseCases.Products.AddProduct.Response;

namespace Application.UseCases.Products.GetProducts.Response;
public class GetProductsErrorResponse : GetProductsResponse
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
