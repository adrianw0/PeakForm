using Application.UseCases.Dishes.DeleteDish.Request;
using Application.UseCases.Dishes.DeleteDish.Response;
using Application.UseCases.Products.DeleteProduct.Response;
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

    public async Task<DeleteDishReposnse> Execute(DeleteDishRequest request)
    {
        var dish = await _dishReadRepository.FindByIdAsync(request.Id);
        
        if(dish == null || !dish.OwnerId.Equals(_userProvider.UserId))
            return new DeleteDishErrorResponse { Code = ErrorCodes.NotFound };

        var deleted = await _dishWriteRepository.DeleteByIdAsync(request.Id);

        if (deleted) return new DeleteDishSuccessReposnse();

        return new DeleteDishErrorResponse { Code = ErrorCodes.DeleteFailed };
    }
}
