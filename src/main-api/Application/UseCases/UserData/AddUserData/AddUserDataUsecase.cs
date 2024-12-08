using Application.UseCases.Responses.Add;
using Application.UseCases.UserData.AddUserData.Request;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;

namespace Application.UseCases.UserData.AddUserData;
public class AddUserDataUsecase : IAddUserDataUseCase
{
    readonly IReadRepository<Domain.Models.UserData> _readRepository;
    readonly IWriteRepository<Domain.Models.UserData> _writeRepository;
    readonly IUserProvider _userProvider;
    public AddUserDataUsecase(IWriteRepository<Domain.Models.UserData> writeRepository, IReadRepository<Domain.Models.UserData> readRepository, IUserProvider userProvider)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _userProvider = userProvider;
    }

    ///[obsolete]: no business reason to call that. To delete propably.
    public async Task<AddReponse<Domain.Models.UserData>> Execute(AddUserDataRequest request)
    {
        throw new NotImplementedException();
    }
}
