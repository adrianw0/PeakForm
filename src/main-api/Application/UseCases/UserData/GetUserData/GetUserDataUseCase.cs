using Application.UseCases.Responses.Get;
using Application.UseCases.UserData.GetUserData.Request;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;

namespace Application.UseCases.UserData.GetUserData;
public class GetUserDataUseCase(IReadRepository<Domain.Models.UserData> readRepository, IUserProvider userProvider) : IGetUserDataUseCase
{
    readonly IReadRepository<Domain.Models.UserData> _readRepository = readRepository;
    readonly IUserProvider _userProvider = userProvider;

    public async Task<GetReponse<Domain.Models.UserData>> Execute(GetUserDataReuqest request)
    {
        var userId = new Guid(_userProvider.UserId);

        var userData = await _readRepository.FindByIdAsync(userId);

        userData ??= new Domain.Models.UserData { Id = new Guid(_userProvider.UserId) };

        return new GetSuccessReponse<Domain.Models.UserData> { Entity = [userData] };
    }
}
