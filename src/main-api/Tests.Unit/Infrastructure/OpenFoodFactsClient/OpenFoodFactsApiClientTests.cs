using FluentAssertions;
using Infrastructure.ExternalAPIs.OpenFoodFactsApiWrapper;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using Newtonsoft.Json;
using System.Net;

namespace Tests.Unit.Infrastructure.OpenFoodFactsClient;
public class OpenFoodFactsApiClientTests
{
    private Mock<HttpMessageHandler> _httpMessageHandlerMock;
    private Mock<ILogger<OpenFoodFactsApiClient>> _loggerMock;
    private HttpClient _httpClient;
    private OpenFoodFactsApiClient _apiClient;

    [SetUp]
    public void Setup()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_httpMessageHandlerMock.Object);

        _loggerMock = new Mock<ILogger<OpenFoodFactsApiClient>>();

        _apiClient = new OpenFoodFactsApiClient(_httpClient, _loggerMock.Object);
    }

    [TearDown]
    public void Teardown()
    {
        _httpClient.Dispose();
    }

    [Test]
    public async Task GetProductsByNameAsyncShouldReturnListOfProductsWhenApiReturnsValidResponse()
    {
        // Arrange
        var searchParam = "Berlinki";
        var pageNumber = 1;
        var pageSize = 5;
        var fakeApiResponse = new Root
        {
            Products =
                [
                    new Product { product_name = "Berlinki Classic", code = "5900567001746" }
                ]
        };

        var responseContent = JsonConvert.SerializeObject(fakeApiResponse);

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            });

        // Act
        var result = await _apiClient.GetProductsByNameAsync(searchParam, pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.Should().HaveCount(1);
        result.First().Name.Should().Be("Berlinki Classic");
        result.First().Ean.Should().Be("5900567001746");
    }

    [Test]
    public async Task GetProductsByNameAsyncShouldReturnEmptyListWhenApiReturnsNoProducts()
    {
        // Arrange
        var searchParam = "UnknownProduct";
        var pageNumber = 1;
        var pageSize = 5;
        var fakeApiResponse = new Root
        {
            Products = []
        };

        var responseContent = JsonConvert.SerializeObject(fakeApiResponse);

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            });

        // Act
        var result = await _apiClient.GetProductsByNameAsync(searchParam, pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Test]
    public async Task GetProductByCodeAsyncShouldReturnProductWhenApiReturnsValidResponse()
    {
        // Arrange
        var searchParam = "5900567001746";
        var fakeApiResponse = new Root
        {
            product = new Product { product_name = "Berlinki Classic", code = "5900567001746" }
        };

        var responseContent = JsonConvert.SerializeObject(fakeApiResponse);

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            });

        // Act
        var result = await _apiClient.GetProductByCodeAsync(searchParam);

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("Berlinki Classic");
        result.Ean.Should().Be("5900567001746");
    }

    [Test]
    public async Task GetProductByCodeAsyncShouldReturnNullWhenApiReturnsNull()
    {
        // Arrange
        var searchParam = "InvalidCode";
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
        var fakeApiResponse = new Root
        {
            product = null
        };
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.

        var responseContent = JsonConvert.SerializeObject(fakeApiResponse);

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(responseContent)
            });

        // Act
        var result = await _apiClient.GetProductByCodeAsync(searchParam);

        // Assert
        result.Should().BeNull();
    }

    [Test]
    public async Task GetProductsByNameAsyncShouldReturnEmptyListWhenApiCallFails()
    {
        // Arrange
        var searchParam = "Berlinki";
        var pageNumber = 1;
        var pageSize = 5;

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("API call failed"));

        // Act
        var result = await _apiClient.GetProductsByNameAsync(searchParam, pageNumber, pageSize);

        // Assert
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Test]
    public async Task GetProductByCodeAsyncShouldReturnNullWhenApiCallFails()
    {
        // Arrange
        var searchParam = "5900567001746";

        _httpMessageHandlerMock
            .Protected()
            .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
            .ThrowsAsync(new HttpRequestException("API call failed"));

        // Act
        var result = await _apiClient.GetProductByCodeAsync(searchParam);

        // Assert
        result.Should().BeNull();
    }
}
