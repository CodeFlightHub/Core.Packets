namespace Core.QuickExtend.Tests.HttpClientExtentions.Post;

internal class PostTests
{

    public class HttpClientExtensionsTests
    {
        private HttpClient _httpClient;
        private const string BaseUrl = "https://jsonplaceholder.typicode.com";

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
        }



        [Test]
        public async Task PostJsonAsync_ValidRequest_ReturnsExpectedResponse()
        {
            // Arrange
            var requestUri = new Uri($"{BaseUrl}/posts");
            var requestData = new { userId = 1, id = 101, title = "test title", body = "test body" };

            // Act
            var response = await _httpClient.PostJsonAsync<ResponseData, object>(requestUri, requestData);

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(requestData.userId, response.UserId);
            Assert.AreEqual(requestData.id, response.Id);
            Assert.AreEqual(requestData.title, response.Title);
            Assert.AreEqual(requestData.body, response.Body);
        }

        [Test]
        public void PostJsonAsync_NullRequestUri_ThrowsArgumentNullException()
        {
            // Arrange
            Uri requestUri = null;
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
            var requestUri = new Uri($"{BaseUrl}/posts");
            object requestData = null;

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _httpClient.PostJsonAsync<dynamic, object>(requestUri, requestData);
            });
        }

    }
}
