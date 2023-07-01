using Application.UseCases.Dishes.UpdateDish.Request;
using Application.UseCases.Dishes.UpdateDish.Response;
using Application.UseCases.Products.UpdateProduct.Response;
using Core.Common;
using Core.Interfaces.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dishes.UpdateDish;
public class UpdateDishUseCase : IUpdateDishUseCase
{
    private readonly IReadRepository<Dish> _dishReadRepository;
    private readonly IWriteRepository<Dish> _dishWriteRepository;
    public UpdateDishUseCase(IReadRepository<Dish> dishReadRepository, IWriteRepository<Dish> dishWriteRepository)
    {
        _dishReadRepository = dishReadRepository;
        _dishWriteRepository = dishWriteRepository;
    }



    public async Task<UpdateDishReposnse> Execute(UpdateDishRequest request)
    {
        bool updated;

        var dish = new Dish
        {
            Name = request.Name,
            Description = request.Description,
            Ingredients = request.Ingredients,
            Id = request.Id
        };

        updated = await _dishWriteRepository.UpdateAsync(dish);

        if (updated)
            return new UpdateDishSuccessResponse { Dish = dish };

        return new UpdateDishErrorResponse { Message = ErrorCodes.UpdateFailed };

    }
}
