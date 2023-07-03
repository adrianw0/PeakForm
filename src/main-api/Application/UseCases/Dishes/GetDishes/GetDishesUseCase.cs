using Application.UseCases.Dishes.GetDishes.Request;
using Application.UseCases.Dishes.GetDishes.Response;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Core.Params;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dishes.GetDishes;
public class GetDishesUseCase : IGetDishesUseCase
{
    private readonly IReadRepository<Dish> _dishReadRepository;
    private readonly IWriteRepository<Dish> _dishWriteRepository;
    private readonly IUserProvider _userProvider;
    public GetDishesUseCase(IReadRepository<Dish> dishReadRepository, IWriteRepository<Dish> dishWriteRepository, IUserProvider userProvider)
    {
        _dishReadRepository = dishReadRepository;
        _dishWriteRepository = dishWriteRepository;
        _userProvider = userProvider;
    }



    public async Task<GetDishesReposnse> Execute(GetDishesRequest request)
    {

        Expression<Func<Dish, bool>> predicate = d =>
        d.Name.Contains(request.SearchParams) && (d.OwnerId.Equals(_userProvider.UserId) || d.IsGloballyVisible);
        
        var dishes = await _dishReadRepository
            .FindAsync(predicate, request.PagingParams.Page, request.PagingParams.PageSize);

        return new GetDishesSuccessResponse { Dishes = dishes.ToList() };


    }
}
