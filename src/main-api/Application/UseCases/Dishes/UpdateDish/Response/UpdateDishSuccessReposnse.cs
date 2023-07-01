using Domain.Models;

namespace Application.UseCases.Dishes.UpdateDish.Response;
public class UpdateDishSuccessResponse : UpdateDishReposnse
{
    public Dish Dish { get; set; } = null!;
}
