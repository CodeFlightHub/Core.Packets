namespace Core.QuickExtend.Tests.UriExtentions.Checks;

internal class IsWebResourceTests
{
    [Test]
    public void IsWebResource_WithHttpScheme_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act
        var result = uri.IsWebResource();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsWebResource_WithHttpsScheme_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("https://example.com");

        // Act
        var result = uri.IsWebResource();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsWebResource_WithFtpScheme_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("ftp://example.com");

        // Act
        var result = uri.IsWebResource();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsWebResource_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.IsWebResource());
    }
}
