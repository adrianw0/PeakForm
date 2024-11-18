using Application.UseCases.MealHistory.DeleteMeal.Request;
using Application.UseCases.Responses.Delete;
using Domain.Models;

namespace Application.UseCases.MealHistory.DeleteMeal;
public interface IDeleteMealUseCase : IUseCase<DeleteMealRequest, DeleteResponse<Meal>>
{
}
