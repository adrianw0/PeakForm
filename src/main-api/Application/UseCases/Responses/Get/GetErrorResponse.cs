using Core.Common;

namespace Application.UseCases.Responses.Get;
public class GetErrorResponse<T> : GetReponse<T>
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
