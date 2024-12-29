namespace Application.UseCases.Responses.Get;
public class GetErrorResponse<T> : GetReponse<T>
{
    public string ErrorMessage { get; internal set; } = string.Empty;
}
