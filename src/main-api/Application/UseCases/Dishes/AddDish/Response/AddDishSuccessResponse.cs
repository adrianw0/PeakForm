using Domain.Models;

namespace Application.UseCases.Dishes.AddDish.Response;
public class AddDishSuccessResponse : AddDishResponse
{
    public Dish Dish { get; set; } = null!;
}
