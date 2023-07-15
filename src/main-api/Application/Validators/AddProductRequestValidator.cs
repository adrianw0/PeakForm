using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.UseCases.Products.AddProduct.Request;
using Core.Common;
using Core.Interfaces.Repositories;
using Domain.Models;
using FluentValidation;

namespace Application.Validators;

public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
{
    private readonly IReadRepository<Unit> _unitReadRepository;

    public AddProductRequestValidator(IReadRepository<Unit> unitReadRepository)
    {
        _unitReadRepository = unitReadRepository;


        RuleFor(x => x.BaseUnit)
            .MustAsync(async (unit, cancellation) =>
                await unitReadRepository.ExistsAsync(u => u.Code == unit.Code))
            .WithMessage(ErrorCodes.UnitDoesNotExist);
        RuleFor(x => x.UnitWeights)
            .Must(uws => uws.GroupBy(uw => uw.Unit.Code).All(g => g.Count() == 1))
            .WithMessage(ErrorCodes.DuplicateUnitInProduct);
        RuleFor(x => x)
            .Must(r => r.UnitWeights.Any(uw => uw.Unit.Code == r.BaseUnit.Code))
            .WithMessage(ErrorCodes.BaseUnitDoesNotExistInProductUnits);
    }
}
