using Application.UseCases.Dishes.UpdateDish.Request;
using Application.UseCases.Responses.Update;
using Domain.Models;

namespace Application.UseCases.Dishes.UpdateDish;
public interface IUpdateDishUseCase : IUseCase<UpdateDishRequest, UpdateResponse<Dish>>
{
}
