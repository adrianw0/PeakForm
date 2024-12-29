using Application.UseCases.Dishes.DeleteDish.Request;
using Application.UseCases.Responses.Delete;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;


namespace Application.UseCases.Dishes.DeleteDish;
public class DeleteDishUseCase(IWriteRepository<Dish> dishWriteRepository, IReadRepository<Dish> dishReadRepository, IUserProvider userProvider) : IDeleteDishUseCase
{
    private readonly IWriteRepository<Dish> _dishWriteRepository = dishWriteRepository;
    private readonly IReadRepository<Dish> _dishReadRepository = dishReadRepository;
    private readonly IUserProvider _userProvider = userProvider;

    public async Task<DeleteResponse<Dish>> Execute(DeleteDishRequest request)
    {
        var dish = await _dishReadRepository.FindByIdAsync(request.Id);

        if (!dish.OwnerId.Equals(_userProvider.UserId))
            return new DeleteErrorResponse<Dish> { ErrorMessage = "Dish not found." };

        var deleted = await _dishWriteRepository.DeleteByIdAsync(request.Id);

        if (deleted) return new DeleteSuccessResponse<Dish>();

        return new DeleteErrorResponse<Dish> { ErrorMessage = "Delete failed." };
    }
}
