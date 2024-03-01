namespace Core.QuickExtend.Tests.UriExtentions.Gets;

internal class GetFileNameTests
{
    [Test]
    public void GetFileName_WithFileName_ReturnsFileName()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/sample.txt");

        // Act
        var fileName = uri.GetFileName();

        // Assert
        Assert.AreEqual("sample.txt", fileName);
    }

    [Test]
    public void GetFileName_WithoutFileName_ReturnsEmptyString()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/");

        // Act
        var fileName = uri.GetFileName();

        // Assert
        Assert.AreEqual(string.Empty, fileName);
    }

    [Test]
    public void GetFileName_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetFileName());
    }
}
