using Application.UseCases.Responses.Delete;
using Application.UseCases.UserData.DeleteUserData.Request;

namespace Application.UseCases.UserData.DeleteUserData;
public interface IDeleteUserDataUseCase : IUseCase<DeleteuserDataRequest, DeleteResponse<Domain.Models.UserData>>
{
}
