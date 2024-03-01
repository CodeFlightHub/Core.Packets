namespace Core.QuickExtend.Tests.UriExtentions.Gets;

internal class GetPhoneNumberTests
{
    [Test]
    public void GetPhoneNumber_ValidTelUri_ReturnsPhoneNumber()
    {
        // Arrange
        var uri = new Uri("tel:+1234567890");

        // Act
        var phoneNumber = uri.GetPhoneNumber();

        // Assert
        Assert.AreEqual("+1234567890", phoneNumber);
    }


    [Test]
    public void GetPhoneNumber_InvalidScheme_ThrowsInvalidOperationException()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => uri.GetPhoneNumber());
    }

    [Test]
    public void GetPhoneNumber_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetPhoneNumber());
    }
}
