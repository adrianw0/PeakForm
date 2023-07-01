using Core.Common;

namespace Application.UseCases.Dishes.AddDish.Response;
public class AddDishErrorReposnse : UseCases.Response
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
