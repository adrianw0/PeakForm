using Application.UseCases.Products.GetProducts.Response;

namespace Application.UseCases.Products.UpdateProduct.Response;
public class UpdateProductErrorResponse : UpdateProductResponse
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
