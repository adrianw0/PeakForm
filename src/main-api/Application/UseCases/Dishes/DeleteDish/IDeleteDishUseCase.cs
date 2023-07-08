using Application.UseCases.Dishes.DeleteDish.Request;
using Application.UseCases.Dishes.DeleteDish.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dishes.DeleteDish;
public interface IDeleteDishUseCase : IUseCase<DeleteDishRequest, DeleteDishResponse>
{
}
