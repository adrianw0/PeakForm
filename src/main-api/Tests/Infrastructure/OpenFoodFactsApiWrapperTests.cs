using Core.Models.Constants;
using Domain.Models;
using FluentAssertions;
using Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;
using Moq;
using Moq.Protected;


namespace Tests.Infrastructure;
public class OpenFoodFactsApiWrapperTests
{
    [Fact]
    public async Task GetProducts_ReturnListOfProducts()
    {
        var gramUnit = new Unit { Code = UnitsContants.GramCode, Name = UnitsContants.GramName };

        var values = new List<NutrientValues>
        {
            new NutrientValues{ Nutrient =  new Nutrient { Name = NutrientNames.Proteins, Unit = gramUnit }, Value = 13 },
            new NutrientValues{ Nutrient =  new Nutrient { Name = NutrientNames.Carbohydrates, Unit = gramUnit }, Value = (decimal)2.7 },
            new NutrientValues{ Nutrient =  new Nutrient { Name = NutrientNames.Fats, Unit = gramUnit }, Value = 21 },
            new NutrientValues{ Nutrient =  new Nutrient { Name = NutrientNames.Sugar, Unit = gramUnit }, Value = (decimal)0.8 }
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


        var expectedResponse = await File.ReadAllTextAsync(Path.Combine("TestData", "OpenFoodFactsApiGetProductReponse.json"));

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



        var apiWrapper = new OpenFoodFactsApiWrapper(httpClient);
        var Product  = (await apiWrapper.GetProductsAsync("5900567001746")).FirstOrDefault();

        Assert.IsType<Domain.Models.Product>(Product);

        expectedProduct.Should().BeEquivalentTo(Product);
    }
}
