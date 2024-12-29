using Application.UseCases.Dishes.AddDish.Request;
using Application.UseCases.Responses.Add;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;


namespace Application.UseCases.Dishes.AddDish;
public class AddDishUseCase(IWriteRepository<Dish> dishWriteRepository, IUserProvider userProvider) : IAddDishUseCase
{
    private readonly IWriteRepository<Dish> _dishWriteRepository = dishWriteRepository;
    private readonly IUserProvider _userProvider = userProvider;

    public async Task<AddReponse<Dish>> Execute(AddDishRequest request)
    {
        var dish = new Dish
        {
            Name = request.Name,
            Description = request.Description,
            Ingredients = request.Ingredients,
            OwnerId = _userProvider.UserId
        };

        await _dishWriteRepository.InsertOneAsync(dish);

        return new AddSuccessResponse<Dish> { Entity = dish };

    }
}
