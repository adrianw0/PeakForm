using Core.Common;

namespace Application.UseCases.MealHistory.AddMeal.Response;
public class AddMealErrorResponse : AddMealResponse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
