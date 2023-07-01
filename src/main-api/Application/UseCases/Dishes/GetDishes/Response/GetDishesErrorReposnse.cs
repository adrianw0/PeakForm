using Core.Common;

namespace Application.UseCases.Dishes.GetDishes.Response;
public class GetDishesErrorReposnse : GetDishesReposnse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
