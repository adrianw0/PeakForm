
using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.MealHistory.DeleteMeal.Request;
public class DeleteMealRequest : UseCases.Request
{
    [Required]
    public required Guid Id { get; set; }
}
