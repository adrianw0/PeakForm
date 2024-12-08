using Application.UseCases.Responses.Update;
using Application.UseCases.UserData.UpdateUserData.Request;

namespace Application.UseCases.UserData.UpdateUserData;
public interface IUpdateUserDataUseCase : IUseCase<UpdateUserDataRequest, UpdateResponse<Domain.Models.UserData>>
{
}
