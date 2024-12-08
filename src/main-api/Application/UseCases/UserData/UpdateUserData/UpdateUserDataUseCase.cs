using Application.UseCases.Responses.Update;
using Application.UseCases.UserData.UpdateUserData.Request;
using Core.Common;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using Domain.Models.Enums;
using FluentValidation;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq.Expressions;

namespace Application.UseCases.UserData.UpdateUserData;
public class UpdateUserDataUseCase : IUpdateUserDataUseCase
{
    readonly IReadRepository<Domain.Models.UserData> _readRepository;
    readonly IWriteRepository<Domain.Models.UserData> _writeRepository;
    readonly IUserProvider _userProvider;
    readonly IValidator<UpdateUserDataRequest> _validator;

    public UpdateUserDataUseCase(IWriteRepository<Domain.Models.UserData> writeRepository, IReadRepository<Domain.Models.UserData> readRepository, IUserProvider userProvider, IValidator<UpdateUserDataRequest> validator)
    {
        _writeRepository = writeRepository;
        _readRepository = readRepository;
        _userProvider = userProvider;
        _validator = validator;
    }

    public async Task<UpdateResponse<Domain.Models.UserData>> Execute(UpdateUserDataRequest request)
    {
        var validationResult =await _validator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            return new UpdateErrorResponse<Domain.Models.UserData> {Code=ErrorCodes.UpdateFailed, Message = string.Join(';', validationResult.Errors) };
        }
        
        var userGuid = new Guid(_userProvider.UserId);

        var userData = await _readRepository.FindByIdAsync(userGuid);

        if (userData is null)
        {
            userData = CreateNewUser(request);
            await _writeRepository.InsertOneAsync(userData);
            return new UpdateSuccessResponse<Domain.Models.UserData> { Entity = userData };
        }
        else
        {
            MapRequestToUserData(request, userData);
            await _writeRepository.UpdateAsync(userData);
            return new UpdateSuccessResponse<Domain.Models.UserData> { Entity = userData};
        }

    }

    private void MapRequestToUserData(UpdateUserDataRequest request, Domain.Models.UserData userData)
    {
        userData.Weight = request.Weight ?? userData.Weight;
        userData.Height = request.Height ?? userData.Height;
        userData.Age = request.Age ?? userData.Age;
        userData.Gender = request.Gender;
        userData.BodyFatPercentage = request.BodyFatPercentage ?? userData.BodyFatPercentage;
        userData.MuscleMassPercentage = request.MuscleMassPercentage ?? userData.MuscleMassPercentage;
        userData.ActivityLevel = request.ActivityLevel;
        userData.WaistCircumference = request.WaistCircumference ?? userData.WaistCircumference;
        userData.HipCircumference = request.HipCircumference ?? userData.HipCircumference;
        userData.NeckCircumference = request.NeckCircumference ?? userData.NeckCircumference;
        userData.GoalBodyFatPercentage = request.GoalBodyFatPercentage ?? userData.GoalBodyFatPercentage;
        userData.GoalWeight = request.GoalWeight ?? userData.GoalWeight;
        userData.GoalMuscleMassPercentage = request.GoalMuscleMassPercentage ?? userData.GoalMuscleMassPercentage;
    }

    private Domain.Models.UserData CreateNewUser(UpdateUserDataRequest request)
    {
        return new Domain.Models.UserData { 
            Id = new Guid(_userProvider.UserId),
            Weight = request.Weight ?? default,
            Height = request.Height ?? default,
            Age = request.Age ?? default,
            Gender = request.Gender,
            BodyFatPercentage = request.BodyFatPercentage ?? default,
            MuscleMassPercentage = request.MuscleMassPercentage ?? default,
            ActivityLevel = request.ActivityLevel,
            WaistCircumference = request.WaistCircumference ?? default,
            HipCircumference = request.HipCircumference ?? default,
            NeckCircumference = request.NeckCircumference ?? default,
            GoalBodyFatPercentage = request.GoalBodyFatPercentage ?? default,
            GoalWeight = request.GoalWeight ?? default,
            GoalMuscleMassPercentage = request.GoalMuscleMassPercentage ?? default,
        };
    }







}
