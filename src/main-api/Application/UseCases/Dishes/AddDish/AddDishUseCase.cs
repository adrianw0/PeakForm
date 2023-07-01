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
    private readonly ILogger _logger;

    public AddDishUseCase(ILogger<IGetDishesUseCase> logger, IWriteRepository<Dish> dishWriteRepository)
    {
        _dishWriteRepository = dishWriteRepository;
        _logger = logger;
    }



    public async Task<AddDishReposnse> Execute(AddDishRequest request)
    {
        var dish = new Dish
        {
            Name = request.Name,
            Description = request.Description,
            Ingredients = request.Ingredients
        };

        try
        {
            await _dishWriteRepository.InsertOneAsync(dish);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }

        return new AddDishSuccessReposnse { Dish = dish };

    }
}
