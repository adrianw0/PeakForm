using Core.Interfaces;
using Core.Models;
using Fuel.Api.Controllers.Params;
using Fuel.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Fuel.Api.Controllers;

[ApiController]
[Route("Products")]
public class ProductsController : ControllerBase
{
    private readonly IReadRepository<Product> _productReadRepository;
    private readonly IWriteRepository<Product> _productWriteRepository;
    public ProductsController(IReadRepository<Product> productReadRepository, IWriteRepository<Product> productWriteRepository)
    {
        _productReadRepository = productReadRepository;
        _productWriteRepository = productWriteRepository;
    }

    

    [HttpGet("Products")]
    public async Task<IActionResult> GetProducts([FromQuery] PagingParams pagingParams, string searchParam = "")
    {
        var products = await _productReadRepository.FindAsync(p=>p.Name.Contains(searchParam) || p.Ean.Contains(searchParam), pagingParams.Page, pagingParams.PageSize);  ;
        var productsDto = products.Select(ProductDto.FromProduct).ToList();
        return Ok(productsDto);
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
    {
        try 
        {
            var product = ProductDto.ToProduct(productDto);

            await _productWriteRepository.InsertOneAsync(product);
            return Created(string.Empty, ProductDto.FromProduct(product) );

        } catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
    }

    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
    {
        try
        {
            var product = ProductDto.ToProduct(productDto);
            await _productWriteRepository.UpdateAsync(product);

            return Ok();

        }catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
    }

    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    {
        try
        {
            await _productWriteRepository.DeleteByIdAsync(id);
            return Ok();
        }catch (Exception ex)
        {
            return BadRequest(ex?.InnerException?.Message);
        }
    }
}
