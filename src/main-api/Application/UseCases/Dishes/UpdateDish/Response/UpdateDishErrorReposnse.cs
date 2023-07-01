using Core.Common;

namespace Application.UseCases.Dishes.UpdateDish.Response;
public class UpdateDishErrorResponse : UpdateDishReposnse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
