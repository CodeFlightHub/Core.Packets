using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.HttpClientExtentions.Post
{
    internal class StreamTests
    {
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
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
            Stream contentStream = null;

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _httpClient.PostAsStreamAsync(requestUri, contentStream);
            });
        }
    }
}
