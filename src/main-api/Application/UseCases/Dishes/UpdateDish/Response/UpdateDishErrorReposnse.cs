namespace Application.UseCases.Dishes.UpdateDish.Response;
public class UpdateDishErrorResponse : UpdateDishReposnse
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
