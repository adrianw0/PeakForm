using Application.UseCases.MealHistory.DeleteMeal.Request;
using Application.UseCases.MealHistory.DeleteMeal.Response;
using Core.Common;
using Core.Interfaces.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MealHistory.DeleteMeal;
public class DeleteMealUseCase : IDeleteMealUseCase
{
    private readonly IWriteRepository<Meal> _mealWriteRepository;
    public DeleteMealUseCase( IWriteRepository<Meal> mealWriteRepository)
    {
        _mealWriteRepository = mealWriteRepository;
    }

    

    public async Task<DeleteMealReposnse> Execute(DeleteMealRequest request)
    {
        var deleted = await _mealWriteRepository.DeleteByIdAsync(request.Id);

        if (deleted) return new DeleteMealSuccessReposnse();

        return new DeleteMealErrorReposnse { Message = ErrorMessages.DeleteFailed };
    }
}
