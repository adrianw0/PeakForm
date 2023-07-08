using Application.UseCases.MealHistory.DeleteMeal.Request;
using Application.UseCases.MealHistory.DeleteMeal.Response;
using Core.Common;
using Core.Interfaces.Providers;
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
    private readonly IReadRepository<Meal> _mealReadRepository;
    private readonly IUserProvider _userProvider;
    public DeleteMealUseCase(IWriteRepository<Meal> mealWriteRepository, IReadRepository<Meal> mealReadRepository, IUserProvider userProvider)
    {
        _mealWriteRepository = mealWriteRepository;
        _mealReadRepository = mealReadRepository;
        _userProvider = userProvider;
    }



    public async Task<DeleteMealResponse> Execute(DeleteMealRequest request)
    {
        var meal = await _mealReadRepository.FindByIdAsync(request.Id);
        if (!meal.OwnerId.Equals(_userProvider.UserId))
            return new DeleteMealErrorResponse { Code = ErrorCodes.NotFound };

        var deleted = await _mealWriteRepository.DeleteByIdAsync(request.Id);

        if (deleted) return new DeleteMealSuccessResponse();

        return new DeleteMealErrorResponse { Code = ErrorCodes.DeleteFailed };
    }
}
