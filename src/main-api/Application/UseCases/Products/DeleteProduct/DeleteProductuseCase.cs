using Application.UseCases.Products.DeleteProduct.Request;
using Application.UseCases.Products.DeleteProduct.Response;
using Core.Common;
using Core.Interfaces.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.DeleteProduct;
public class DeleteProductuseCase : IDeleteProductuseCase
{
    private readonly IWriteRepository<Product> _productWriteRepository;
    public DeleteProductuseCase(IWriteRepository<Product> productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }

    public async Task<DeleteProductReposnse> Execute(DeleteProductRequest request)
    {
        bool deleted;

        deleted = await _productWriteRepository.DeleteByIdAsync(request.Id);

        if (deleted) return new DeleteProductSuccessReposnse();
        
        return new DeleteProductErrorResponse { Message = ErrorMessages.DeleteFailed };
    }
}
