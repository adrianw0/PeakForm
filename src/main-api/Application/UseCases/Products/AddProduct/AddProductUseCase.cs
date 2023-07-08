using Application.UseCases.Products.AddProduct.Request;
using Application.UseCases.Products.AddProduct.Response;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;


namespace Application.UseCases.Products.AddProduct;
public class AddProductUseCase : IAddProductUseCase
{
    private readonly IWriteRepository<Product> _productWriteRepository;
    private readonly IUserProvider _userProvider;

    public AddProductUseCase(IWriteRepository<Product> productWriteRepository, IUserProvider userProvider)
    {
        _userProvider = userProvider;
        _productWriteRepository = productWriteRepository;
    }

    public async Task<AddProductResponse> Execute(AddProductRequest request)
    {

        var product = new Product
        {
            Name = request.Name,
            Ean = request.Ean,
            Description = request.Description,
            Nutrients = request.Nutrients,
            OwnerId = _userProvider.UserId
            };

            await _productWriteRepository.InsertOneAsync(product);

            return new AddProductSuccessResponse { Product = product };
    }
}
