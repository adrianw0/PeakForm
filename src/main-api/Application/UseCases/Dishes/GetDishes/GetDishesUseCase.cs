using Application.UseCases.Dishes.GetDishes.Request;
using Application.UseCases.Dishes.GetDishes.Response;
using Core.Interfaces.Repositories;
using Core.Params;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dishes.GetDishes;
public class GetDishesUseCase : IGetDishesUseCase
{
    private readonly IReadRepository<Dish> _dishReadRepository;
    private readonly IWriteRepository<Dish> _dishWriteRepository;
    public GetDishesUseCase(IReadRepository<Dish> dishReadRepository, IWriteRepository<Dish> dishWriteRepository)
    {
        _dishReadRepository = dishReadRepository;
        _dishWriteRepository = dishWriteRepository;
    }



    public async Task<GetDishesReposnse> Execute(GetDishesRequest request)
    {
        var dishes = await _dishReadRepository
            .FindAsync(p => p.Name.Contains(request.SearchParams), request.PagingParams.Page, request.PagingParams.PageSize);

        return new GetDishesSuccessResponse { Dishes = dishes.ToList() };


    }
}
