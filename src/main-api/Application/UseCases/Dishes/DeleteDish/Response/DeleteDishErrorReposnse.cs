namespace Application.UseCases.Dishes.DeleteDish.Response;
public class DeleteDishErrorResponse : DeleteDishReposnse
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
