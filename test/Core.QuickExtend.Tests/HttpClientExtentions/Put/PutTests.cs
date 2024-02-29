using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.HttpClientExtentions.Put
{
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
                userId = 1,
                id = 1,
                title = "Updated Title",
                body = "Updated Body"
            };

            // Act
            var response = await _httpClient.PutJsonAsync<ResponseData, RequestData>(requestUri, requestData);

            // Assert
            Assert.NotNull(response);
            Assert.AreEqual(requestData.userId, response.userId);
            Assert.AreEqual(requestData.id, response.id);
            Assert.AreEqual(requestData.title, response.title);
            Assert.AreEqual(requestData.body, response.body);
        }

        [Test]
        public void PutJsonAsync_NullRequestUri_ThrowsArgumentNullException()
        {
            // Arrange
            Uri requestUri = null;
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
            RequestData requestData = null;

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
}
 
