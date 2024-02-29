using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.HttpClientExtentions.Post
{
    internal class XmlTests
    {
        private HttpClient _httpClient;
        private const string BaseUrl = "https://example.com";  

        [SetUp]
        public void Setup()
        {
            _httpClient = new HttpClient();
        }

        //[Test]
        //public async Task PostAsXmlAsync_ValidRequest_ReturnsSuccessStatusCode()
        //{
        //    // Arrange
        //    var requestUri = new Uri("https://www.example.com/api/endpoint");  
        //    var requestData = new SampleData { Property1 = "Value1", Property2 = "Value2" };  

        //    // Act
        //    var response = await _httpClient.PostAsXmlAsync(requestUri, requestData);

        //    // Assert
        //    Assert.IsNotNull(response);
        //    Assert.IsTrue(response.IsSuccessStatusCode);
        //}


        [Test]
        public void PostAsXmlAsync_NullData_ThrowsArgumentNullException()
        {
            // Arrange
            var requestUri = new Uri($"{BaseUrl}/endpoint");  
            SampleData requestData = null;

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () =>
            {
                await _httpClient.PostAsXmlAsync(requestUri, requestData);
            });
        }

 
        public class SampleData
        {
            public string Property1 { get; set; }
            public string Property2 { get; set; }
        }
    }
}
