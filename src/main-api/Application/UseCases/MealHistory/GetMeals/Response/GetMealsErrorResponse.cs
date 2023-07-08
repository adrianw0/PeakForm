using Core.Common;

namespace Application.UseCases.MealHistory.GetMeals.Response;
public class GetMealsErrorResponse : GetMealsResponse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
