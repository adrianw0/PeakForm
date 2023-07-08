using Core.Common;

namespace Application.UseCases.Products.AddProduct.Response;
public class AddProductErrorResponse : AddProductResponse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
