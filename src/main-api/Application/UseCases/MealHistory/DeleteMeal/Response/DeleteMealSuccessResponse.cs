namespace Application.UseCases.MealHistory.DeleteMeal.Response;
public class DeleteMealSuccessResponse : DeleteMealResponse
{
    public string Message { get; internal set; } = "Success";
}
