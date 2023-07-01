using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MealHistory.DeleteMeal.Request;
public class DeleteMealRequest : UseCases.Request
{
    public Guid Id { get; set; }
}
