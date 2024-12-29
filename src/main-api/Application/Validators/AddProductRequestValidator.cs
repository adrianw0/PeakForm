using Application.UseCases.Products.AddProduct.Request;
using Application.Validators.Consts;
using Core.Interfaces.Repositories;
using Domain.Models;
using FluentValidation;

namespace Application.Validators;

public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
{

    public AddProductRequestValidator(IReadRepository<Unit> unitReadRepository)
    {
        RuleFor(x => x.BaseUnit)
            .MustAsync(async (unit, cancellation) =>
                await unitReadRepository.ExistsAsync(u => u.Code == unit.Code))
            .WithMessage(ValidationMessages.UnitNotFound);
        RuleFor(x => x.UnitWeights)
            .Must(uws => uws.GroupBy(uw => uw.Unit.Code).All(g => g.Count() == 1))
            .WithMessage(ValidationMessages.DuplicateUnit);
        RuleFor(x => x)
            .Must(r => r.UnitWeights.Any(uw => uw.Unit.Code == r.BaseUnit.Code))
            .WithMessage(ValidationMessages.BaseUnitDoesntExist);
    }
}
