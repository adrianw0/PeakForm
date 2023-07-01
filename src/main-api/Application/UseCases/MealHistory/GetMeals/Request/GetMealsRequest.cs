using Core.Params;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MealHistory.GetMeals.Request;
public class GetMealsRequest : UseCases.Request
{
    public PagingParams PagingParams { get; set; } = new();
    public  DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
}
