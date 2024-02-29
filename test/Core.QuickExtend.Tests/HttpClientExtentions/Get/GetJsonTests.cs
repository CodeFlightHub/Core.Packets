using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Core.QuickExtend.Tests.HttpClientExtentions.Put.PutTests;

namespace Core.QuickExtend.Tests.HttpClientExtentions.Get
{
    internal class GetJsonTests
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
        public async Task GetAsJsonAsync_ValidRequest_ReturnsResponse()
        {
            // Arrange
            var requestUri = new Uri("posts/1", UriKind.Relative);  

            // Act
            var response = await _httpClient.GetAsJsonAsync<ResponseData>(requestUri);

            // Assert
            Assert.NotNull(response);
            // Additional assertions as needed
        }

        [Test]
        public async Task GetAsJsonAsync_NullRequestUri_ThrowsArgumentNullException()
        {
            // Arrange
            Uri requestUri = null;

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _httpClient.GetAsJsonAsync<ResponseData>(requestUri);
            });
        }

        [Test]
        public async Task GetAsJsonAsync_HttpRequestExceptionThrown_ThrowsHttpRequestException()
        {
            // Arrange
            var requestUri = new Uri("invalidendpoint", UriKind.Relative);

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _httpClient.GetAsJsonAsync<ResponseData>(requestUri);
            });
        }

        [Test]
        public async Task GetAsJsonAsync_EmptyResponseContent_ThrowsHttpRequestException()
        {
            // Arrange
            var requestUri = new Uri("emptyendpoint", UriKind.Relative);  

            // Act & Assert
            Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _httpClient.GetAsJsonAsync<ResponseData>(requestUri);
            });
        }



    }
}
