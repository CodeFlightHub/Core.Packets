using Moq.Protected;
using System.Net;
using System.Text;

namespace Core.QuickExtend.Tests.HttpClientExtension;

internal class HttpClientExtentionUnitTest
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
    public async Task DeleteAsync_Generic_ReturnsResponse()
    {
        // Arrange
        var requestUri = new Uri("posts/1", UriKind.Relative);

        // Act
        var response = await _httpClient.CustomDeleteAsync<ResponseData>(requestUri);

        // Assert
        Assert.NotNull(response);
        // Additional assertions as needed
    }

    [Test]
    public async Task DeleteAsync_Generic_NullRequestUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri requestUri = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.CustomDeleteAsync<ResponseData>(requestUri);
        });
    }

    [Test]
    public async Task DeleteAsync_Generic_HttpRequestExceptionThrown_ThrowsHttpRequestException()
    {
        // Arrange
        var requestUri = new Uri("invalidendpoint", UriKind.Relative);

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await _httpClient.CustomDeleteAsync<ResponseData>(requestUri);
        });
    }

    [Test]
    public async Task DeleteAsync_NonGeneric_ValidRequest_ReturnsTrue()
    {
        // Arrange
        var requestUri = new Uri("posts/1", UriKind.Relative);

        // Act
        var result = await _httpClient.CustomDeleteAsync(requestUri);

        // Assert
        Assert.IsTrue(result);
    }


    [Test]
    public async Task DeleteAsync_NonGeneric_NullRequestUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri requestUri = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.CustomDeleteAsync(requestUri);
        });
    }

    [Test]
    public async Task DeleteAsync_NonGeneric_HttpRequestExceptionThrown_ThrowsHttpRequestException()
    {
        // Arrange
        var requestUri = new Uri("invalidendpoint", UriKind.Relative);

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await _httpClient.CustomDeleteAsync(requestUri);
        });
    }

    [Test]
    public async Task GetAsByteArrayAsync_ValidUri_ReturnsByteArray()
    {
        // Arrange
        var validUri = new Uri("https://www.example.com");

        // Act
        byte[] result = await _httpClient.GetAsByteArrayAsync(validUri);

        // Assert
        Assert.IsNotNull(result);
        Assert.Greater(result.Length, 0);
    }

    [Test]
    public void GetAsByteArrayAsync_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri nullUri = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () => await _httpClient.GetAsByteArrayAsync(nullUri));
    }

    [Test]
    public void GetAsByteArrayAsync_HttpRequestExceptionThrownByHttpClient_ThrowsHttpRequestException()
    {
        // Arrange
        var invalidUri = new Uri("https://invalid.example.com");

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () => await _httpClient.GetAsByteArrayAsync(invalidUri));
    }

    [Test]
    public void GetAsByteArrayAsync_InvalidResponse_ThrowsHttpRequestException()
    {
        // Arrange
        var invalidUri = new Uri("https://www.example.com/invalid");

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () => await _httpClient.GetAsByteArrayAsync(invalidUri));
    }

    //[Test]
    //public async Task GetAsImageAsync_ValidUri_ReturnsImage()
    //{
    //    // Arrange
    //    var validUri = new Uri("https://via.placeholder.com/150");

    //    // Act
    //    Image result = await _httpClient.GetAsImageAsync(validUri);

    //    // Assert
    //    Assert.IsNotNull(result);
    //    Assert.IsInstanceOf<Bitmap>(result);
    //}

    [Test]
    public void GetAsImageAsync_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri nullUri = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () => await _httpClient.GetAsImageAsync(nullUri));
    }

    [Test]
    public void GetAsImageAsync_HttpRequestExceptionThrownByHttpClient_ThrowsHttpRequestException()
    {
        // Arrange
        var invalidUri = new Uri("https://invalid.example.com/image.jpg");

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () => await _httpClient.GetAsImageAsync(invalidUri));
    }

    [Test]
    public async Task GetAsImageAsync_InvalidImageBytes_ThrowsInvalidOperationException()
    {
        // Arrange
        byte[] invalidImageBytes = new byte[] { 0x00, 0x00, 0x00, 0x00 };
        var content = new ByteArrayContent(invalidImageBytes);
        var invalidUri = new Uri("https://www.example.com/invalid_image.jpg");

        var httpClientHandler = new Mock<HttpMessageHandler>();
        httpClientHandler.Protected()
                         .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                         .ReturnsAsync(new HttpResponseMessage
                         {
                             StatusCode = HttpStatusCode.OK,
                             Content = content
                         });

        var httpClient = new HttpClient(httpClientHandler.Object);

        // Act & Assert
        Assert.ThrowsAsync<InvalidOperationException>(async () => await httpClient.GetAsImageAsync(invalidUri));
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
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
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

    [Test]
    public async Task PostJsonAsync_ValidRequest_ReturnsExpectedResponse()
    {
        // Arrange
        var requestUri = new Uri($"{BaseUri}/posts");
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
        var requestUri = new Uri($"{BaseUri}/posts");
        object requestData = null;

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
        Stream contentStream = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PostAsStreamAsync(requestUri, contentStream);
        });
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
        var requestUri = new Uri($"{BaseUri}/endpoint");
        SampleData requestData = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.PostAsXmlAsync(requestUri, requestData);
        });
    }

    [Test]
    public async Task PutJsonAsync_ValidRequest_ReturnsResponse()
    {
        // Arrange
        var requestUri = new Uri("posts/1", UriKind.Relative);
        var requestData = new RequestData
        {
            UserId = 1,
            Id = 1,
            Title = "Updated Title",
            Body = "Updated Body"
        };

        // Act
        var response = await _httpClient.PutJsonAsync<ResponseData, RequestData>(requestUri, requestData);

        // Assert
        Assert.NotNull(response);
        Assert.AreEqual(requestData.UserId, response.UserId);
        Assert.AreEqual(requestData.Id, response.Id);
        Assert.AreEqual(requestData.Title, response.Title);
        Assert.AreEqual(requestData.Body, response.Body);
    }

    [Test]
    public void PutJsonAsync_NullRequestUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri requestUri = default!;
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
        RequestData requestData = default!;

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
