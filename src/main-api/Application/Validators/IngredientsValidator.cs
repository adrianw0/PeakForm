﻿using Application.Validators.Consts;
using Core.Interfaces.Repositories;
using Domain.Models;
using FluentValidation;

namespace Application.Validators;
internal class IngredientsValidator : AbstractValidator<Ingredient>
{
    public IngredientsValidator(IReadRepository<Unit> unitRepo)
    {
        RuleFor(x => x.Weight)
            .GreaterThan(0).WithMessage(ValidationMessages.WeightShouldBeGreaterThanZero);

        RuleFor(x => x.Unit)
            .MustAsync(async (unit, cancellation) =>
                await unitRepo.ExistsAsync(u => u.Code == unit.Code))
            .WithMessage(ValidationMessages.UnitDoesNotExist);


    }
}
