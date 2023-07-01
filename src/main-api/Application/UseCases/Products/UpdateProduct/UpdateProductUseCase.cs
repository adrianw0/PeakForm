using Application.UseCases.Products.AddProduct;
using Application.UseCases.Products.UpdateProduct.Request;
using Application.UseCases.Products.UpdateProduct.Response;
using Core.Common;
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
    public UpdateProductUseCase(IWriteRepository<Product> productWriteRepository)
    {
        _productWriteRepository = productWriteRepository;
    }


    public async Task<UpdateProductResponse> Execute(UpdateProductsRequest request)
    {
        bool updated;

        var product = new Product
        {
            Id = request.Id,
            Name = request.Name,
            Ean = request.Ean,
            Description = request.Description,
            Nutrients = request.Nutrients
        };

        updated = await _productWriteRepository.UpdateAsync(product);

        if (updated)
            return new UpdateProductSuccessResponse { Product = product };

        return new UpdateProductErrorResponse { Message = ErrorCodes.UpdateFailed };
       
    }
}
