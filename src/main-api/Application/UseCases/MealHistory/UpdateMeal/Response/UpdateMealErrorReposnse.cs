namespace Application.UseCases.MealHistory.UpdateMeal.Response;
public class UpdateMealErrorReposnse : UpdateMealReposnse
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
