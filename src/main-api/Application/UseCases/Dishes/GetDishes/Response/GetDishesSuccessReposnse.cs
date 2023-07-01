using Domain.Models;

namespace Application.UseCases.Dishes.GetDishes.Response;
public class GetDishesSuccessResponse : GetDishesReposnse
{
    public List<Dish> Dishes { get; set; } = new();
}
