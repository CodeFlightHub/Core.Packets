using Core.QuickExtend.Tests.Infrastructure.Models;
using System.Net;
using System.Text;

namespace Core.QuickExtend.Tests.Tests.HttpClientExtensions;

internal class PostTests
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
    public async Task PostByteArrayAsync_ValidRequest_ReturnsSuccessStatusCode()
    {
        // Arrange
        var requestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
        var contentString = "{\"title\":\"Test Title\",\"body\":\"Test Body\",\"userId\":1}";
        var byteArrayContent = Encoding.UTF8.GetBytes(contentString);

        // Act
        var response = await _httpClient.PostByteArrayAsync(requestUri, byteArrayContent);

        // Assert
        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }

    [Test]
    public void PostByteArrayAsync_NullContent_ThrowsArgumentNullException()
    {
        // Arrange
        var requestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
        byte[]? byteArrayContent = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PostByteArrayAsync(requestUri, byteArrayContent);
        });
    }

    [Test]
    public async Task PostFileAsync_ValidRequest_Success()
    {
        // Arrange
        var fileBytes = new byte[] { 0x1, 0x2, 0x3 }; // Sample file bytes
        var fileName = "testfile.txt";
        var requestUri = new Uri("https://jsonplaceholder.typicode.com/posts");

        // Act
        var response = await _httpClient.PostFileAsync(requestUri, fileBytes, fileName);

        // Assert
        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));
    }

    [Test]
    public async Task PostAsFormDataAsync_ValidRequest_ReturnsSuccessStatusCode()
    {
        // Arrange
        var requestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
        var formData = new List<KeyValuePair<string, string>>
        {
        new KeyValuePair<string, string>("title", "foo"),
        new KeyValuePair<string, string>("body", "bar"),
        new KeyValuePair<string, string>("userId", "1")
        };

        // Act
        var response = await _httpClient.PostAsFormDataAsync(requestUri, formData);

        // Assert
        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }

    [Test]
    public void PostAsFormDataAsync_NullFormData_ThrowsArgumentNullException()
    {
        // Arrange
        var requestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
        IEnumerable<KeyValuePair<string, string>>? formData = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PostAsFormDataAsync(requestUri, formData);
        });
    }

    [Test]
    public async Task PostJsonAsync_ValidRequest_ReturnsExpectedResponse()
    {
        // Arrange
        var requestUri = new Uri($"{BaseUri}/posts");
        var requestData = new { userId = 1, id = 101, title = "test title", body = "test body" };

        // Act
        var response = await _httpClient.PostJsonAsync<ResponseDataModel, object>(requestUri, requestData);

        // Assert
        Assert.IsNotNull(response);
        Assert.That(response.UserId, Is.EqualTo(requestData.userId));
        Assert.That(response.Id, Is.EqualTo(requestData.id));
        Assert.That(response.Title, Is.EqualTo(requestData.title));
        Assert.That(response.Body, Is.EqualTo(requestData.body));
    }

    [Test]
    public void PostJsonAsync_NullRequestUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri? requestUri = null;
        var requestData = new { userId = 1, id = 101, title = "test title", body = "test body" };

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PostJsonAsync<dynamic, object>(requestUri, requestData);
        });
    }

    [Test]
    public void PostJsonAsync_NullRequestData_ThrowsArgumentNullException()
    {
        // Arrange
        var requestUri = new Uri($"{BaseUri}/posts");
        object? requestData = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PostJsonAsync<dynamic, object>(requestUri, requestData);
        });
    }

    [Test]
    public async Task PostAsStreamAsync_ValidRequest_ReturnsSuccessStatusCode()
    {
        // Arrange
        var requestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
        var contentString = "{\"title\":\"Test Title\",\"body\":\"Test Body\",\"userId\":1}";
        var contentStream = new MemoryStream(Encoding.UTF8.GetBytes(contentString));

        // Act
        var response = await _httpClient.PostAsStreamAsync(requestUri, contentStream);

        // Assert
        Assert.IsNotNull(response);
        Assert.IsTrue(response.IsSuccessStatusCode);
    }

    [Test]
    public void PostAsStreamAsync_NullStream_ThrowsArgumentNullException()
    {
        // Arrange
        var requestUri = new Uri("https://jsonplaceholder.typicode.com/posts");
        Stream? contentStream = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PostAsStreamAsync(requestUri, contentStream);
        });
    }

    [Test]
    public void PostAsXmlAsync_NullData_ThrowsArgumentNullException()
    {
        // Arrange
        var requestUri = new Uri($"{BaseUri}/endpoint");
        SampleDataModel? requestData = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PostAsXmlAsync(requestUri, requestData);
        });
    }
}
