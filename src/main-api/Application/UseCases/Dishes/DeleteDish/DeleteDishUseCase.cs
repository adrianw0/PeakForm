using Application.UseCases.Dishes.DeleteDish.Request;
using Application.UseCases.Dishes.DeleteDish.Response;
using Application.UseCases.Products.DeleteProduct.Response;
using Core.Common;
using Core.Interfaces.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dishes.DeleteDish;
public class DeleteDishUseCase : IDeleteDishUseCase
{
    private readonly IWriteRepository<Dish> _dishWriteRepository;
    public DeleteDishUseCase(IWriteRepository<Dish> dishWriteRepository)
    {
        _dishWriteRepository = dishWriteRepository;
    }

    public async Task<DeleteDishReposnse> Execute(DeleteDishRequest request)
    {
        bool deleted;

        deleted = await _dishWriteRepository.DeleteByIdAsync(request.Id);

        if (deleted) return new DeleteDishSuccessReposnse();

        return new DeleteDishErrorResponse { Message = ErrorMessages.DeleteFailed };
    }
}
