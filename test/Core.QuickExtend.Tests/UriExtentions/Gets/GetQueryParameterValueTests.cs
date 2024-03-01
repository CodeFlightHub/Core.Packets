namespace Core.QuickExtend.Tests.UriExtentions.Gets;

internal class GetQueryParameterValueTests
{
    [Test]
    public void GetQueryParameterValue_WithParameter_ReturnsValue()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act
        var parameterValue = uri.GetQueryParameterValue("page");

        // Assert
        Assert.AreEqual("2", parameterValue);
    }

    [Test]
    public void GetQueryParameterValue_WithoutParameter_ReturnsNull()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act
        var parameterValue = uri.GetQueryParameterValue("filter");

        // Assert
        Assert.IsNull(parameterValue);
    }

    [Test]
    public void GetQueryParameterValue_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetQueryParameterValue("page"));
    }

    [Test]
    public void GetQueryParameterValue_EmptyParameterName_ThrowsArgumentException()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => uri.GetQueryParameterValue(""));
    }
}
