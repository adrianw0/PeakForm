﻿using Application.UseCases.Dishes.UpdateDish.Request;
using Application.UseCases.Dishes.UpdateDish.Response;
using Application.UseCases.Products.UpdateProduct.Response;
using Core.Common;
using Core.Interfaces.Providers;
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
    private readonly IUserProvider _userProvider;
    public UpdateDishUseCase(IReadRepository<Dish> dishReadRepository, IWriteRepository<Dish> dishWriteRepository, IUserProvider userProvider)
    {
        _dishReadRepository = dishReadRepository;
        _dishWriteRepository = dishWriteRepository;
        _userProvider = userProvider;
    }



    public async Task<UpdateDishResponse> Execute(UpdateDishRequest request)
    {

        var dish = await _dishReadRepository.FindByIdAsync(request.Id);
        if (!dish.OwnerId.Equals(_userProvider.UserId))
            return new UpdateDishErrorResponse { Code = ErrorCodes.NotFound }; 

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
            return new UpdateDishSuccessResponse { Dish = updateDish };

        return new UpdateDishErrorResponse { Code = ErrorCodes.UpdateFailed };

    }
}
