using Application.UseCases.Dishes.AddDish.Request;
using Application.Validators.Consts;
using Core.Interfaces.Repositories;
using Domain.Models;
using FluentValidation;

namespace Application.Validators.Requests;
internal class AddDishRequestValidator : AbstractValidator<AddDishRequest>
{
    public AddDishRequestValidator(IReadRepository<Unit> unitRepo)
    {
        RuleFor(x => x.Ingredients)
            .NotEmpty().WithMessage(ValidationMessages.IngredientsShouldNotBeEmpty)
            .ForEach(ingredient =>
            {
                ingredient.SetValidator(new IngredientsValidator(unitRepo));
            });
    }
}
