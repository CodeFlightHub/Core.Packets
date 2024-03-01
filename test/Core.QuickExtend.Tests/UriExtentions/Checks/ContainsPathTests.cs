namespace Core.QuickExtend.Tests.UriExtentions.Checks;

internal class ContainsPathTests
{
    [Test]
    public void ContainsPath_WithPath_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var containsPath = uri.ContainsPath("/api");

        // Assert
        Assert.IsTrue(containsPath);
    }

    [Test]
    public void ContainsPath_WithoutPath_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act
        var containsPath = uri.ContainsPath("/api");

        // Assert
        Assert.IsFalse(containsPath);
    }

    [Test]
    public void ContainsPath_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.ContainsPath("/api"));
    }

    [Test]
    public void ContainsPath_EmptyPath_ThrowsArgumentException()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => uri.ContainsPath(""));
    }
}
