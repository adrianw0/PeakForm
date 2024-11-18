using Application.UseCases.MealHistory.AddMeal.Request;
using Application.UseCases.Responses.Add;
using Domain.Models;

namespace Application.UseCases.MealHistory.AddMeal;
public interface IAddMealUseCase : IUseCase<AddMealRequest, AddReponse<Meal>>
{
}
