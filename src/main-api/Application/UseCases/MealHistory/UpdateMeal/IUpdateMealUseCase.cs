using Application.UseCases.MealHistory.UpdateMeal.Request;
using Application.UseCases.Responses.Update;
using Domain.Models;

namespace Application.UseCases.MealHistory.UpdateMeal;
public interface IUpdateMealUseCase : IUseCase<UpdateMealRequest, UpdateResponse<Meal>>
{
}
