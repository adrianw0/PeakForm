using Application.UseCases.Dishes.GetDishes.Request;
using Application.UseCases.Responses.Get;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.UseCases.Dishes.GetDishes;
public class GetDishesUseCase : IGetDishesUseCase
{
    private readonly IReadRepository<Dish> _dishReadRepository;
    private readonly IUserProvider _userProvider;
    public GetDishesUseCase(IReadRepository<Dish> dishReadRepository, IUserProvider userProvider)
    {
        _dishReadRepository = dishReadRepository;
        _userProvider = userProvider;
    }



    public async Task<GetReponse<Dish>> Execute(GetDishesRequest request)
    {

        Expression<Func<Dish, bool>> predicate = d =>
        d.Name.Contains(request.SearchParams) && (d.OwnerId.Equals(_userProvider.UserId) || d.IsGloballyVisible);

        var dishes = await _dishReadRepository
            .FindAsync(predicate, request.PagingParams.Page, request.PagingParams.PageSize);

        return new GetSuccessReponse<Dish> { Entity = dishes.ToList() };


    }
}
