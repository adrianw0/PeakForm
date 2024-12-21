using Application.UseCases.MealHistory.GetMeals.Request;
using Application.UseCases.Responses.Get;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using System.Linq.Expressions;

namespace Application.UseCases.MealHistory.GetMeals;
public class GetMealsUseCase : IGetMealsUseCase
{
    private readonly IReadRepository<Meal> _mealReadRepository;
    private readonly IUserProvider _userProvider;

    public GetMealsUseCase(IReadRepository<Meal> mealReadRepository, IUserProvider userProvider)
    {
        _mealReadRepository = mealReadRepository;
        _userProvider = userProvider;
    }

    public async Task<GetReponse<Meal>> Execute(GetMealsRequest request)
    {
        Expression<Func<Meal, bool>> predicate = m =>
        (request.DateFrom <= m.Date && m.Date <= request.DateTo
        && m.OwnerId.Equals(_userProvider.UserId));


        var meals = await _mealReadRepository.FindAsync(predicate, request.PagingParams.Page, request.PagingParams.PageSize);

        return new GetSuccessReponse<Meal> { Entity = meals.ToList() };
    }
}
