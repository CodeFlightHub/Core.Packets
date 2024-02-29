using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.HttpClientExtentions.Post
{
    internal class ByteArrayTests
    {
        private HttpClient _httpClient;

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
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
            byte[] byteArrayContent = null;

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _httpClient.PostByteArrayAsync(requestUri, byteArrayContent);
            });
        }
    }
}
