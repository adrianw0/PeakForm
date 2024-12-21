using Core.Common;

namespace Application.UseCases.Responses.Update;
public class UpdateErrorResponse<T> : UpdateResponse<T>
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
