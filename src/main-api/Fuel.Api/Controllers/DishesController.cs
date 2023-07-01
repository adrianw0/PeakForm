using Application.UseCases;
using Application.UseCases.Dishes.AddDish;
using Application.UseCases.Dishes.AddDish.Request;
using Application.UseCases.Dishes.AddDish.Response;
using Application.UseCases.Dishes.DeleteDish;
using Application.UseCases.Dishes.DeleteDish.Request;
using Application.UseCases.Dishes.DeleteDish.Response;
using Application.UseCases.Dishes.GetDishes;
using Application.UseCases.Dishes.GetDishes.Request;
using Application.UseCases.Dishes.GetDishes.Response;
using Application.UseCases.Dishes.UpdateDish;
using Application.UseCases.Dishes.UpdateDish.Request;
using Application.UseCases.Dishes.UpdateDish.Response;

using Fuel.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fuel.Api.Controllers;

[Authorize]
[ApiController]
[Route("[Controller]")]
public class DishesController : ControllerBase
{
    IGetDishesUseCase _getDishesUseCase;
    IUpdateDishUseCase _updateDishUseCase;
    IAddDishUseCase _addDishUseCase;
    IDeleteDishUseCase _deleteDishUseCase;

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

        if(result is GetDishesSuccessResponse success) return Ok(success.Dishes.Select(x=>x.MapToDto()).ToList());

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> AddDish(AddDishRequest request)
    {
        var result = await _addDishUseCase.Execute(request);

        if (result is AddDishSuccessReposnse success) 
            return Created("", success.Dish?.MapToDto());

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateDish(UpdateDishRequest request)
    {
        var response = await _updateDishUseCase.Execute(request);

        return response switch
        {
            UpdateDishSuccessResponse successResponse => Ok(successResponse.Dish.MapToDto()),
            UpdateDishErrorResponse errorResponse => BadRequest(errorResponse.Message),
            _ => BadRequest()
        };
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteDish(DeleteDishRequest request)
    {
        var response = await _deleteDishUseCase.Execute(request);

        return response switch
        {
            DeleteDishSuccessReposnse => Ok(),
            DeleteDishErrorResponse errorResponse => BadRequest(errorResponse.Message),
            _ => BadRequest()
        };
    }
}
