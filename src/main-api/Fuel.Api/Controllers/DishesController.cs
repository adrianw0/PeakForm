using Application.UseCases.Dishes.AddDish;
using Application.UseCases.Dishes.AddDish.Request;
using Application.UseCases.Dishes.DeleteDish;
using Application.UseCases.Dishes.DeleteDish.Request;
using Application.UseCases.Dishes.GetDishes;
using Application.UseCases.Dishes.GetDishes.Request;
using Application.UseCases.Dishes.UpdateDish;
using Application.UseCases.Dishes.UpdateDish.Request;
using Application.UseCases.Responses.Add;
using Application.UseCases.Responses.Delete;
using Application.UseCases.Responses.Get;
using Application.UseCases.Responses.Update;
using Domain.Models;
using Fuel.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Fuel.Api.Controllers;

[Authorize]
[ApiController]
[EnableRateLimiting("fixed")]
[Route("[Controller]")]
public class DishesController : ControllerBase
{
    readonly IGetDishesUseCase _getDishesUseCase;
    readonly IUpdateDishUseCase _updateDishUseCase;
    readonly IAddDishUseCase _addDishUseCase;
    readonly IDeleteDishUseCase _deleteDishUseCase;

    public DishesController(IGetDishesUseCase getDishesUseCase, IUpdateDishUseCase updateDishesUseCase, IAddDishUseCase addDishUseCase, IDeleteDishUseCase deleteDishUseCase)
    {
        _getDishesUseCase = getDishesUseCase;
        _updateDishUseCase = updateDishesUseCase;
        _addDishUseCase = addDishUseCase;
        _deleteDishUseCase = deleteDishUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetDishes([FromQuery] GetDishesRequest request)
    {
        var result = await _getDishesUseCase.Execute(request);

        if (result is GetSuccessReponse<Dish> success) return Ok(success.Entity.Select(x => x.MapToDto()).ToList());

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> AddDish([FromQuery] AddDishRequest request)
    {
        var result = await _addDishUseCase.Execute(request);

        if (result is AddSuccessResponse<Dish> success)
            return Created("", success.Entity?.MapToDto());

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDish([FromQuery] UpdateDishRequest request)
    {
        var response = await _updateDishUseCase.Execute(request);

        return response switch
        {
            UpdateSuccessResponse<Dish> successResponse => Ok(successResponse.Entity?.MapToDto()),
            UpdateErrorResponse<Dish> errorResponse => BadRequest(errorResponse.ErrorMessage),
            _ => BadRequest()
        };
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDish([FromQuery] DeleteDishRequest request)
    {
        var response = await _deleteDishUseCase.Execute(request);

        return response switch
        {
            DeleteSuccessResponse<Dish> => Ok(),
            DeleteErrorResponse<Dish> errorResponse => BadRequest(),
            _ => BadRequest()
        };
    }
}
