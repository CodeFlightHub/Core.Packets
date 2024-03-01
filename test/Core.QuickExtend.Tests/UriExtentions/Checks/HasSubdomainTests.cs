namespace Core.QuickExtend.Tests.UriExtentions.Checks;

internal class HasSubdomainTests
{
    [Test]
    public void HasSubdomain_WithSubdomain_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("http://sub.example.com/api/resource");

        // Act
        var hasSubdomain = uri.HasSubdomain("sub");

        // Assert
        Assert.IsTrue(hasSubdomain);
    }

    [Test]
    public void HasSubdomain_WithoutSubdomain_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var hasSubdomain = uri.HasSubdomain("sub");

        // Assert
        Assert.IsFalse(hasSubdomain);
    }

    [Test]
    public void HasSubdomain_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.HasSubdomain("sub"));
    }

    [Test]
    public void HasSubdomain_EmptySubdomain_ThrowsArgumentException()
    {
        // Arrange
        var uri = new Uri("http://sub.example.com/api/resource");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => uri.HasSubdomain(""));
    }
}
