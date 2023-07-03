using Application.UseCases.Dishes.GetDishes.Request;
using Application.UseCases.Dishes.GetDishes.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dishes.GetDishes;
public interface IGetDishesUseCase : IUseCase<GetDishesRequest, GetDishesReposnse>
{

}
