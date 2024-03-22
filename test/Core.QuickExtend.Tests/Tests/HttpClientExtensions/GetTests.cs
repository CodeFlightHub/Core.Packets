using Moq.Protected;
using System.Net.Http;
using System.Net;
using Core.QuickExtend.Tests.Infrastructure.Models;

namespace Core.QuickExtend.Tests.Tests.HttpClientExtensions;

internal class GetTests
{
    private HttpClient _httpClient;
    private const string BaseUri = "https://jsonplaceholder.typicode.com/";

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri(BaseUri) };
    }

    [TearDown]
    public void TearDown()
    {
        _httpClient.Dispose();
    }

    [Test]
    public async Task GetAsByteArrayAsync_ValidUri_ReturnsByteArray()
    {
        // Arrange
        var validUri = new Uri("https://www.example.com");

        // Act
        byte[] result = await _httpClient.GetAsByteArrayAsync(validUri);

        // Assert
        Assert.IsNotNull(result);
        Assert.Greater(result.Length, 0);
    }

    [Test]
    public void GetAsByteArrayAsync_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri? nullUri = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () => await _httpClient.GetAsByteArrayAsync(nullUri));
    }

    [Test]
    public void GetAsByteArrayAsync_HttpRequestExceptionThrownByHttpClient_ThrowsHttpRequestException()
    {
        // Arrange
        var invalidUri = new Uri("https://invalid.example.com");

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () => await _httpClient.GetAsByteArrayAsync(invalidUri));
    }

    [Test]
    public void GetAsByteArrayAsync_InvalidResponse_ThrowsHttpRequestException()
    {
        // Arrange
        var invalidUri = new Uri("https://www.example.com/invalid");

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () => await _httpClient.GetAsByteArrayAsync(invalidUri));
    }

    [Test]
    public void GetAsImageAsync_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri? nullUri = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () => await _httpClient.GetAsImageAsync(nullUri));
    }

    [Test]
    public void GetAsImageAsync_HttpRequestExceptionThrownByHttpClient_ThrowsHttpRequestException()
    {
        // Arrange
        var invalidUri = new Uri("https://invalid.example.com/image.jpg");

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () => await _httpClient.GetAsImageAsync(invalidUri));
    }

    [Test]
    public void GetAsImageAsync_InvalidImageBytes_ThrowsInvalidOperationException()
    {
        // Arrange
        byte[] invalidImageBytes = new byte[] { 0x00, 0x00, 0x00, 0x00 };
        var content = new ByteArrayContent(invalidImageBytes);
        var invalidUri = new Uri("https://www.example.com/invalid_image.jpg");

        var httpClientHandler = new Mock<HttpMessageHandler>();
        httpClientHandler.Protected()
                         .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                         .ReturnsAsync(new HttpResponseMessage
                         {
                             StatusCode = HttpStatusCode.OK,
                             Content = content
                         });

        var httpClient = new HttpClient(httpClientHandler.Object);

        // Act & Assert
        Assert.ThrowsAsync<InvalidOperationException>(async () => await httpClient.GetAsImageAsync(invalidUri));
    }

    [Test]
    public async Task GetAsJsonAsync_ValidRequest_ReturnsResponse()
    {
        // Arrange
        var requestUri = new Uri("posts/1", UriKind.Relative);

        // Act
        var response = await _httpClient.GetAsJsonAsync<ResponseDataModel>(requestUri);

        // Assert
        Assert.NotNull(response);
        // Additional assertions as needed
    }

    [Test]
    public void GetAsJsonAsync_NullRequestUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri? requestUri = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.GetAsJsonAsync<ResponseDataModel>(requestUri);
        });
    }

    [Test]
    public void GetAsJsonAsync_HttpRequestExceptionThrown_ThrowsHttpRequestException()
    {
        // Arrange
        var requestUri = new Uri("invalidendpoint", UriKind.Relative);

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await _httpClient.GetAsJsonAsync<ResponseDataModel>(requestUri);
        });
    }

    [Test]
    public void GetAsJsonAsync_EmptyResponseContent_ThrowsHttpRequestException()
    {
        // Arrange
        var requestUri = new Uri("emptyendpoint", UriKind.Relative);

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await _httpClient.GetAsJsonAsync<ResponseDataModel>(requestUri);
        });
    }

    [Test]
    public async Task GetAsStreamAsync_ValidUri_ReturnsStream()
    {
        // Arrange
        var validUri = new Uri("https://example.com");

        // Act
        Stream stream = await _httpClient.GetAsStreamAsync(validUri);

        // Assert
        Assert.IsNotNull(stream);
        Assert.IsTrue(stream.CanRead);
    }

    [Test]
    public void GetAsStreamAsync_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri? nullUri = null;

        // Act & Assert
        ArgumentNullException ex = Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.GetAsStreamAsync(nullUri);
        });

        Assert.That(ex.ParamName, Is.EqualTo("requestUri"));
    }

    [Test]
    public void GetAsStreamAsync_UnsuccessfulHttpResponse_ThrowsHttpRequestException()
    {
        // Arrange
        var invalidUri = new Uri("https://example.com/nonexistent");

        // Act & Assert
        HttpRequestException ex = Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await _httpClient.GetAsStreamAsync(invalidUri);
        });

        Assert.IsTrue(ex.Message.Contains("404"));
    }
}
