using Core.Interfaces;
using Core.Models;
using Fuel.Api.DTOs;
using Fuel.Api.Mappers;
using Fuel.Api.Params;
using Microsoft.AspNetCore.Mvc;

namespace Fuel.Api.Controllers;

[ApiController]
[Route("[MealHistory]")]
public class MealHistoryController : ControllerBase
{
    private readonly IReadRepository<Meal> _mealReadRepository;
    private readonly IWriteRepository<Meal> _mealWriteRepository;
    public MealHistoryController(IReadRepository<Meal> mealReadRepository, IWriteRepository<Meal> mealWriteRepository)
    {
        _mealReadRepository = mealReadRepository;
        _mealWriteRepository = mealWriteRepository;
    }



    [HttpGet("GetMeals")]
    public async Task<IActionResult> GetMeals([FromQuery] PagingParams pagingParams, DateTime DateFrom, DateTime DateTo)
    {
        var meals = await _mealReadRepository.FindAsync(m=> DateFrom <= m.Date && m.Date >= DateTo, pagingParams.Page, pagingParams.PageSize); ;
        var productsDto = meals.Select(m => m.MapToDto()).ToList();
        return Ok(productsDto);
    }

    [HttpPost("AddMeal")]
    public async Task<IActionResult> AddMeal([FromBody] MealDto mealDto)
    {
        try
        {
            var meal = mealDto.MapToDomain();

            await _mealWriteRepository.InsertOneAsync(meal);
            return Created(string.Empty, meal.MapToDto());

        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
    }

    [HttpPut("UpdateMeal")]
    public async Task<IActionResult> UpdateMeal([FromBody] MealDto mealDto)
    {
        bool updated;
        try
        {
            var meal = mealDto.MapToDomain();
            updated = await _mealWriteRepository.UpdateAsync(meal);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.InnerException?.Message);
        }
        return updated ? Ok() : NoContent();
    }

    [HttpDelete("DeleteMeal")]
    public async Task<IActionResult> DeleteMeal(Guid id)
    {
        bool deleted;
        try
        {
            deleted = await _mealWriteRepository.DeleteByIdAsync(id);
        }
        catch (Exception ex)
        {
            return BadRequest(ex?.InnerException?.Message);
        }
        return deleted ? Ok() : NotFound();
    }
}
