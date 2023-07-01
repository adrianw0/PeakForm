using Core.Common;

namespace Application.UseCases.MealHistory.DeleteMeal.Response;
public class DeleteMealErrorReposnse : DeleteMealReposnse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
