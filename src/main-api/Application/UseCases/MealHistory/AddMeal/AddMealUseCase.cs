using Application.UseCases.MealHistory.AddMeal.Request;
using Application.UseCases.Responses.Add;
using Application.Validators.Requests;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using FluentValidation;

namespace Application.UseCases.MealHistory.AddMeal;
public class AddMealUseCase(IWriteRepository<Meal> mealWriteRepository, IUserProvider userProvider, IValidator<AddMealRequest> requestValidator) : IAddMealUseCase
{
    private readonly IWriteRepository<Meal> _mealWriteRepository = mealWriteRepository;
    private readonly IUserProvider _userProvider = userProvider;
    private readonly IValidator<AddMealRequest> _requestValidator = requestValidator;

    public async Task<AddReponse<Meal>> Execute(AddMealRequest request)
    {
        var validationResult = await _requestValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return CreateErrorResponse(validationResult);

        Meal meal = CreateMeal(request);
        await _mealWriteRepository.InsertOneAsync(meal);

        return new AddSuccessResponse<Meal> { Entity = meal };
    }

    private Meal CreateMeal(AddMealRequest request)
    {
        return new Meal
        {
            Date = request.Date,
            FoodItems = request.FoodItems,
            OwnerId = _userProvider.UserId,
        };
    }

    private static AddErrorResponse<Meal> CreateErrorResponse(FluentValidation.Results.ValidationResult validationResult)
    {
        var errorMessage = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
        return new AddErrorResponse<Meal> { ErrorMessage = errorMessage };
    }
}

