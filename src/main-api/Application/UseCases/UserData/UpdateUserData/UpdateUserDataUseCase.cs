using Application.UseCases.Responses.Update;
using Application.UseCases.UserData.UpdateUserData.Request;


namespace Application.UseCases.UserData.UpdateUserData;
public class UpdateUserDataUseCase : IUpdateUserDataUseCase
{
    public Task<UpdateResponse<Domain.Models.UserData>> Execute(UpdateUserDataRequest request)
    {
        throw new NotImplementedException();
    }
}
