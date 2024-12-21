namespace Application.UseCases.Responses.Update;
public class UpdateSuccessResponse<T> : UpdateResponse<T>
{
    public T? Entity { get; internal set; }
}
