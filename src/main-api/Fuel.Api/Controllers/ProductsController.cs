using Core.Models;
using Fuel.Api.DTOs;
using Fuel.Api.Params;
using Microsoft.AspNetCore.Mvc;
using Fuel.Api.Mappers;
using Core.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Fuel.Api.Controllers;

[Authorize]
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
        var productsDto = products.Select(p=>p.MapToDto()).ToList();
        return Ok(productsDto);
    }

    [HttpPost("AddProduct")]
    public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
    {
        try 
        {
            var product = productDto.MapToDomain();

            await _productWriteRepository.InsertOneAsync(product);
            return Created(string.Empty, product.MapToDto() );

        } catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
    }

    [HttpPut("UpdateProduct")]
    public async Task<IActionResult> UpdateProduct([FromBody] ProductDto productDto)
    {
        bool updated;
        try
        {
            var product = productDto.MapToDomain();
            updated = await _productWriteRepository.UpdateAsync(product);

        }catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
        return updated ? Ok() : NoContent();
    }

    [HttpDelete("DeleteProduct")]
    public async Task<IActionResult> DeleteProduct(Guid id)
    { 
        bool deleted;
        try
        {
            deleted = await _productWriteRepository.DeleteByIdAsync(id);
        }catch (Exception ex)
        {
            return BadRequest(ex?.InnerException?.Message);
        }
        return deleted ? Ok() : NotFound();
    }
}
