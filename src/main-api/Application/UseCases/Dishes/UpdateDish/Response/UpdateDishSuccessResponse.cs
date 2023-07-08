using Domain.Models;

namespace Application.UseCases.Dishes.UpdateDish.Response;
public class UpdateDishSuccessResponse : UpdateDishResponse
{
    public required Dish Dish { get; set; }
}
