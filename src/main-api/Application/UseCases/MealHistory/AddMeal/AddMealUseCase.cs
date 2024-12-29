using Application.UseCases.MealHistory.AddMeal.Request;
using Application.UseCases.Responses.Add;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;

namespace Application.UseCases.MealHistory.AddMeal;
public class AddMealUseCase(IWriteRepository<Meal> mealWriteRepository, IUserProvider userProvider) : IAddMealUseCase
{
    private readonly IWriteRepository<Meal> _mealWriteRepository = mealWriteRepository;
    private readonly IUserProvider _userProvider = userProvider;

    public async Task<AddReponse<Meal>> Execute(AddMealRequest request)
    {
        var meal = new Meal
        {
            Date = request.Date,
            FoodItems = request.FoodItems,
            OwnerId = _userProvider.UserId,
        };

        await _mealWriteRepository.InsertOneAsync(meal);


        return new AddSuccessResponse<Meal> { Entity = meal };
    }

}
