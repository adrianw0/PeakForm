using Application.UseCases.MealHistory.AddMeal.Request;
using Application.UseCases.MealHistory.AddMeal.Response;
using Application.UseCases.Products.AddProduct;
using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MealHistory.AddMeal;
public class AddMealUseCase : IAddMealUseCase
{
    private readonly ILogger<AddMealUseCase> _logger;
    private readonly IReadRepository<Meal> _mealReadRepository;
    private readonly IWriteRepository<Meal> _mealWriteRepository;
    public AddMealUseCase(ILogger<AddMealUseCase> logger, IReadRepository<Meal> mealReadRepository, IWriteRepository<Meal> mealWriteRepository)
    {
        _logger = logger;
        _mealReadRepository = mealReadRepository;
        _mealWriteRepository = mealWriteRepository;
    }

    

    public async Task<AddMealReposnse> Execute(AddMealRequest request)
    {
        var meal = new Meal
        {
            Date = request.Date,
            FoodItems = request.FoodItems
        };

        try
        {
            await _mealWriteRepository.InsertOneAsync(meal); 
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            throw;
        }

        return new AddMealSuccessReposnse { Meal = meal };
    }
}
