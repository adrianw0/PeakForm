namespace Application.UseCases.Responses.Delete;
public class DeleteSuccessResponse<T> : DeleteResponse<T>
{
    public string Message { get; internal set; } = "Success";
}
