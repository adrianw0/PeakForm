using Application.UseCases.MealHistory.DeleteMeal.Request;
using Application.UseCases.MealHistory.DeleteMeal.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MealHistory.DeleteMeal;
public interface IDeleteMealUseCase : IUseCase<DeleteMealRequest, DeleteMealResponse>
{
}
