namespace Application.UseCases.Dishes.AddDish.Response;
public class AddDishErrorReposnse : UseCases.Response
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
