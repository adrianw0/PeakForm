using System.Linq.Expressions;
using Application.Validators;
using Application.UseCases.Products.AddProduct;
using Application.UseCases.Products.AddProduct.Request;
using Core.Common;
using Core.Interfaces.Providers;
using Core.Interfaces.Repositories;
using Domain.Models;
using Domain.Models.Constants;
using Moq;
using Application.UseCases.Responses.Add;

namespace Tests.UseCases;
public class AddProductUseCaseTests
{
    private readonly Mock<IWriteRepository<Product>> _mockProductRepo;
    private readonly Mock<IUserProvider> _mockUserProvider;
    private readonly AddProductUseCase _useCase;
    private readonly Mock<IReadRepository<Unit>> _mockUnitRepo;

    public AddProductUseCaseTests()
    {
        _mockProductRepo = new Mock<IWriteRepository<Product>>();
        _mockUserProvider = new Mock<IUserProvider>();
        _mockUnitRepo = new Mock<IReadRepository<Unit>>();

        var validator = new AddProductRequestValidator(_mockUnitRepo.Object);
        _useCase = new AddProductUseCase(_mockProductRepo.Object, _mockUserProvider.Object, validator);
    }
    [Fact]
    public async Task ExecuteShouldReturnProductResponse()
    {


        var userId = "123456789";
        _mockUserProvider.Setup(x => x.UserId).Returns(userId);
        _mockUnitRepo.Setup(x => x.ExistsAsync(It.IsAny<Expression<Func<Unit, bool>>>())).ReturnsAsync(true);

        const string baseUnitCode = UnitsConstants.GramCode;
        const string baseUnitName = UnitsConstants.GramName;
        const double baseUnitWeight = 100.0;

        const double nutrientValueInBaseUnit = 123.0;
        const double nutrientValuePer1G = nutrientValueInBaseUnit / baseUnitWeight;

        var request = new AddProductRequest
        {
            Name = "testProduct",
            BaseUnit = new Unit { Code = baseUnitCode, Name = baseUnitName },
            UnitWeights = new List<UnitWeight>
            {
                new()
                {
                    Unit = new Unit { Code = baseUnitCode, Name = baseUnitName },
                    Weight = baseUnitWeight
                }
            },
            Nutrients = new List<NutrientValue>
            {
                new()
                {
                    Nutrient = new Nutrient
                    {
                        Name = NutrientNames.Proteins,
                        Unit = new Unit { Code = baseUnitCode, Name = baseUnitName }
                    },
                    Value = nutrientValueInBaseUnit
                }
            }
        };

        var result = await _useCase.Execute(request);
        var successResult = result as AddSuccessResponse<Product>;

        Assert.NotNull(successResult);
        Assert.Equal(request.Name, successResult.Entity?.Name);
        Assert.Equal(userId, successResult.Entity?.OwnerId);
        Assert.Single(successResult.Entity.NutrientsPer1G);

        var nutrientPer1G = successResult.Entity.NutrientsPer1G.Single();
        Assert.Equal(nutrientValuePer1G, nutrientPer1G.Value);
        Assert.Equal(NutrientNames.Proteins, nutrientPer1G.Nutrient.Name);
        Assert.Equal(baseUnitCode, nutrientPer1G.Nutrient.Unit.Code);
        Assert.Equal(baseUnitName, nutrientPer1G.Nutrient.Unit.Name);

    }
    [Fact]
    public async Task ExecuteShouldReturnUnitDoesNotExistWhenBaseUnitIsNotPresent()
    {
        _mockUnitRepo.Setup(x => x.ExistsAsync(u => u.Code == "baseUnitCode")).ReturnsAsync(false);

        var request = new AddProductRequest
        {
            Name = "TestProduct",
            BaseUnit = new Unit { Code = "baseUnitCode", Name = "baseUnitName" },
            Nutrients = new List<NutrientValue>(),
            UnitWeights = new List<UnitWeight>()
        };

        var result = await _useCase.Execute(request);

        Assert.IsType<AddErrorResponse<Product>>(result);
        Assert.Equal($"{ErrorCodes.UnitDoesNotExist}; {ErrorCodes.BaseUnitDoesNotExistInProductUnits}", ((AddErrorResponse<Product>)result).Code);
    }

}
