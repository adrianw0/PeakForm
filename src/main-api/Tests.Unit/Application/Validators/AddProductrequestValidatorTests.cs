using Application.UseCases.Dishes.AddDish.Request;
using Application.UseCases.MealHistory.AddMeal.Request;
using Application.UseCases.Products.AddProduct.Request;
using Application.Validators.Consts;
using Application.Validators.Requests;
using AutoFixture;
using Core.Interfaces.Repositories;
using Core.Params;
using Domain.Models;
using FluentAssertions;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Components.Forms;
using Moq;
using Moq.Protected;
using System.Linq.Expressions;
using Models= Domain.Models;

namespace Tests.Unit.Application.Validators;
[TestFixture]
public class AddProductrequestValidatorTests
{
    private Mock<IReadRepository<Models.Unit>> _unitRepoMock;
    private Fixture _fixture;

    private AddProductRequestValidator _cut;
    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture();
        _unitRepoMock = new Mock<IReadRepository<Models.Unit>>();
        _cut = new AddProductRequestValidator(_unitRepoMock.Object);
    }

    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ShouldReturnErrorWhenBaseUnitDoesntExist(bool unitExists)
    {  
        _unitRepoMock.Setup(x => x.ExistsAsync(It.IsAny<Expression<Func<Models.Unit, bool>>>())).ReturnsAsync(unitExists);

        var req = _fixture.Build<AddProductRequest>().Create();

        var res = await _cut.TestValidateAsync(req);

        if (!unitExists)
        {
            res.ShouldHaveValidationErrorFor(x => x.BaseUnit).WithErrorMessage(ValidationMessages.BaseUnitDoesntExist);
        }
        else
        {
            res.ShouldNotHaveValidationErrorFor(x => x.BaseUnit);
        }
    }
    [Test]
    public async Task ShouldReturnErrorWhenUnitWeightsDuplicate()
    {
        var unitWeights = _fixture.CreateMany<Models.UnitWeight>(2).ToList();
        unitWeights[0].Unit.Code = "code1";
        unitWeights[1].Unit.Code = "code1";

        var req = _fixture.Build<AddProductRequest>().With(x => x.UnitWeights, unitWeights).Create();

        var res = await _cut.TestValidateAsync(req);

        res.ShouldHaveValidationErrorFor(x => x.UnitWeights).WithErrorMessage(ValidationMessages.DuplicateUnit);
    }
    [Test]
    public async Task ShouldNotReturnErrorWhenUnitWeightsUnique()
    {
        var unitWeights = _fixture.CreateMany<Models.UnitWeight>(2).ToList();
        unitWeights[0].Unit.Code = "code1";
        unitWeights[1].Unit.Code = "code2";

        var req = _fixture.Build<AddProductRequest>().With(x => x.UnitWeights, unitWeights).Create();

        var res = await _cut.TestValidateAsync(req);

        res.ShouldNotHaveValidationErrorFor(x => x.UnitWeights);
    }
    [Test]
    public async Task ShouldReturnErrorWhenWeightForBaseUnitNotSpecified()
    {

        var unitWeights = _fixture.CreateMany<Models.UnitWeight>(2).ToList();
        unitWeights[0].Unit.Code = "code1";
        unitWeights[1].Unit.Code = "code2";

        var req = _fixture.Build<AddProductRequest>()
            .With(x => x.UnitWeights, unitWeights)
            .With(x => x.BaseUnit, new Models.Unit { Code = "Code3", Name = "Name"})
            .Create();

        var res = await _cut.TestValidateAsync(req);

        res.ShouldHaveValidationErrorFor(x => x).WithErrorMessage(ValidationMessages.NoWeightForBaseUnit);
    }
    [Test]
    public async Task ShouldNotReturnErrorWhenWeightForBaseUnitSpecified()
    {

        var unitWeights = _fixture.CreateMany<Models.UnitWeight>(2).ToList();
        unitWeights[0].Unit.Code = "code1";
        unitWeights[1].Unit.Code = "code2";

        var req = _fixture.Build<AddProductRequest>()
            .With(x => x.UnitWeights, unitWeights)
            .With(x => x.BaseUnit, new Models.Unit { Code = "code2", Name = "Name" })
            .Create();

        var res = await _cut.TestValidateAsync(req);

        res.ShouldNotHaveValidationErrorFor(x => x);
    }
    
}
