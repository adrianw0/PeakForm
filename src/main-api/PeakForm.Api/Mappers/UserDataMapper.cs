using Domain.Models;
using PeakForm.Api.DTOs;

namespace PeakForm.Api.Mappers;

public static class UserDataMapper
{
    public static UserDataDto MapToDto(this UserData userData)
    {
        return new UserDataDto
        {
            Weight = userData.Weight,
            Height = userData.Height,
            Age = userData.Age,
            Gender = userData.Gender,
            BodyFatPercentage = userData.BodyFatPercentage,
            MuscleMassPercentage = userData.MuscleMassPercentage,
            ActivityLevel = userData.ActivityLevel,
            WaistCircumference = userData.WaistCircumference,
            HipCircumference = userData.HipCircumference,
            NeckCircumference = userData.NeckCircumference,
            GoalBodyFatPercentage = userData.GoalBodyFatPercentage,
            GoalWeight = userData.GoalWeight,
            GoalMuscleMassPercentage = userData.GoalMuscleMassPercentage,
            Bmi = userData.Bmi,
            Bmr = userData.Bmr
        };
    }
}
