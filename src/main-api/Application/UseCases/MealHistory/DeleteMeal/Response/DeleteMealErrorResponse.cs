using Core.Common;

namespace Application.UseCases.MealHistory.DeleteMeal.Response;
public class DeleteMealErrorResponse : DeleteMealResponse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
