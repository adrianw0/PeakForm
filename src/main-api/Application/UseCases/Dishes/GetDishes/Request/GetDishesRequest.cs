using Core.Params;

namespace Application.UseCases.Dishes.GetDishes.Request;
public class GetDishesRequest : UseCases.Request
{
    public PagingParams PagingParams { get; set; } = new();
    public string SearchParams { get; set; } = string.Empty;
}
