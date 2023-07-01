namespace Application.UseCases.Dishes.GetDishes.Response;
public class GetDishesErrorReposnse : GetDishesReposnse
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
