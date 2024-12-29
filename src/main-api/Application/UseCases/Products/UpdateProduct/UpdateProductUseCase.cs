using Application.UseCases.Products.UpdateProduct.Request;
using Application.UseCases.Responses.Update;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;

namespace Application.UseCases.Products.UpdateProduct;
public class UpdateProductUseCase : IUpdateProductUseCase
{
    private readonly IWriteRepository<Product> _productWriteRepository;
    private readonly IReadRepository<Product> _productReadRepository;
    private readonly IUserProvider _userProvider;
    public UpdateProductUseCase(IWriteRepository<Product> productWriteRepository, IReadRepository<Product> productReadRepository, IUserProvider userProvider)
    {
        _productWriteRepository = productWriteRepository;
        _productReadRepository = productReadRepository;
        _userProvider = userProvider;
    }


    public async Task<UpdateResponse<Product>> Execute(UpdateProductsRequest request)
    {
        var product = await _productReadRepository.FindByIdAsync(request.Id);

        if (!product.OwnerId.Equals(_userProvider.UserId))
            return new UpdateErrorResponse<Product> { ErrorMessage = "Update failed" };

        var updateProduct = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Ean = request.Ean,
            Description = request.Description,
            NutrientsPer1G = request.Nutrients,
            OwnerId = _userProvider.UserId
        };

        var updated = await _productWriteRepository.UpdateAsync(updateProduct);

        if (updated)
            return new UpdateSuccessResponse<Product> { Entity = updateProduct };

        return new UpdateErrorResponse<Product> { ErrorMessage = "Update failed."};

    }
}
