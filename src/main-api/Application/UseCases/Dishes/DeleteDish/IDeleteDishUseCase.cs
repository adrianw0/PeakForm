using Application.UseCases.Dishes.DeleteDish.Request;
using Application.UseCases.Responses.Delete;
using Domain.Models;

namespace Application.UseCases.Dishes.DeleteDish;
public interface IDeleteDishUseCase : IUseCase<DeleteDishRequest, DeleteResponse<Dish>>
{
}
