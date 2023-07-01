using Application.UseCases.Products.DeleteProduct.Request;
using Application.UseCases.Products.DeleteProduct.Response;
using Core.Common;
using Core.Interfaces.Repositories;
using Domain.Models;

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
        
        return new DeleteProductErrorResponse { Message = ErrorCodes.DeleteFailed };
    }
}
