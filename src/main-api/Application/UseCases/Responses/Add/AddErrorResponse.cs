
namespace Application.UseCases.Responses.Add;
public class AddErrorResponse<T> : AddReponse<T>
{
    public string ErrorMessage { get; internal set; } = string.Empty;
}
