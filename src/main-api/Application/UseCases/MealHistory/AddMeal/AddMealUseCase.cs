using Application.UseCases.MealHistory.AddMeal.Request;
using Application.UseCases.MealHistory.AddMeal.Response;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.Extensions.Logging;

namespace Application.UseCases.MealHistory.AddMeal;
public class AddMealUseCase : IAddMealUseCase
{
    private readonly IWriteRepository<Meal> _mealWriteRepository;
    private readonly IUserProvider _userProvider;

    public AddMealUseCase(IWriteRepository<Meal> mealWriteRepository, IUserProvider userProvider)
    {
        _mealWriteRepository = mealWriteRepository;
        _userProvider = userProvider;
    }

    public async Task<AddMealResponse> Execute(AddMealRequest request)
    {
        var meal = new Meal
        {
            Date = request.Date,
            FoodItems = request.FoodItems,
            OwnerId = _userProvider.UserId,
        };

        await _mealWriteRepository.InsertOneAsync(meal);


        return new AddMealSuccessResponse { Meal = meal };
    }

}
