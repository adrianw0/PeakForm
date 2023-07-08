using Domain.Models;
using Domain.Models.Constants;
using FluentAssertions;
using Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;


namespace Tests.Infrastructure;
public class OpenFoodFactsApiWrapperTests
{
    [Fact]
    public async Task GetProductsByNameAsync_ReturnListOfProducts()
    {
        var gramUnit = new Unit { Code = UnitsConstants.GramCode, Name = UnitsConstants.GramName };

        var values = new List<NutrientValues>
        {
            new() { Nutrient =  new Nutrient { Name = NutrientNames.Proteins, Unit = gramUnit }, Value = 13 },
            new() { Nutrient =  new Nutrient { Name = NutrientNames.Carbohydrates, Unit = gramUnit }, Value = 2.7 },
            new() { Nutrient =  new Nutrient { Name = NutrientNames.Fats, Unit = gramUnit }, Value = 21 },
            new() { Nutrient =  new Nutrient { Name = NutrientNames.Sugar, Unit = gramUnit }, Value = 0.8 }
        };

        var expectedProduct = new Domain.Models.Product
        {
            Id = Guid.Empty,
            Name = "Berlinki Classic",
            Ean = "5900567001746",
            Description = string.Empty,
            Nutrients = values,
            IsGloballyVisible = true,
            OwnerId = string.Empty
        };


        var expectedResponse = await File.ReadAllTextAsync(Path.Combine("TestData", "OpenFoodFactsApiGetProductResponse.json"));

        var loggerMock = Mock.Of<ILogger<OpenFoodFactsApiWrapper>>();

        var handlerMock = new Mock<HttpMessageHandler>();
        var httpClient = new HttpClient(handlerMock.Object);

        handlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>
            (
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>()
            )
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = new StringContent(expectedResponse)
            })
            .Verifiable();



        var apiWrapper = new OpenFoodFactsApiWrapper(httpClient, loggerMock);
        var product  = (await apiWrapper.GetProductsByNameAsync("Berlinki", 1, 5)).FirstOrDefault();

        Assert.IsType<Domain.Models.Product>(product);

        expectedProduct.Should().BeEquivalentTo(product);
    }
}
