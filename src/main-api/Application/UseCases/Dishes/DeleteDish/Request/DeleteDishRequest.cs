using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dishes.DeleteDish.Request;
public class DeleteDishRequest : UseCases.Request
{
    [Required]
    public required Guid Id { get; set; }
}
