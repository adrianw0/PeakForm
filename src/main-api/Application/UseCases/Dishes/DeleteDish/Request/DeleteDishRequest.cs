using System.ComponentModel.DataAnnotations;

namespace Application.UseCases.Dishes.DeleteDish.Request;
public class DeleteDishRequest : UseCases.Request
{
    [Required]
    public required Guid Id { get; set; }
}
