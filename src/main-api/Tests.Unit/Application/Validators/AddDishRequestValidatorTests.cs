
using Application.Validators.Requests;
using Core.Interfaces.Repositories;
using Moq;
using Domain.Models;
using AutoFixture;
using Application.UseCases.Dishes.AddDish.Request;
using FluentValidation.TestHelper;
using Application.Validators.Consts;
using System.Linq.Expressions;
using System.Reflection;

namespace Tests.Unit.Application.Validators;
[TestFixture]
public class AddDishRequestValidatorTests
{
    private AddDishRequestValidator _cut;
    private Fixture _fixture;
    private Mock<IReadRepository<Domain.Models.Unit>> _unitRepoMock;
    [SetUp]
    public void Setup()
    {
        _unitRepoMock = new Mock<IReadRepository<Domain.Models.Unit>>();
        _fixture = new Fixture();
        _cut = new AddDishRequestValidator(_unitRepoMock.Object);            
    }

    [Test]
    public async Task ShoudReturnErrorWhenIngredientsEmpty()
    {
        List<Ingredient> ingredients = [];
        var Dish = _fixture.Build<AddDishRequest>()
            .With(x=>x.Ingredients, ingredients)
            .Create();

        var res = await _cut.TestValidateAsync(Dish);

        res.ShouldHaveValidationErrorFor(x=>x.Ingredients).WithErrorMessage(ValidationMessages.IngredientsShouldNotBeEmpty);
    }
    [Test]
    public async Task ShoudNotReturnErrorWhenIngredientsNotEmpty()
    {
        List<Ingredient> ingredients = _fixture.CreateMany<Ingredient>().ToList();
        var Dish = _fixture.Build<AddDishRequest>()
            .With(x => x.Ingredients, ingredients)
            .Create();

        var res = await _cut.TestValidateAsync(Dish);

        res.ShouldNotHaveValidationErrorFor(x => x.Ingredients);
    }
    [Test]
    [TestCase(0.00, true)]
    [TestCase(-1.00, true)]
    [TestCase(1.00, false)]
    [TestCase(10000.99, false)]
    public async Task ShouldReturnErrorWhenIngredientWeightNotGreaterThanZero(decimal weight, bool shouldHaveError)
    {
        List<Ingredient> ingredients = _fixture
            .Build<Ingredient>()
            .With(x=>x.Weight, weight).CreateMany(1).ToList();
        var req = _fixture.Build<AddDishRequest>()
            .With(x=>x.Ingredients, ingredients)
            .Create();

        var res = await _cut.TestValidateAsync(req);

        if (shouldHaveError)
        {
            res.ShouldHaveValidationErrorFor("Ingredients[0].Weight").WithErrorMessage(ValidationMessages.WeightShouldBeGreaterThanZero);
        }
        else
        {
            res.ShouldNotHaveValidationErrorFor("Ingredients[0].Weight");
        }

    }
    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ShouldReturnErrorWhenUnitDoesNotExist(bool unitExists)
    {
        _unitRepoMock.Setup(x => x.ExistsAsync(It.IsAny<Expression<Func<Domain.Models.Unit, bool>>>())).ReturnsAsync(unitExists);
        List<Ingredient> ingredients = _fixture.CreateMany<Ingredient>(2).ToList();
        var req = _fixture.Build<AddDishRequest>()
            .With(x => x.Ingredients, ingredients)
            .Create();

        var res = await _cut.TestValidateAsync(req);

        if (!unitExists)
        {
            res.ShouldHaveValidationErrorFor("Ingredients[0].Unit").WithErrorMessage(ValidationMessages.UnitDoesNotExist);
            res.ShouldHaveValidationErrorFor("Ingredients[1].Unit").WithErrorMessage(ValidationMessages.UnitDoesNotExist);
        }
        else
        {
            res.ShouldNotHaveValidationErrorFor("Ingredients[0].Unit");
            res.ShouldNotHaveValidationErrorFor("Ingredients[1].Unit");
        }
    }

}
