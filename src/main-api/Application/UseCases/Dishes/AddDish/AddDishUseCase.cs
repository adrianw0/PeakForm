using Application.UseCases.Dishes.AddDish.Request;
using Application.UseCases.Dishes.AddDish.Response;
using Application.UseCases.Dishes.GetDishes;
using Application.UseCases.Products.AddProduct;
using Core.Interfaces.Repositories;
using Core.Params;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dishes.AddDish;
public class AddDishUseCase : IAddDishUseCase
{
    private readonly IWriteRepository<Dish> _dishWriteRepository;

    public AddDishUseCase(IWriteRepository<Dish> dishWriteRepository)
    {
        _dishWriteRepository = dishWriteRepository;
    }



    public async Task<AddDishReposnse> Execute(AddDishRequest request)
    {
        var dish = new Dish
        {
            Name = request.Name,
            Description = request.Description,
            Ingredients = request.Ingredients
        };

        await _dishWriteRepository.InsertOneAsync(dish);

        return new AddDishSuccessReposnse { Dish = dish };

    }
}
