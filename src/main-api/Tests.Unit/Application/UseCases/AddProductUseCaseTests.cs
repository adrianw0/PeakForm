using Application.UseCases.Products.AddProduct;
using Application.UseCases.Products.AddProduct.Request;
using Application.UseCases.Responses.Add;
using Application.Validators;
using AutoFixture;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using Domain.Models.Constants;
using FluentAssertions;
using FluentValidation;
using Moq;
using System.Linq.Expressions;
using ProdUnit = Domain.Models.Unit;


namespace Tests.Unit.Application.UseCases;

[TestFixture]
public class AddProductUseCaseTests
{
    private Mock<IWriteRepository<Product>> _mockProductRepo;
    private Mock<IUserProvider> _mockUserProvider;
    private Mock<IReadRepository<ProdUnit>> _mockUnitRepo;
    private AddProductUseCase _useCase;
    private Fixture _fixture;

    [SetUp]
    public void SetUp()
    {
        _fixture = new Fixture();
        _mockProductRepo = new Mock<IWriteRepository<Product>>();
        _mockUserProvider = new Mock<IUserProvider>();
        _mockUnitRepo = new Mock<IReadRepository<ProdUnit>>();

        var validator = new AddProductRequestValidator(_mockUnitRepo.Object);
        _useCase = new AddProductUseCase(_mockProductRepo.Object, _mockUserProvider.Object, validator);
    }

    [Test]
    public async Task ExecuteShouldReturnProductResponseWhenRequestIsValid()
    {
        // Arrange
        var userId = _fixture.Create<string>();
        var baseUnit = _fixture.Build<ProdUnit>()
            .With(u => u.Code, UnitsConstants.GramCode)
            .With(u => u.Name, UnitsConstants.GramName)
            .Create();

        var request = _fixture.Build<AddProductRequest>()
            .With(r => r.Name, "testProduct")
            .With(r => r.BaseUnit, baseUnit)
            .With(r => r.UnitWeights,
            [
                new() { Unit = baseUnit, Weight = 100 }
            ])
            .With(r => r.Nutrients,
            [
                new()
                {
                    Nutrient = new Nutrient { Name = NutrientNames.Proteins, Unit = baseUnit },
                    Value = 123
                }
            ])
            .Create();

        _mockUserProvider.Setup(x => x.UserId).Returns(userId);
        _mockUnitRepo.Setup(x => x.ExistsAsync(It.IsAny<Expression<Func<ProdUnit, bool>>>())).ReturnsAsync(true);

        // Act
        var result = await _useCase.Execute(request);

        // Assert
        var successResult = result.Should().BeOfType<AddSuccessResponse<Product>>().Subject;
        successResult.Entity.Should().NotBeNull();
        successResult.Entity.Name.Should().Be(request.Name);
        successResult.Entity.OwnerId.Should().Be(userId);
        successResult.Entity.NutrientsPer1G.Should().HaveCount(1);

        var nutrientPer1G = successResult.Entity.NutrientsPer1G.Single();
        nutrientPer1G.Value.Should().BeApproximately(123 / 100.0, 0.001);
        nutrientPer1G.Nutrient.Name.Should().Be(NutrientNames.Proteins);
        nutrientPer1G.Nutrient.Unit.Code.Should().Be(baseUnit.Code);
        nutrientPer1G.Nutrient.Unit.Name.Should().Be(baseUnit.Name);

        _mockProductRepo.Verify(x => x.InsertOneAsync(It.IsAny<Product>()), Times.Once);
    }

    [Test]
    public async Task ExecuteShouldReturnUnitDoesNotExistWhenBaseUnitIsMissing()
    {
        // Arrange

        var request = _fixture.Build<AddProductRequest>()
            .With(r => r.Name, "TestProduct")
            .With(r => r.BaseUnit, new ProdUnit { Code = "baseUnitCode", Name = "baseUnitName" })
            .With(r => r.Nutrients, [])
            .With(r => r.UnitWeights, [])
            .Create();

        _mockUnitRepo.Setup(x => x.ExistsAsync(It.IsAny<Expression<Func<ProdUnit, bool>>>())).ReturnsAsync(false);

        // Act
        var result = await _useCase.Execute(request);

        // Assert
        result.Should().BeOfType<AddErrorResponse<Product>>();
    }

    [Test]
    public async Task ExecuteShouldThrowExceptionWhenRepoThrowsError()
    {
        // Arrange
        var baseUnit = _fixture.Build<ProdUnit>()
            .With(u => u.Code, UnitsConstants.GramCode)
            .With(u => u.Name, UnitsConstants.GramName)
            .Create();

        var request = _fixture.Build<AddProductRequest>()
            .With(r => r.Name, "testProduct")
            .With(r => r.BaseUnit, baseUnit)
            .With(r => r.UnitWeights,
            [
                new() { Unit = baseUnit, Weight = 100 }
            ])
            .Create();
        _mockUnitRepo.Setup(x => x.ExistsAsync(It.IsAny<Expression<Func<ProdUnit, bool>>>())).ReturnsAsync(true);

        _mockProductRepo.Setup(x => x.InsertOneAsync(It.IsAny<Product>())).ThrowsAsync(new Exception("Database error"));

        // Act
        Func<Task> act = async () => await _useCase.Execute(request);

        // Assert
        await act.Should().ThrowAsync<Exception>().WithMessage("Database error");
        _mockProductRepo.Verify(x => x.InsertOneAsync(It.IsAny<Product>()), Times.Once);
    }
}
