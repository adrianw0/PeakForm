
namespace Application.UseCases.Responses.Update;
public class UpdateErrorResponse<T> : UpdateResponse<T>
{
    public string ErrorMessage { get; internal set; } = string.Empty;
}
