using Application.UseCases.Dishes.AddDish.Request;
using Application.UseCases.Responses.Add;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dishes.AddDish;
public interface IAddDishUseCase : IUseCase<AddDishRequest, AddReponse<Dish>>
{
}
