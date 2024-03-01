namespace Core.QuickExtend.Tests.UriExtentions.Gets;

internal class GetQueryParametersTests
{
    [Test]
    public void GetQueryParameters_WithParameters_ReturnsDictionary()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act
        var queryParameters = uri.GetQueryParameters();

        // Assert
        Assert.AreEqual(2, queryParameters.Count);
        Assert.IsTrue(queryParameters.ContainsKey("page"));
        Assert.AreEqual("2", queryParameters["page"]);
        Assert.IsTrue(queryParameters.ContainsKey("sort"));
        Assert.AreEqual("desc", queryParameters["sort"]);
    }

    [Test]
    public void GetQueryParameters_WithoutParameters_ReturnsEmptyDictionary()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var queryParameters = uri.GetQueryParameters();

        // Assert
        Assert.AreEqual(0, queryParameters.Count);
    }

    [Test]
    public void GetQueryParameters_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetQueryParameters());
    }
}
