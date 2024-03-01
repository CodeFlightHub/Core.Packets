namespace Core.QuickExtend.Tests.UriExtentions.Checks;

internal class IsSecureTests
{
    [Test]
    public void IsSecure_WithHttpsScheme_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("https://example.com");

        // Act
        var result = uri.IsSecure();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsSecure_WithHttpScheme_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act
        var result = uri.IsSecure();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsSecure_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.IsSecure());
    }
}
