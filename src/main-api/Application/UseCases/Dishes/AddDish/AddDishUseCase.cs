using Application.UseCases.Dishes.AddDish.Request;
using Application.UseCases.Dishes.AddDish.Response;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;


namespace Application.UseCases.Dishes.AddDish;
public class AddDishUseCase : IAddDishUseCase
{
    private readonly IWriteRepository<Dish> _dishWriteRepository;
    private readonly IUserProvider _userProvider;

    public AddDishUseCase(IWriteRepository<Dish> dishWriteRepository, IUserProvider userProvider)
    {
        _dishWriteRepository = dishWriteRepository;
        _userProvider = userProvider;
    }

    public async Task<AddDishResponse> Execute(AddDishRequest request)
    {
        var dish = new Dish
        {
            Name = request.Name,
            Description = request.Description,
            Ingredients = request.Ingredients,
            OwnerId = _userProvider.UserId
        };

        await _dishWriteRepository.InsertOneAsync(dish);

        return new AddDishSuccessResponse { Dish = dish };

    }
}
