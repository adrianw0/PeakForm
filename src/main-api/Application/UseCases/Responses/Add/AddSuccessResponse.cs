namespace Application.UseCases.Responses.Add;
public class AddSuccessResponse<T> : AddReponse<T>
{
    public T? Entity { get; set; }
}
