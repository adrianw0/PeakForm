using Application.UseCases.MealHistory.AddMeal.Request;
using Application.Validators.Consts;
using Core.Interfaces.Repositories;
using Domain.Models;
using FluentValidation;

namespace Application.Validators.Requests;
internal class AddMealRequestValidator : AbstractValidator<AddMealRequest>
{
    public AddMealRequestValidator(IReadRepository<Unit> unitReadRepo)
    {
        RuleFor(x => x.FoodItems)
           .NotEmpty()
           .WithMessage(ValidationMessages.FooditemsListCannotBeEmpty)
           .ForEach(item =>
               item.SetValidator(new MealFoodItemsValidator(unitReadRepo)));  
    }
}
