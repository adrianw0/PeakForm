using Application.UseCases.MealHistory.AddMeal;
using Application.UseCases.MealHistory.AddMeal.Request;
using Application.UseCases.MealHistory.AddMeal.Response;
using Application.UseCases.MealHistory.DeleteMeal;
using Application.UseCases.MealHistory.DeleteMeal.Request;
using Application.UseCases.MealHistory.DeleteMeal.Response;
using Application.UseCases.MealHistory.GetMeals;
using Application.UseCases.MealHistory.GetMeals.Request;
using Application.UseCases.MealHistory.GetMeals.Response;
using Application.UseCases.MealHistory.UpdateMeal;
using Application.UseCases.MealHistory.UpdateMeal.Request;
using Application.UseCases.MealHistory.UpdateMeal.Response;
using Core.Common;
using Fuel.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fuel.Api.Controllers;

[Authorize]
[ApiController]
[Route("[Controller]")]
public class MealHistoryController : ControllerBase
{
    private readonly IAddMealUseCase _addMealUseCase;
    private readonly IDeleteMealUseCase _deleteMealUseCase;
    private readonly IGetMealsUseCase _getMealsUseCase;
    private readonly IUpdateMealUseCase _updateMealUseCase;

    public MealHistoryController(IAddMealUseCase addMealUseCase, IDeleteMealUseCase deleteMealUseCase, IGetMealsUseCase getMealsUseCase, IUpdateMealUseCase updateMealUseCase)
    {
        _addMealUseCase = addMealUseCase;
        _deleteMealUseCase = deleteMealUseCase;
        _getMealsUseCase = getMealsUseCase;
        _updateMealUseCase = updateMealUseCase;
    }

    [HttpGet()]
    public async Task<IActionResult> GetMeals([FromQuery] GetMealsRequest request)
    {
        var result = await _getMealsUseCase.Execute(request);

        if (result is GetMealsSuccessResponse response) return Ok(response.Meals.Select(x => x.MapToDto()).ToList());

        return BadRequest();
    }

    [HttpPost]
    public async Task<IActionResult> AddMeal(AddMealRequest request)
    {
        var result = await _addMealUseCase.Execute(request);
        if (result is AddMealSuccessReposnse success) return Ok(success.Meal.MapToDto());

        return BadRequest();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMeal(UpdateMealRequest request)
    {
        var result = await _updateMealUseCase.Execute(request);

        return result switch
        {
            UpdateMealSuccessReposnse success => Ok(success.Meal.MapToDto()),
            UpdateMealErrorReposnse error => BadRequest(error),
            _ => BadRequest(ErrorCodes.SomethingWentWrong)
        };
        


    }

    [HttpDelete]
    public async Task<IActionResult> DeleteMeal(DeleteMealRequest request)
    {
        var result = await _deleteMealUseCase.Execute(request);

        return result switch
        {
            DeleteMealSuccessReposnse success => Ok(success.Message),
            DeleteMealErrorReposnse error => BadRequest(error.Message),
            _ => BadRequest()
        };
    }
}
