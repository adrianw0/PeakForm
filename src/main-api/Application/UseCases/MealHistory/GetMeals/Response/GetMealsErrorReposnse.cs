namespace Application.UseCases.MealHistory.GetMeals.Response;
public class GetMealsErrorReposnse : GetMealsReposnse
{
    public string Message { get; internal set; }
    public string Code { get; internal set; }
}
