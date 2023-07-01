using Core.Common;

namespace Application.UseCases.Dishes.DeleteDish.Response;
public class DeleteDishErrorResponse : DeleteDishReposnse
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
