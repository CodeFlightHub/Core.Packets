using Core.QuickExtend.Tests.Infrastructure.Models;

namespace Core.QuickExtend.Tests.Tests.HttpClientExtensions;

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
        var requestDataModel = new RequestDataModel
        {
            UserId = 1,
            Id = 1,
            Title = "Updated Title",
            Body = "Updated Body"
        };

        // Act
        var response = await _httpClient.PutJsonAsync<ResponseDataModel, RequestDataModel>(requestUri, requestDataModel);

        // Assert
        Assert.NotNull(response);
        Assert.That(response.UserId, Is.EqualTo(requestDataModel.UserId));
        Assert.That(response.Id, Is.EqualTo(requestDataModel.Id));
        Assert.That(response.Title, Is.EqualTo(requestDataModel.Title));
        Assert.That(response.Body, Is.EqualTo(requestDataModel.Body));
    }

    [Test]
    public void PutJsonAsync_NullRequestUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri requestUri = default!;
        var requestDataModel = new RequestDataModel();

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PutJsonAsync<ResponseDataModel, RequestDataModel>(requestUri, requestDataModel);
        });
    }

    [Test]
    public void PutJsonAsync_NullRequestDataModel_ThrowsArgumentNullException()
    {
        // Arrange
        var requestUri = new Uri("posts/1", UriKind.Relative);
        RequestDataModel requestDataModel = default!;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PutJsonAsync<ResponseDataModel, RequestDataModel>(requestUri, requestDataModel);
        });
    }

    [Test]
    public void PutJsonAsync_HttpRequestExceptionThrown_ThrowsHttpRequestException()
    {
        // Arrange
        var requestUri = new Uri("invalidendpoint", UriKind.Relative);
        var requestDataModel = new RequestDataModel();

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await _httpClient.PutJsonAsync<ResponseDataModel, RequestDataModel>(requestUri, requestDataModel);
        });
    }
}