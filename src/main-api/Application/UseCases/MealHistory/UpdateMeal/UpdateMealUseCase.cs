using Application.UseCases.MealHistory.UpdateMeal.Request;
using Application.UseCases.MealHistory.UpdateMeal.Response;
using Core.Common;
using Core.Interfaces.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MealHistory.UpdateMeal;

public class UpdateMealUseCase : IUpdateMealUseCase
{
    private readonly IReadRepository<Meal> _mealReadRepository;
    private readonly IWriteRepository<Meal> _mealWriteRepository;
    public UpdateMealUseCase(IReadRepository<Meal> mealReadRepository, IWriteRepository<Meal> mealWriteRepository)
    {
        _mealReadRepository = mealReadRepository;
        _mealWriteRepository = mealWriteRepository;
    }

    public async Task<UpdateMealReposnse> Execute(UpdateMealRequest request)
    {
        bool updated;

        var meal = new Meal
        {
            Id = request.Id,
            FoodItems = request.FoodItems
        };

        updated = await _mealWriteRepository.UpdateAsync(meal);

        if (updated) return new UpdateMealSuccessReposnse { Meal = meal };

        return new UpdateMealErrorReposnse { Message = ErrorMessages.MealupdateFailed };
    }
}
