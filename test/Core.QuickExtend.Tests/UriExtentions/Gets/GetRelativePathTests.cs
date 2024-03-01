namespace Core.QuickExtend.Tests.UriExtentions.Gets;

internal class GetRelativePathTests
{
    [Test]
    public void GetRelativePath_AbsoluteUri_ReturnsPathAndQuery()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2");

        // Act
        var relativePath = uri.GetRelativePath();

        // Assert
        Assert.AreEqual("/api/resource?page=2", relativePath);
    }

    [Test]
    public void GetRelativePath_RelativeUri_ReturnsOriginalString()
    {
        // Arrange
        var uri = new Uri("/api/resource", UriKind.Relative);

        // Act
        var relativePath = uri.GetRelativePath();

        // Assert
        Assert.AreEqual("/api/resource", relativePath);
    }

    [Test]
    public void GetRelativePath_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetRelativePath());
    }
}
