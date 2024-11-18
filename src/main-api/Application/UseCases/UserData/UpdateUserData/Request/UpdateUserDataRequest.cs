using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Models.Enums;

namespace Application.UseCases.UserData.UpdateUserData.Request;
public class UpdateUserDataRequest
{
    [Required]
    public Guid Id { get; init; }
    public decimal? Weight { get; set; }
    public decimal? Height { get; set; }
    public int? Age { get; set; }
    public Gender? Gender { get; set; }
    public decimal? BodyFatPercentage { get; set; }
    public decimal? MuscleMassPercentage { get; set; }

    public ActivityLevel? ActivityLevel { get; set; }

    public decimal? WaistCircumference { get; set; }
    public decimal? HipCircumference { get; set; }
    public decimal? NeckCircumference { get; set; }

    public decimal? GoalBodyFatPercentage { get; set; }
    public decimal? GoalWeight { get; set; }
    public decimal? GoalMuscleMassPercentage { get; set; }

}
