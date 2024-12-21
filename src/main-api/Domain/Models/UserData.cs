using Domain.Models.Enums;

namespace Domain.Models;

public class UserData : IEntity
{
    public Guid Id { get; init; }
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public decimal BodyFatPercentage { get; set; }
    public decimal MuscleMassPercentage { get; set; }

    public ActivityLevel ActivityLevel { get; set; }

    public decimal Bmr
    {
        get { return CalculateBmr(); }
    }
    public decimal Bmi
    {
        get { return CalculateBmi(); }
    }

    public decimal WaistCircumference { get; set; }
    public decimal HipCircumference { get; set; }
    public decimal NeckCircumference { get; set; }

    public decimal GoalBodyFatPercentage { get; set; }
    public decimal GoalWeight { get; set; }
    public decimal GoalMuscleMassPercentage { get; set; }

    private decimal CalculateBmi()
    {
        if (Weight <= 0 || Height <= 0)
            return 0;

        return Weight / (Height / 100 * Height / 100);
    }

    private decimal CalculateBmr()
    {
        if (Weight <= 0 || Height <= 0 || Age <= 0)
            return 0;

        if (Gender == Enums.Gender.Male)
        {
            return 10 * Weight + 6.25m * Height - 5 * Age + 5;
        }
        else
        {
            return 10 * Weight + 6.25m * Height - 5 * Age - 161;
        }
    }
}