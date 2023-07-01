using Application.UseCases.MealHistory.AddMeal.Request;
using Application.UseCases.MealHistory.AddMeal.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MealHistory.AddMeal;
public interface IAddMealUseCase : IUseCase<AddMealRequest, AddMealReposnse>
{
}
