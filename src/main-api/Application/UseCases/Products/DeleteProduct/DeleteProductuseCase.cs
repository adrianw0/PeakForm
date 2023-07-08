using Application.UseCases.Products.DeleteProduct.Request;
using Application.UseCases.Products.DeleteProduct.Response;
using Core.Common;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;

namespace Application.UseCases.Products.DeleteProduct;
public class DeleteProductUseCase : IDeleteProductUseCase
{
    private readonly IWriteRepository<Product> _productWriteRepository;
    private readonly IReadRepository<Product> _productReadRepository;
    private readonly IUserProvider _userProvider;
    public DeleteProductUseCase(IWriteRepository<Product> productWriteRepository, IReadRepository<Product> readRepository, IUserProvider userProvider)
    {
        _productWriteRepository = productWriteRepository;
        _productReadRepository = readRepository;
        _userProvider = userProvider;
    }

    public async Task<DeleteProductResponse> Execute(DeleteProductRequest request)
    {

        var product = await _productReadRepository.FindByIdAsync(request.Id);
        if (product is null || !product.OwnerId.Equals(_userProvider.UserId))
            return new DeleteProductErrorResponse { Code = ErrorCodes.NotFound };

        var deleted = await _productWriteRepository.DeleteByIdAsync(request.Id);

        if (deleted) return new DeleteProductSuccessResponse();
        
        return new DeleteProductErrorResponse { Code = ErrorCodes.DeleteFailed };
    }
}
