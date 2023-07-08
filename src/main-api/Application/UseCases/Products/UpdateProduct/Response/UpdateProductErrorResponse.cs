using Application.UseCases.Products.GetProducts.Response;
using Core.Common;

namespace Application.UseCases.Products.UpdateProduct.Response;
public class UpdateProductErrorResponse : UpdateProductResponse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
