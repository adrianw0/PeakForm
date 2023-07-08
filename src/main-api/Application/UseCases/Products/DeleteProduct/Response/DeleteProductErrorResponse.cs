using Core.Common;

namespace Application.UseCases.Products.DeleteProduct.Response;
public class DeleteProductErrorResponse : DeleteProductResponse
{
    public string Message { get; internal set; } =  string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
