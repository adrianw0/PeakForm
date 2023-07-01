using Application.UseCases.MealHistory.GetMeals.Request;
using Application.UseCases.MealHistory.GetMeals.Response;
using Core.Common;
using Core.Interfaces.Repositories;
using Core.Params;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.MealHistory.GetMeals;
public class GetMealsUseCase : IGetMealsUseCase
{
    private readonly IReadRepository<Meal> _mealReadRepository;

    public GetMealsUseCase(IReadRepository<Meal> mealReadRepository)
    {
        _mealReadRepository = mealReadRepository;
    }

    public async Task<GetMealsReposnse> Execute(GetMealsRequest request)
    {

        var meals = await _mealReadRepository.FindAsync(m => request.DateFrom <= m.Date && m.Date <= request.DateTo, request.PagingParams.Page, request.PagingParams.PageSize);
        
        return new GetMealsSuccessResponse { Meals = meals.ToList() };
    }
}
