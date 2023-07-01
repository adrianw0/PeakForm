using Application.UseCases.Products.AddProduct.Request;
using Application.UseCases.Products.AddProduct.Response;
using Core.Interfaces.Repositories;
using Domain.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Products.AddProduct;
public class AddProductUseCase : IAddProductUseCase
{
    private readonly IWriteRepository<Product> _productWriteRepository;

    public AddProductUseCase(IWriteRepository<Product> productWriteRepository)
    {

        _productWriteRepository = productWriteRepository;
    }

    public async Task<AddProductResposnse> Execute(AddProductRequest request)
    {
    
            var product = new Product
            {
                Name = request.Name,
                Ean = request.Ean,
                Description = request.Description,
                Nutrients = request.Nutrients
            };

            await _productWriteRepository.InsertOneAsync(product);

            return new AddProductSuccessResponse { Product = product };
    }
}
