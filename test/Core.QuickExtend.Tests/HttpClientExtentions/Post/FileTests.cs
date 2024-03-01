using System.Net;

namespace Core.QuickExtend.Tests.HttpClientExtentions.Post;

internal class FileTests
{
    private HttpClient _client;

    [SetUp]
    public void Setup()
    {
        _client = new HttpClient();
    }

    [Test]
    public async Task PostFileAsync_ValidRequest_Success()
    {
        // Arrange
        var fileBytes = new byte[] { 0x1, 0x2, 0x3 }; // Sample file bytes
        var fileName = "testfile.txt";
        var requestUri = new Uri("https://jsonplaceholder.typicode.com/posts");

        // Act
        var response = await _client.PostFileAsync(requestUri, fileBytes, fileName);

        // Assert
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
    }

    [TearDown]
    public void TearDown()
    {
        _client.Dispose();
    }
}
