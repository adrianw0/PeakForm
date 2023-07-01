namespace Application.UseCases.MealHistory.AddMeal.Response;
public class AddMealErrorReposnse : AddMealReposnse
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
