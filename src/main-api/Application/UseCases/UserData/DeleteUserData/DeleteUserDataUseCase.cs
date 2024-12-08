using Application.UseCases.Responses.Delete;
using Application.UseCases.Responses.Update;
using Application.UseCases.UserData.DeleteUserData.Request;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;

namespace Application.UseCases.UserData.DeleteUserData;
public class DeleteUserDataUseCase : IDeleteUserDataUseCase
{
    IWriteRepository<Domain.Models.UserData> _writeRepository;
    IUserProvider _userProvider;
    public DeleteUserDataUseCase(IWriteRepository<Domain.Models.UserData> writeRepository, IUserProvider userProvider)
    {
        _writeRepository = writeRepository;
        _userProvider = userProvider;
    }
    public async Task<DeleteResponse<Domain.Models.UserData>> Execute(DeleteuserDataRequest request)
    {
        var userId = _userProvider.UserId;

        bool result = await _writeRepository.DeleteByIdAsync(new Guid(userId));

        if (result)
        {
            return new DeleteSuccessResponse<Domain.Models.UserData>();
        }
        else
        {
            return new DeleteErrorResponse<Domain.Models.UserData>();
        }

    }
}
