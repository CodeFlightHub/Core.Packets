namespace Core.QuickExtend.Tests.UriExtentions.Gets;

internal class GetEmailAddressTests
{
    [Test]
    public void GetEmailAddress_ValidMailtoUri_ReturnsEmailAddress()
    {
        // Arrange
        var uri = new Uri("mailto:test@example.com");

        // Act
        var emailAddress = uri.GetEmailAddress();

        // Assert
        Assert.AreEqual("test@example.com", emailAddress);
    }

    [Test]
    public void GetEmailAddress_InvalidScheme_ThrowsInvalidOperationException()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => uri.GetEmailAddress());
    }

    [Test]
    public void GetEmailAddress_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetEmailAddress());
    }
}
