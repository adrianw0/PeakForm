using Application.UseCases.Products.AddProduct;
using Application.UseCases.Products.UpdateProduct.Request;
using Application.UseCases.Products.UpdateProduct.Response;
using Core.Common;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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


    public async Task<UpdateProductResponse> Execute(UpdateProductsRequest request)
    {
        bool updated;

        var product = await _productReadRepository.FindByIdAsync(request.Id);

        if (product is null || !product.OwnerId.Equals(_userProvider.UserId))
            return new UpdateProductErrorResponse { Code = ErrorCodes.UpdateFailed };

        var updateProduct = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Ean = request.Ean,
            Description = request.Description,
            Nutrients = request.Nutrients,
            OwnerId = _userProvider.UserId
        };

        updated = await _productWriteRepository.UpdateAsync(updateProduct);

        if (updated)
            return new UpdateProductSuccessResponse { Product = updateProduct };

        return new UpdateProductErrorResponse { Message = ErrorCodes.UpdateFailed };
       
    }
}
