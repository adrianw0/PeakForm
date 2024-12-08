using Application.UseCases.Responses.Add;
using Application.UseCases.UserData.AddUserData.Request;

namespace Application.UseCases.UserData.AddUserData;
public interface IAddUserDataUseCase : IUseCase<AddUserDataRequest, AddReponse<Domain.Models.UserData>>
{
}
