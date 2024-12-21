using Core.Common;

namespace Application.UseCases.Responses.Delete;
public class DeleteErrorResponse<T> : DeleteResponse<T>
{
    public string Message { get; internal set; } = string.Empty;
    public string Code { get; internal set; } = ErrorCodes.SomethingWentWrong;
}
