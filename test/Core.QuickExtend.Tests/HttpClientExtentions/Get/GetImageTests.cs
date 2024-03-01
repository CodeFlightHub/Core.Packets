using Moq.Protected;
using System.Net;

namespace Core.QuickExtend.Tests.HttpClientExtentions.Get;

internal class GetImageTests
{
    private HttpClient _httpClient;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
    }

    [TearDown]
    public void TearDown()
    {
        _httpClient.Dispose();
    }

    //[Test]
    //public async Task GetAsImageAsync_ValidUri_ReturnsImage()
    //{
    //    // Arrange
    //    var validUri = new Uri("https://via.placeholder.com/150");

    //    // Act
    //    Image result = await _httpClient.GetAsImageAsync(validUri);

    //    // Assert
    //    Assert.IsNotNull(result);
    //    Assert.IsInstanceOf<Bitmap>(result);
    //}



    [Test]
    public void GetAsImageAsync_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri nullUri = null;

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
    public async Task GetAsImageAsync_InvalidImageBytes_ThrowsInvalidOperationException()
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
}
