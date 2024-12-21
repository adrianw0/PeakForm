using Application.UseCases.Dishes.AddDish.Request;
using Application.UseCases.Responses.Add;
using Domain.Models;

namespace Application.UseCases.Dishes.AddDish;
public interface IAddDishUseCase : IUseCase<AddDishRequest, AddReponse<Dish>>
{
}
