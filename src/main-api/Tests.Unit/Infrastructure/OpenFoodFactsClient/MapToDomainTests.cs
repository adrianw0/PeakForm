using AutoFixture;
using FluentAssertions;
using Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;
using Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper.Extensions;
using Moq;
using OpenFoodFactsProduct = Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper.Product;

namespace Tests.Unit.Infrastructure.OpenFoodFactsClient;
public class MapToDomainTests
{
    private Fixture _fixture;

    [SetUp]
    public void SetUp()
    {
        _fixture = new Fixture();
    }

    [Test]
    public void MapToDomainShouldReturnProductWhenValidOpenFoodFactsProductIsGiven()
    {
        // Arrange
        var externalProduct = _fixture.Build<OpenFoodFactsProduct>()
                                      .With(x => x.product_name, "Test Product")
                                      .With(x => x.code, "1234567890123")
                                      .With(x => x.nutriments, _fixture.Create<Nutriments>())
                                      .Create();

        // Act
        var result = externalProduct.MapToDomain();

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be(externalProduct.product_name);
        result.Ean.Should().Be(externalProduct.code);
        result.OwnerId.Should().BeEmpty();
        result.IsGloballyVisible.Should().BeTrue();
        result.NutrientsPer1G.Should().NotBeEmpty();
        result.NutrientsPer1G.Count.Should().Be(4); // 4 nutrients should be mapped
    }

    [Test]
    public void MapToDomainShouldHandleNullNutrimentsCorreclty()
    {
        // Arrange
        var externalProduct = _fixture.Build<OpenFoodFactsProduct>()
                                      .With(x => x.product_name, "Test Product")
                                      .With(x => x.code, "1234567890123")
                                      .With(x => x.nutriments, null as Nutriments)
                                      .Create();

        // Act
        var result = externalProduct.MapToDomain();

        // Assert
        result.Should().NotBeNull();
        result.NutrientsPer1G.Should().BeEmpty();
    }
}

