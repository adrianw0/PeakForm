using Core.Interfaces.Repositories;
using Core.Models;
using Fuel.Api.DTOs;
using Fuel.Api.Mappers;
using Fuel.Api.Params;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fuel.Api.Controllers;

[Authorize]
[ApiController]
[Route("Dishes")]
public class DishesController : ControllerBase
{

    private readonly IReadRepository<Dish> _dishReadRepository;
    private readonly IWriteRepository<Dish> _dishWriteRepository;
    public DishesController(IReadRepository<Dish> dishReadRepository, IWriteRepository<Dish> dishWriteRepository)
    {
        _dishReadRepository = dishReadRepository;
        _dishWriteRepository = dishWriteRepository;
    }



    [HttpGet("Dishes")]
    public async Task<IActionResult> GetDishes([FromQuery] PagingParams pagingParams, string searchParam = "")
    {
        var dishes = await _dishReadRepository.FindAsync(p => p.Name.Contains(searchParam), pagingParams.Page, pagingParams.PageSize); ;
        var dishesDto = dishes.Select(p => p.MapToDto()).ToList();
        return Ok(dishesDto);
    }

    [HttpPost("AddDish")]
    public async Task<IActionResult> AddDisha([FromBody] DishDto dishDto)
    {
        try
        {
            var dish = dishDto.MapToDomain();

            await _dishWriteRepository.InsertOneAsync(dish);
            return Created(string.Empty, dish.MapToDto());

        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
    }

    [HttpPut("updateDish")]
    public async Task<IActionResult> UpdateDish([FromBody] DishDto dishDto)
    {
        bool updated;
        try
        {
            var dish = dishDto.MapToDomain();
            updated = await _dishWriteRepository.UpdateAsync(dish);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
        return updated ? Ok() : NoContent();
    }

    [HttpDelete("DeleteDish")]
    public async Task<IActionResult> DeleteDish(Guid id)
    {
        bool deleted;
        try
        {
            deleted = await _dishWriteRepository.DeleteByIdAsync(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex?.InnerException?.Message);
        }
        return deleted ? Ok() : NotFound();

    }
}
