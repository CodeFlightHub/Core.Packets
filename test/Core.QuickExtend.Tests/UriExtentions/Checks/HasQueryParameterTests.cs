namespace Core.QuickExtend.Tests.UriExtentions.Checks;

internal class HasQueryParameterTests
{
    [Test]
    public void HasQueryParameter_ExistingParameter_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act
        var hasParameter = uri.HasQueryParameter("page");

        // Assert
        Assert.IsTrue(hasParameter);
    }

    [Test]
    public void HasQueryParameter_NonExistingParameter_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act
        var hasParameter = uri.HasQueryParameter("filter");

        // Assert
        Assert.IsFalse(hasParameter);
    }

    [Test]
    public void HasQueryParameter_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.HasQueryParameter("page"));
    }

    [Test]
    public void HasQueryParameter_EmptyParameterName_ThrowsArgumentException()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => uri.HasQueryParameter(""));
    }
}
