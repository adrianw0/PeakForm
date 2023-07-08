using Core.Common;

namespace Application.UseCases.MealHistory.UpdateMeal.Response;
public class UpdateMealErrorResponse : UpdateMealResponse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
