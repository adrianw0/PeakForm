using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

<<<<<<<< HEAD:src/main-api/Application/UseCases/MealHistory/DeleteMeal/Request/DeleteMealRequest.cs
namespace Application.UseCases.MealHistory.DeleteMeal.Request;
public class DeleteMealRequest : UseCases.Request
========
namespace Application.UseCases.Dishes.DeleteDish.Request;
public class DeleteDishRequest : UseCases.Request
>>>>>>>> d0f03aa0fe33333db916b435d17113880aa2aa51:src/main-api/Application/UseCases/Dishes/DeleteDish/Request/DeleteDishRequest.cs
{
    public Guid Id { get; set; }
}
