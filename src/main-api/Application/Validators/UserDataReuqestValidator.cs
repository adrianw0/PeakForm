using Application.UseCases.UserData.UpdateUserData.Request;
using Application.Validators.Consts;
using FluentValidation;

namespace Application.Validators;
public class UserDataReuqestValidator : AbstractValidator<UpdateUserDataRequest>
{
    public UserDataReuqestValidator()
    {
        RuleFor(x => x.Weight)
            .GreaterThan(0)
            .When(x => x.Weight.HasValue)
            .WithMessage(ValidationMessages.WeightGreaterThanZero);

        RuleFor(x => x.Height)
            .GreaterThan(0)
            .When(x => x.Height.HasValue)
            .WithMessage(ValidationMessages.HeightGreaterThanZero);

        RuleFor(x => x.Age)
            .InclusiveBetween(1, 120)
            .When(x => x.Age.HasValue)
            .WithMessage(ValidationMessages.AgeRange);

        RuleFor(x => x.BodyFatPercentage)
            .InclusiveBetween(0, 100)
            .When(x => x.BodyFatPercentage.HasValue)
            .WithMessage(ValidationMessages.BodyFatPercentageRange);

        RuleFor(x => x.MuscleMassPercentage)
            .InclusiveBetween(0, 100)
            .When(x => x.MuscleMassPercentage.HasValue)
            .WithMessage(ValidationMessages.MuscleMassPercentageRange);

        RuleFor(x => x.GoalBodyFatPercentage)
            .InclusiveBetween(0, 100)
            .When(x => x.GoalBodyFatPercentage.HasValue)
            .WithMessage(ValidationMessages.GoalBodyFatPercentageRange);

        RuleFor(x => x.GoalMuscleMassPercentage)
            .InclusiveBetween(0, 100)
            .When(x => x.GoalMuscleMassPercentage.HasValue)
            .WithMessage(ValidationMessages.GoalMuscleMassPercentageRange);

        RuleFor(x => x.WaistCircumference)
            .GreaterThan(0)
            .When(x => x.WaistCircumference.HasValue)
            .WithMessage(ValidationMessages.WaistCircumferenceGreaterThanZero);

        RuleFor(x => x.HipCircumference)
            .GreaterThan(0)
            .When(x => x.HipCircumference.HasValue)
            .WithMessage(ValidationMessages.HipCircumferenceGreaterThanZero);

        RuleFor(x => x.NeckCircumference)
            .GreaterThan(0)
            .When(x => x.NeckCircumference.HasValue)
            .WithMessage(ValidationMessages.NeckCircumferenceGreaterThanZero);

        RuleFor(x => x.GoalWeight)
            .GreaterThan(0)
            .When(x => x.GoalWeight.HasValue)
            .WithMessage(ValidationMessages.GoalWeightGreaterThanZero);

        RuleFor(x => x.Gender)
            .NotNull()
            .IsInEnum()
            .WithMessage(ValidationMessages.GenderRequired);

        RuleFor(x => x.ActivityLevel)
            .NotNull()
            .IsInEnum()
            .WithMessage(ValidationMessages.ActivityLevelRequired);
    }

}
