using Application.UseCases.MealHistory.GetMeals.Request;
using Application.UseCases.Responses.Get;
using Domain.Models;

namespace Application.UseCases.MealHistory.GetMeals;
public interface IGetMealsUseCase : IUseCase<GetMealsRequest, GetReponse<Meal>>
{
}
