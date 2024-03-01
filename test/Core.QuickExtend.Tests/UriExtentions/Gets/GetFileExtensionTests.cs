namespace Core.QuickExtend.Tests.UriExtentions.Gets;

internal class GetFileExtensionTests
{
    [Test]
    public void GetFileExtension_WithExtension_ReturnsExtension()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/sample.txt");

        // Act
        var fileExtension = uri.GetFileExtension();

        // Assert
        Assert.AreEqual(".txt", fileExtension);
    }

    [Test]
    public void GetFileExtension_WithoutExtension_ReturnsEmptyString()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/sample");

        // Act
        var fileExtension = uri.GetFileExtension();

        // Assert
        Assert.AreEqual(string.Empty, fileExtension);
    }

    [Test]
    public void GetFileExtension_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetFileExtension());
    }
}
