using Core.Params;

namespace Application.UseCases.Products.GetProducts.Request;
public class GetProductsRequest : UseCases.Request
{
    public PagingParams PagingParams { get; set; } = new();
    public string SearchParams { get; set; } = string.Empty;
}
