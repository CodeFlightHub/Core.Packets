using Core.QuickExtend.Tests.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.HttpClientExtensions;

internal class DeleteTests
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
        var response = await _httpClient.CustomDeleteAsync<ResponseDataModel>(requestUri);

        // Assert
        Assert.NotNull(response);
    }

    [Test]
    public void DeleteAsync_Generic_NullRequestUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri? requestUri = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            _ = await _httpClient.CustomDeleteAsync<ResponseDataModel>(requestUri);
        });
    }

    [Test]
    public void DeleteAsync_Generic_HttpRequestExceptionThrown_ThrowsHttpRequestException()
    {
        // Arrange
        var requestUri = new Uri("invalidendpoint", UriKind.Relative);

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await _httpClient.CustomDeleteAsync<ResponseDataModel>(requestUri);
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
    public void DeleteAsync_NonGeneric_NullRequestUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri? requestUri = null;

        // Act & Assert
        Assert.ThrowsAsync<ArgumentNullException>(async () =>
        {
            await _httpClient.CustomDeleteAsync(requestUri);
        });
    }

    [Test]
    public void DeleteAsync_NonGeneric_HttpRequestExceptionThrown_ThrowsHttpRequestException()
    {
        // Arrange
        var requestUri = new Uri("invalidendpoint", UriKind.Relative);

        // Act & Assert
        Assert.ThrowsAsync<HttpRequestException>(async () =>
        {
            await _httpClient.CustomDeleteAsync(requestUri);
        });
    }
}
