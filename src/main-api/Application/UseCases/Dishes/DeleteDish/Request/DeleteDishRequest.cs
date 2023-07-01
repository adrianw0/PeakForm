using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Dishes.DeleteDish.Request;
public class DeleteDishRequest : UseCases.Request
{
    public Guid Id { get; set; }
}
