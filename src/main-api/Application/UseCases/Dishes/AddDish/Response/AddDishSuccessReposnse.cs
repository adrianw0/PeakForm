using Domain.Models;

namespace Application.UseCases.Dishes.AddDish.Response;
public class AddDishSuccessReposnse : AddDishReposnse
{
    public Dish Dish { get; set; } = null!;
}
