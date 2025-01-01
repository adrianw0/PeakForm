using Application.UseCases.Dishes.AddDish.Request;
using Application.UseCases.Responses.Add;
using Application.Validators.Requests;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using FluentValidation;


namespace Application.UseCases.Dishes.AddDish;
public class AddDishUseCase(IWriteRepository<Dish> dishWriteRepository, IUserProvider userProvider, IValidator<AddDishRequest> validator) : IAddDishUseCase
{
    private readonly IWriteRepository<Dish> _dishWriteRepository = dishWriteRepository;
    private readonly IUserProvider _userProvider = userProvider;
    private readonly IValidator<AddDishRequest> _requestValidator = validator;

    public async Task<AddReponse<Dish>> Execute(AddDishRequest request)
    {
        var validationResult = await _requestValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
            return CreateErrorResponse(validationResult);

        Dish dish = CreateDish(request);

        await _dishWriteRepository.InsertOneAsync(dish);

        return new AddSuccessResponse<Dish> { Entity = dish };

    }

    private Dish CreateDish(AddDishRequest request)
    {
        return new Dish
        {
            Name = request.Name,
            Description = request.Description,
            Ingredients = request.Ingredients,
            OwnerId = _userProvider.UserId
        };
    }
    private static AddErrorResponse<Dish> CreateErrorResponse(FluentValidation.Results.ValidationResult validationResult)
    {
        var errorMessage = string.Join("; ", validationResult.Errors.Select(e => e.ErrorMessage));
        return new AddErrorResponse<Dish> { ErrorMessage = errorMessage };
    }
}
