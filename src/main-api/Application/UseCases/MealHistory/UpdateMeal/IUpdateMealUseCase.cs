using Application.UseCases.MealHistory.UpdateMeal.Request;
using Application.UseCases.MealHistory.UpdateMeal.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MealHistory.UpdateMeal;
public interface IUpdateMealUseCase : IUseCase<UpdateMealRequest, UpdateMealResponse>
{
}
