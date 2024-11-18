using Application.UseCases.Dishes.GetDishes.Request;
using Application.UseCases.Responses.Get;
using Domain.Models;

namespace Application.UseCases.Dishes.GetDishes;
public interface IGetDishesUseCase : IUseCase<GetDishesRequest, GetReponse<Dish>>
{

}
