using Application.UseCases.Responses.Get;
using Application.UseCases.UserData.GetUserData.Request;

namespace Application.UseCases.UserData.GetUserData;
public interface IGetUserDataUseCase : IUseCase<GetUserDataReuqest, GetReponse<Domain.Models.UserData>>
{
}
