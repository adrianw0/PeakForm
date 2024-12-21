using Core.Common;

namespace Application.UseCases.Responses.Add;
public class AddErrorResponse<T> : AddReponse<T>
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
