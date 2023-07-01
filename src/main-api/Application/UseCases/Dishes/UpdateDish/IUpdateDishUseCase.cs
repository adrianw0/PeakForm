using Application.UseCases.Dishes.UpdateDish.Request;
using Application.UseCases.Dishes.UpdateDish.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dishes.UpdateDish;
public interface IUpdateDishUseCase : IUseCase<UpdateDishRequest, UpdateDishReposnse>
{
}
