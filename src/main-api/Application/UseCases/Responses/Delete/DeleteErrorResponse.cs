
namespace Application.UseCases.Responses.Delete;
public class DeleteErrorResponse<T> : DeleteResponse<T>
{
    public string ErrorMessage { get; internal set; } = string.Empty;
}
