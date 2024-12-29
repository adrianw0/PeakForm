namespace Application.UseCases.Responses.Get;
public class GetSuccessReponse<T> : GetReponse<T>
{
    public required List<T> Entity { get; set; } = [];
}
