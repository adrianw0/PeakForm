using Domain;
using Domain.Models;

namespace Application.Validators.Consts;
public class ValidationMessages
{
    #region General
    public const string UnitDoesNotExist = "Weight unit Does not exist";
    public const string WeightShouldBeGreaterThanZero = "Weight should be greated than 0.";
    #endregion
    #region Dish
    public const string NameIsRequired = "Name is required.";
    public const string IngredientsShouldNotBeEmpty = "Ingredients cannot be empty.";
    #endregion
    #region Meal
    public const string FooditemsListCannotBeEmpty = "Fooditems list cannot be empty.";
    public const string IngredientShouldNotBeNull = "Ingredient should not be null";

    #endregion
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
    #region Products
    public const string NoWeightForBaseUnit = "No weight for base unit specified";
    public const string BaseUnitDoesntExist = "Base unit doesn't exist";
    public const string DuplicateUnit = "Duplicate unit in product";
    #endregion
}
