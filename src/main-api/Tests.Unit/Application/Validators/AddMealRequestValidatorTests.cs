using Application.UseCases.MealHistory.AddMeal.Request;
using Application.Validators.Consts;
using Application.Validators.Requests;
using AutoFixture;
using AutoFixture.Kernel;
using Core.Interfaces.Repositories;
using Domain;
using Domain.Models;
using FluentValidation.TestHelper;
using Moq;
using Moq.Protected;
using System.Linq.Expressions;
using Models = Domain.Models;

namespace Tests.Unit.Application.Validators;
[TestFixture]
public class AddMealRequestValidatorTests
{
    private AddMealRequestValidator _cut;
    private Fixture _fixture;
    private Mock<IReadRepository<Models.Unit>> unitReadRepoMock;
    [SetUp]
    public void SetUp()
    {
        _fixture = new Fixture();
        _fixture.Customizations.Add(new TypeRelay(typeof(IFoodItem), typeof(Product)));
        unitReadRepoMock = new Mock<IReadRepository<Models.Unit>>();
        _cut = new AddMealRequestValidator(unitReadRepoMock.Object);
    }

    [Test]
    public async Task ShouldReturnErrorWhenFooditemsListEmpty()
    {
        var foodItems = new List<MealFoodItem>();
        var req = _fixture.Build<AddMealRequest>()
            .With(x => x.FoodItems, foodItems)
            .Create();

        var res = await _cut.TestValidateAsync(req);

        res.ShouldHaveValidationErrorFor(x=>x.FoodItems).WithErrorMessage(ValidationMessages.FooditemsListCannotBeEmpty);

    }
    [Test]
    [TestCase(true)]
    [TestCase(false)]
    public async Task ShouldReturnErrorWhenUnitDoesNotExist(bool unitExists)
    {
        unitReadRepoMock.Setup(x=>x.ExistsAsync(It.IsAny<Expression<Func<Models.Unit, bool>>>())).ReturnsAsync(unitExists);
        List<MealFoodItem> foodItems = _fixture.CreateMany<MealFoodItem>(2).ToList();
        var req = _fixture.Build<AddMealRequest>()
            .With(x=>x.FoodItems, foodItems)
            .Create();

        var res = await _cut.TestValidateAsync(req);
        if (!unitExists)
        {
            res.ShouldHaveValidationErrorFor("FoodItems[0].WeightUnit").WithErrorMessage(ValidationMessages.UnitDoesNotExist);
            res.ShouldHaveValidationErrorFor("FoodItems[1].WeightUnit").WithErrorMessage(ValidationMessages.UnitDoesNotExist);
        }
        else
        {
            res.ShouldNotHaveValidationErrorFor("FoodItems[0].WeightUnit");
            res.ShouldNotHaveValidationErrorFor("FoodItems[1].WeightUnit");
        }
    }
    [Test]
    [TestCase(0, true)]
    [TestCase(-1.0, true)]
    [TestCase(1, false)]
    [TestCase(100000, false)]
    public async Task ShouldReturnErrorWhenWeightLessOrEqualZero(decimal weight, bool shouldHaveError)
    {
        List<MealFoodItem> foodItems = _fixture.Build<MealFoodItem>()
            .With(x => x.Weight, weight)
            .CreateMany(1).ToList();

        var req = _fixture.Build<AddMealRequest>()
            .With(x => x.FoodItems, foodItems)
            .Create();

        var res = await _cut.TestValidateAsync(req);

        if (shouldHaveError)
        {
            res.ShouldHaveValidationErrorFor("FoodItems[0].Weight").WithErrorMessage(ValidationMessages.WeightShouldBeGreaterThanZero);
        }
        else
        {
            res.ShouldNotHaveValidationErrorFor("FoodItems[0].Weight");
        }
    }
    }
