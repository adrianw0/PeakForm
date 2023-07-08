using Core.Common;

namespace Application.UseCases.Products.DeleteProduct.Response;
public class DeleteProductSuccessResponse : DeleteProductResponse
{
    public string Message { get; internal set; } = "Success";
}
