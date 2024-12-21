using Core.Params;

namespace Application.UseCases.MealHistory.GetMeals.Request;
public class GetMealsRequest : UseCases.Request
{
    public PagingParams PagingParams { get; set; } = new();
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}
