namespace Core.QuickExtend.Tests.HttpClientExtentions.Post;

internal class FormDataTests
{
    private HttpClient _httpClient;

    [SetUp]
    public void Setup()
    {
        _httpClient = new HttpClient();
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
        IEnumerable<KeyValuePair<string, string>> formData = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PostAsFormDataAsync(requestUri, formData);
        });
    }
}

