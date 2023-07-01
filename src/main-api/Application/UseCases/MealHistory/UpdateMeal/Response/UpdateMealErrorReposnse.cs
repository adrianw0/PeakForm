using Core.Common;

namespace Application.UseCases.MealHistory.UpdateMeal.Response;
public class UpdateMealErrorReposnse : UpdateMealReposnse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
