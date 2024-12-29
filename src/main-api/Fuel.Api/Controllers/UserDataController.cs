using Application.UseCases.Responses.Delete;
using Application.UseCases.Responses.Get;
using Application.UseCases.Responses.Update;
using Application.UseCases.UserData.DeleteUserData;
using Application.UseCases.UserData.DeleteUserData.Request;
using Application.UseCases.UserData.GetUserData;
using Application.UseCases.UserData.GetUserData.Request;
using Application.UseCases.UserData.UpdateUserData;
using Application.UseCases.UserData.UpdateUserData.Request;
using Domain.Models;
using Fuel.Api.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Fuel.Api.Controllers;

[Authorize]
[ApiController]
[Route("[Controller]")]
public class UserDataController : ControllerBase
{

    readonly IDeleteUserDataUseCase _deleteUserDataUseCase;
    readonly IGetUserDataUseCase _getUserDataUseCase;
    readonly IUpdateUserDataUseCase _updateUserDataUseCase;

    public UserDataController(IUpdateUserDataUseCase updateUserDataUseCase, IGetUserDataUseCase getUserDataUseCase, IDeleteUserDataUseCase deleteUserDataUseCase)
    {
        _updateUserDataUseCase = updateUserDataUseCase;
        _getUserDataUseCase = getUserDataUseCase;
        _deleteUserDataUseCase = deleteUserDataUseCase;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserData([FromQuery] GetUserDataReuqest request)
    {
        var response = await _getUserDataUseCase.Execute(request);

        if (response is GetSuccessReponse<UserData> successResponse) return Ok(successResponse.Entity.Select(u => u.MapToDto()));

        return BadRequest();
    }
    [HttpPut]
    public async Task<IActionResult> UpdateUserData([FromBody] UpdateUserDataRequest request)
    {
        var response = await _updateUserDataUseCase.Execute(request);
        return response switch
        {
            UpdateSuccessResponse<UserData> successResponse => Ok(successResponse.Entity?.MapToDto()),
            UpdateErrorResponse<UserData> errorResponse => BadRequest(),
            _ => BadRequest()
        };
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteUserData([FromQuery] DeleteuserDataRequest request)
    {
        var response = await _deleteUserDataUseCase.Execute(request);
        return response switch
        {
            DeleteSuccessResponse<UserData> successResponse => Ok(),
            DeleteErrorResponse<UserData> errorResponse => BadRequest(errorResponse.ErrorMessage),
            _ => BadRequest()
        };
    }

}

