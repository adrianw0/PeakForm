using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.UseCases.UserData.DeleteUserData;
using Application.UseCases.UserData.GetUserData;
using Application.UseCases.UserData.UpdateUserData;

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
}