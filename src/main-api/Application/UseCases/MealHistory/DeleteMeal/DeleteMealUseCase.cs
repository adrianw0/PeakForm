using Application.UseCases.MealHistory.DeleteMeal.Request;
using Application.UseCases.Responses.Delete;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;

namespace Application.UseCases.MealHistory.DeleteMeal;
public class DeleteMealUseCase : IDeleteMealUseCase
{
    private readonly IWriteRepository<Meal> _mealWriteRepository;
    private readonly IReadRepository<Meal> _mealReadRepository;
    private readonly IUserProvider _userProvider;
    public DeleteMealUseCase(IWriteRepository<Meal> mealWriteRepository, IReadRepository<Meal> mealReadRepository, IUserProvider userProvider)
    {
        _mealWriteRepository = mealWriteRepository;
        _mealReadRepository = mealReadRepository;
        _userProvider = userProvider;
    }



    public async Task<DeleteResponse<Meal>> Execute(DeleteMealRequest request)
    {
        var meal = await _mealReadRepository.FindByIdAsync(request.Id);
        if (!meal.OwnerId.Equals(_userProvider.UserId))
            return new DeleteErrorResponse<Meal> { ErrorMessage = "Meal not found." };

        var deleted = await _mealWriteRepository.DeleteByIdAsync(request.Id);

        if (deleted) return new DeleteSuccessResponse<Meal>();

        return new DeleteErrorResponse<Meal> { ErrorMessage = "Delete failed." };
    }
}
