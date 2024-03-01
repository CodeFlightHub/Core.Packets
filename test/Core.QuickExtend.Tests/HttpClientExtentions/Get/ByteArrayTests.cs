namespace Core.QuickExtend.Tests.HttpClientExtentions.Get;

internal class ByteArrayTests
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
        Uri nullUri = null;

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
}
