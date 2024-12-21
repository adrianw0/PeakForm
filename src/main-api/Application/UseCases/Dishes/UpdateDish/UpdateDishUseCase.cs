using Application.UseCases.Dishes.UpdateDish.Request;
using Application.UseCases.Responses.Update;
using Core.Common;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;

namespace Application.UseCases.Dishes.UpdateDish;
public class UpdateDishUseCase : IUpdateDishUseCase
{
    private readonly IReadRepository<Dish> _dishReadRepository;
    private readonly IWriteRepository<Dish> _dishWriteRepository;
    private readonly IUserProvider _userProvider;
    public UpdateDishUseCase(IReadRepository<Dish> dishReadRepository, IWriteRepository<Dish> dishWriteRepository, IUserProvider userProvider)
    {
        _dishReadRepository = dishReadRepository;
        _dishWriteRepository = dishWriteRepository;
        _userProvider = userProvider;
    }



    public async Task<UpdateResponse<Dish>> Execute(UpdateDishRequest request)
    {

        var dish = await _dishReadRepository.FindByIdAsync(request.Id);
        if (!dish.OwnerId.Equals(_userProvider.UserId))
            return new UpdateErrorResponse<Dish> { Code = ErrorCodes.NotFound };

        var updateDish = new Dish
        {
            Name = request.Name,
            Description = request.Description,
            Ingredients = request.Ingredients,
            Id = request.Id,
            OwnerId = _userProvider.UserId
        };

        var updated = await _dishWriteRepository.UpdateAsync(updateDish);

        if (updated)
            return new UpdateSuccessResponse<Dish> { Entity = updateDish };

        return new UpdateErrorResponse<Dish> { Code = ErrorCodes.UpdateFailed };

    }
}
