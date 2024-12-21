using Application.UseCases.Dishes.DeleteDish.Request;
using Application.UseCases.Responses.Delete;
using Core.Common;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;


namespace Application.UseCases.Dishes.DeleteDish;
public class DeleteDishUseCase : IDeleteDishUseCase
{
    private readonly IWriteRepository<Dish> _dishWriteRepository;
    private readonly IReadRepository<Dish> _dishReadRepository;
    private readonly IUserProvider _userProvider;
    public DeleteDishUseCase(IWriteRepository<Dish> dishWriteRepository, IReadRepository<Dish> dishReadRepository, IUserProvider userProvider)
    {
        _dishWriteRepository = dishWriteRepository;
        _dishReadRepository = dishReadRepository;
        _userProvider = userProvider;
    }

    public async Task<DeleteResponse<Dish>> Execute(DeleteDishRequest request)
    {
        var dish = await _dishReadRepository.FindByIdAsync(request.Id);

        if (!dish.OwnerId.Equals(_userProvider.UserId))
            return new DeleteErrorResponse<Dish> { Code = ErrorCodes.NotFound };

        var deleted = await _dishWriteRepository.DeleteByIdAsync(request.Id);

        if (deleted) return new DeleteSuccessResponse<Dish>();

        return new DeleteErrorResponse<Dish> { Code = ErrorCodes.DeleteFailed };
    }
}
