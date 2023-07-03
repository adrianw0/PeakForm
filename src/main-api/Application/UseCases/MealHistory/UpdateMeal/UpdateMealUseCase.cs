using Application.UseCases.MealHistory.UpdateMeal.Request;
using Application.UseCases.MealHistory.UpdateMeal.Response;
using Core.Common;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;


namespace Application.UseCases.MealHistory.UpdateMeal;

public class UpdateMealUseCase : IUpdateMealUseCase
{
    private readonly IWriteRepository<Meal> _mealWriteRepository;
    private readonly IReadRepository<Meal> _mealReadRepository;
    private readonly IUserProvider _userProvider;
    public UpdateMealUseCase(IWriteRepository<Meal> mealWriteRepository, IReadRepository<Meal> mealReadRepository, IUserProvider userProvider)
    {
        _mealWriteRepository = mealWriteRepository;
        _mealReadRepository = mealReadRepository;
        _userProvider = userProvider;
    }

    public async Task<UpdateMealReposnse> Execute(UpdateMealRequest request)
    {

        var meal = await  _mealReadRepository.FindByIdAsync(request.Id);
        if (meal is null || !meal.OwnerId.Equals(_userProvider.UserId))
            return new UpdateMealErrorReposnse { Code = ErrorCodes.NotFound };

        var updateMeal = new Meal
        {
            Id = request.Id,
            FoodItems = request.FoodItems,
            OwnerId = _userProvider.UserId
        };

        var updated = await _mealWriteRepository.UpdateAsync(updateMeal);

        if (updated) return new UpdateMealSuccessReposnse { Meal = updateMeal };

        return new UpdateMealErrorReposnse { Code = ErrorCodes.MealupdateFailed };
    }
}
