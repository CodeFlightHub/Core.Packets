namespace Core.QuickExtend.Tests.HttpClientExtentions.Put;

internal class PutTests
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
    public async Task PutJsonAsync_ValidRequest_ReturnsResponse()
    {
        // Arrange
        var requestUri = new Uri("posts/1", UriKind.Relative);
        var requestData = new RequestData
        {
            UserId = 1,
            Id = 1,
            Title = "Updated Title",
            Body = "Updated Body"
        };

        // Act
        var response = await _httpClient.PutJsonAsync<ResponseData, RequestData>(requestUri, requestData);

        // Assert
        Assert.NotNull(response);
        Assert.AreEqual(requestData.UserId, response.UserId);
        Assert.AreEqual(requestData.Id, response.Id);
        Assert.AreEqual(requestData.Title, response.Title);
        Assert.AreEqual(requestData.Body, response.Body);
    }

    [Test]
    public void PutJsonAsync_NullRequestUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri requestUri = default!;
        var requestData = new RequestData();

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PutJsonAsync<ResponseData, RequestData>(requestUri, requestData);
        });
    }

    [Test]
    public void PutJsonAsync_NullRequestData_ThrowsArgumentNullException()
    {
        // Arrange
        var requestUri = new Uri("posts/1", UriKind.Relative);
        RequestData requestData = default!;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PutJsonAsync<ResponseData, RequestData>(requestUri, requestData);
        });
    }

    [Test]
    public void PutJsonAsync_HttpRequestExceptionThrown_ThrowsHttpRequestException()
    {
        // Arrange
        var requestUri = new Uri("invalidendpoint", UriKind.Relative);
        var requestData = new RequestData();

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await _httpClient.PutJsonAsync<ResponseData, RequestData>(requestUri, requestData);
        });
    }

}

