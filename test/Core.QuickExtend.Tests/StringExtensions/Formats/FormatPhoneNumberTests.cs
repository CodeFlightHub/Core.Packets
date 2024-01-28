namespace Core.QuickExtend.Tests.StringExtensions.Formats;

internal class FormatPhoneNumberTests
{
    [Test]
    public void FormatPhoneNumber_DefaultFormat_ShouldReturnFormattedPhoneNumber()
    {
        // Arrange
        string phoneNumber = "1234567890";

        // Act
        string? result = phoneNumber.FormatPhoneNumber();

        // Assert
        Assert.That(result, Is.EqualTo("0(123)-456-78-90"));
    }

    [Test]
    public void FormatPhoneNumber_CustomFormat_ShouldReturnFormattedPhoneNumberWithCustomFormat()
    {
        // Arrange
        string phoneNumber = "9876543210";
        string customFormat = "0-XXX-XXXX-XXX";

        // Act
        string? result = phoneNumber.FormatPhoneNumber(customFormat);

        // Assert
        Assert.That(result, Is.EqualTo("0-987-6543-210"));
    }

    [Test]
    public void FormatPhoneNumber_EmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string phoneNumber = "";

        // Act
        string? result = phoneNumber.FormatPhoneNumber();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void FormatPhoneNumber_NullInput_ShouldReturnEmptyString()
    {
        // Arrange
        string? phoneNumber = null;

        // Act
        string? result = phoneNumber.FormatPhoneNumber();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }
}
