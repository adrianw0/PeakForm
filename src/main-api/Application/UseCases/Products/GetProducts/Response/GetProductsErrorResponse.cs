using Application.UseCases.Products.AddProduct.Response;
using Core.Common;

namespace Application.UseCases.Products.GetProducts.Response;
public class GetProductsErrorResponse : GetProductsResponse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
