using Application.UseCases.Products.AddProduct;
using Application.UseCases.Products.AddProduct.Request;
using Application.UseCases.Products.DeleteProduct;
using Application.UseCases.Products.DeleteProduct.Request;
using Application.UseCases.Products.GetProducts;
using Application.UseCases.Products.GetProducts.Request;
using Application.UseCases.Products.UpdateProduct;
using Application.UseCases.Products.UpdateProduct.Request;
using Application.UseCases.Responses.Add;
using Application.UseCases.Responses.Delete;
using Application.UseCases.Responses.Get;
using Application.UseCases.Responses.Update;
using Domain.Models;
using PeakForm.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace PeakForm.Api.Controllers;

[Authorize]
[ApiController]
[EnableRateLimiting("fixed")]
[Route("[Controller]")]
public class ProductsController(IGetProductsUseCase getProductsUseCase, IUpdateProductUseCase updateProductUseCase, IAddProductUseCase addProductUseCase, IDeleteProductUseCase deleteProductUseCase) : ControllerBase
{
    private readonly IGetProductsUseCase _getProductsUseCase = getProductsUseCase;
    private readonly IUpdateProductUseCase _updateProductUseCase = updateProductUseCase;
    private readonly IAddProductUseCase _addProductUseCase = addProductUseCase;
    private readonly IDeleteProductUseCase _deleteProductUseCase = deleteProductUseCase;

    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequest request)
    {
        var response = await _getProductsUseCase.Execute(request);

        if (response is GetSuccessReponse<Product> successResponse) return Ok(successResponse.Entity.Select(p => p.MapToDto()).ToList());

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] AddProductRequest request)
    {
        var response = await _addProductUseCase.Execute(request);

        if (response is AddSuccessResponse<Product> success)
            return Created("Created", success.Entity?.MapToDto());

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductsRequest request)
    {
        var response = await _updateProductUseCase.Execute(request);
        return response switch
        {
            UpdateSuccessResponse<Product> successResponse => Ok(successResponse.Entity?.MapToDto()),
            UpdateErrorResponse<Product> => BadRequest(),
            _ => BadRequest()
        };
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct([FromQuery] DeleteProductRequest request)
    {
        var response = await _deleteProductUseCase.Execute(request);
        return response switch
        {
            DeleteSuccessResponse<Product> => Ok(),
            DeleteErrorResponse<Product> => BadRequest(),
            _ => BadRequest()
        };
    }
}
