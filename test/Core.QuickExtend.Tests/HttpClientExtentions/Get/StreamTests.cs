using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.HttpClientExtentions.Get
{
    internal class StreamTests
    {
        private HttpClient _httpClient;

        [SetUp]
        public void SetUp()
        {
            _httpClient = new HttpClient();
        }

        [TearDown]
        public void TearDown()
        {
            _httpClient.Dispose();
        }

        [Test]
        public async Task GetAsStreamAsync_ValidUri_ReturnsStream()
        {
            // Arrange
            var validUri = new Uri("https://example.com");

            // Act
            Stream stream = await _httpClient.GetAsStreamAsync(validUri);

            // Assert
            Assert.IsNotNull(stream);
            Assert.IsTrue(stream.CanRead);
        }

        [Test]
        public async Task GetAsStreamAsync_NullUri_ThrowsArgumentNullException()
        {
            // Arrange
            Uri nullUri = null;

            // Act & Assert
            ArgumentNullException ex = Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _httpClient.GetAsStreamAsync(nullUri);
            });

            Assert.AreEqual("requestUri", ex.ParamName);
        }

        [Test]
        public async Task GetAsStreamAsync_UnsuccessfulHttpResponse_ThrowsHttpRequestException()
        {
            // Arrange
            var invalidUri = new Uri("https://example.com/nonexistent");

            // Act & Assert
            HttpRequestException ex = Assert.ThrowsAsync<HttpRequestException>(async () =>
            {
                await _httpClient.GetAsStreamAsync(invalidUri);
            });

            Assert.IsTrue(ex.Message.Contains("404"));  
        }

    }
}
