using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.Consts;
internal class ValidationMessages
{
    #region UserData
    public const string WeightGreaterThanZero = "Weight must be greater than 0.";
    public const string HeightGreaterThanZero = "Height must be greater than 0.";
    public const string AgeRange = "Age must be between 1 and 120.";
    public const string BodyFatPercentageRange = "Body Fat Percentage must be between 0 and 100.";
    public const string MuscleMassPercentageRange = "Muscle Mass Percentage must be between 0 and 100.";
    public const string GoalBodyFatPercentageRange = "Goal Body Fat Percentage must be between 0 and 100.";
    public const string GoalMuscleMassPercentageRange = "Goal Muscle Mass Percentage must be between 0 and 100.";
    public const string WaistCircumferenceGreaterThanZero = "Waist Circumference must be greater than 0.";
    public const string HipCircumferenceGreaterThanZero = "Hip Circumference must be greater than 0.";
    public const string NeckCircumferenceGreaterThanZero = "Neck Circumference must be greater than 0.";
    public const string GoalWeightGreaterThanZero = "Goal Weight must be greater than 0.";
    public const string GenderRequired = "Gender must be a valid value.";
    public const string ActivityLevelRequired = "Activity Level must be a valid value.";
    #endregion
}
