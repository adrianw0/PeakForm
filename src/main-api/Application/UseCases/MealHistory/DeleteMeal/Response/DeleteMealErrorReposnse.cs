namespace Application.UseCases.MealHistory.DeleteMeal.Response;
public class DeleteMealErrorReposnse : DeleteMealReposnse
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
