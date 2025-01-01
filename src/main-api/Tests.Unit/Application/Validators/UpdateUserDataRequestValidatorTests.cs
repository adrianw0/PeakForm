using Application.UseCases.UserData.UpdateUserData.Request;
using Application.Validators.Consts;
using Application.Validators.Requests;
using Domain.Models.Enums;
using FluentValidation.TestHelper;

namespace Tests.Unit.Application.Validators;
[TestFixture]
public class UpdateUserDataRequestValidatorTests
{
    private UpdateUserDataReuqestValidator _cut;

    [SetUp]
    public void Setup()
    {
        _cut = new UpdateUserDataReuqestValidator();
    }

    [TestCase(null, false)]
    [TestCase(-1, true)]
    [TestCase(0, true)]
    [TestCase(75, false)]
    public void WeightValidation(decimal? weight, bool shouldHaveError)
    {
        var request = new UpdateUserDataRequest { Weight = weight };

        var result = _cut.TestValidate(request);

        if (shouldHaveError)
        {
            result.ShouldHaveValidationErrorFor(x => x.Weight)
                  .WithErrorMessage(ValidationMessages.WeightGreaterThanZero);
        }
        else
        {
            result.ShouldNotHaveValidationErrorFor(x => x.Weight);
        }
    }

    [TestCase(null, false)]
    [TestCase(-1, true)]
    [TestCase(0, true)]
    [TestCase(180, false)]
    public void HeightValidation(decimal? height, bool shouldHaveError)
    {
        var request = new UpdateUserDataRequest { Height = height };

        var result = _cut.TestValidate(request);

        if (shouldHaveError)
        {
            result.ShouldHaveValidationErrorFor(x => x.Height)
                  .WithErrorMessage(ValidationMessages.HeightGreaterThanZero);
        }
        else
        {
            result.ShouldNotHaveValidationErrorFor(x => x.Height);
        }
    }

    [TestCase(null, false)]
    [TestCase(0, true)]
    [TestCase(121, true)]
    [TestCase(30, false)]
    public void AgeValidation(int? age, bool shouldHaveError)
    {
        var request = new UpdateUserDataRequest { Age = age };

        var result = _cut.TestValidate(request);

        if (shouldHaveError)
        {
            result.ShouldHaveValidationErrorFor(x => x.Age)
                  .WithErrorMessage(ValidationMessages.AgeRange);
        }
        else
        {
            result.ShouldNotHaveValidationErrorFor(x => x.Age);
        }
    }

    [TestCase(null, false)]
    [TestCase(-1, true)]
    [TestCase(101, true)]
    [TestCase(15, false)]
    public void BodyFatPercentageValidation(decimal? bodyFat, bool shouldHaveError)
    {
        var request = new UpdateUserDataRequest { BodyFatPercentage = bodyFat };

        var result = _cut.TestValidate(request);

        if (shouldHaveError)
        {
            result.ShouldHaveValidationErrorFor(x => x.BodyFatPercentage)
                  .WithErrorMessage(ValidationMessages.BodyFatPercentageRange);
        }
        else
        {
            result.ShouldNotHaveValidationErrorFor(x => x.BodyFatPercentage);
        }
    }

    [TestCase(null, false)]
    [TestCase(-1, true)]
    [TestCase(101, true)]
    [TestCase(45, false)]
    public void MuscleMassPercentageValidation(decimal? muscleMass, bool shouldHaveError)
    {
        var request = new UpdateUserDataRequest { MuscleMassPercentage = muscleMass };

        var result = _cut.TestValidate(request);

        if (shouldHaveError)
        {
            result.ShouldHaveValidationErrorFor(x => x.MuscleMassPercentage)
                  .WithErrorMessage(ValidationMessages.MuscleMassPercentageRange);
        }
        else
        {
            result.ShouldNotHaveValidationErrorFor(x => x.MuscleMassPercentage);
        }
    }

    [TestCase(null, false)]
    [TestCase(-1, true)]
    [TestCase(0, true)]
    [TestCase(95, false)]
    public void WaistCircumferenceValidation(decimal? waistCircumference, bool shouldHaveError)
    {
        var request = new UpdateUserDataRequest { WaistCircumference = waistCircumference };

        var result = _cut.TestValidate(request);

        if (shouldHaveError)
        {
            result.ShouldHaveValidationErrorFor(x => x.WaistCircumference)
                  .WithErrorMessage(ValidationMessages.WaistCircumferenceGreaterThanZero);
        }
        else
        {
            result.ShouldNotHaveValidationErrorFor(x => x.WaistCircumference);
        }
    }

    [TestCase(Gender.Male, false)]
    [TestCase((Gender)999, true)]
    public void GenderValidation(Gender gender, bool shouldHaveError)
    {
        var request = new UpdateUserDataRequest { Gender = gender };

        var result = _cut.TestValidate(request);

        if (shouldHaveError)
        {
            result.ShouldHaveValidationErrorFor(x => x.Gender)
                  .WithErrorMessage(ValidationMessages.GenderRequired);
        }
        else
        {
            result.ShouldNotHaveValidationErrorFor(x => x.Gender);
        }
    }

    [TestCase(ActivityLevel.Moderate, false)]
    [TestCase((ActivityLevel)999, true)]
    public void ActivityLevelValidation(ActivityLevel activityLevel, bool shouldHaveError)
    {
        var request = new UpdateUserDataRequest { ActivityLevel = activityLevel };

        var result = _cut.TestValidate(request);

        if (shouldHaveError)
        {
            result.ShouldHaveValidationErrorFor(x => x.ActivityLevel)
                  .WithErrorMessage(ValidationMessages.ActivityLevelRequired);
        }
        else
        {
            result.ShouldNotHaveValidationErrorFor(x => x.ActivityLevel);
        }
    }
}
