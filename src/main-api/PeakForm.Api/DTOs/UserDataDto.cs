using Domain.Models.Enums;

namespace PeakForm.Api.DTOs;

public class UserDataDto
{
    public decimal Weight { get; set; }
    public decimal Height { get; set; }
    public int Age { get; set; }
    public Gender? Gender { get; set; }
    public decimal BodyFatPercentage { get; set; }
    public decimal MuscleMassPercentage { get; set; }

    public ActivityLevel? ActivityLevel { get; set; }

    public decimal WaistCircumference { get; set; }
    public decimal HipCircumference { get; set; }
    public decimal NeckCircumference { get; set; }

    public decimal GoalBodyFatPercentage { get; set; }
    public decimal GoalWeight { get; set; }
    public decimal GoalMuscleMassPercentage { get; set; }
    public decimal Bmi { get; set; }
    public decimal Bmr { get; set; }
}
