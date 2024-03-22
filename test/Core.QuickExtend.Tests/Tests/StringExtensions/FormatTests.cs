namespace Core.QuickExtend.Tests.Tests.StringExtensions;

internal class FormatTests
{
    [Test]
    public void FormatPadToLength_LeftAlign_ShouldPadFromLeft()
    {
        // Arrange
        string text = "Hello";
        int length = 10;
        char paddingChar = '-';
        bool alignLeft = true;

        // Act
        string result = text.FormatPadToLength(length, paddingChar, alignLeft);

        // Assert
        Assert.That(result, Is.EqualTo("Hello-----"));
    }

    [Test]
    public void FormatPadToLength_RightAlign_ShouldPadFromRight()
    {
        // Arrange
        string text = "Hello";
        int length = 10;
        char paddingChar = '-';
        bool alignLeft = false;

        // Act
        string result = text.FormatPadToLength(length, paddingChar, alignLeft);

        // Assert
        Assert.That(result, Is.EqualTo("-----Hello"));
    }

    [Test]
    public void FormatPadToLength_TextAlreadyEqualLength_ShouldReturnOriginalText()
    {
        // Arrange
        string text = "Hello";
        int length = 5;
        char paddingChar = '-';
        bool alignLeft = true;

        // Act
        string result = text.FormatPadToLength(length, paddingChar, alignLeft);

        // Assert
        Assert.That(result, Is.EqualTo("Hello"));
    }

    [Test]
    public void FormatPadToLength_TextLongerThanLength_ShouldReturnOriginalText()
    {
        // Arrange
        string text = "Hello";
        int length = 3;
        char paddingChar = '-';
        bool alignLeft = true;

        // Act
        string result = text.FormatPadToLength(length, paddingChar, alignLeft);

        // Assert
        Assert.That(result, Is.EqualTo("Hello"));
    }

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

    [Test]
    public void FormatTruncateWithEllipsis_TextShorterThanMaxLength_ShouldReturnOriginalText()
    {
        // Arrange
        string text = "Short Text";
        int maxLength = 50;

        // Act
        string result = text.FormatTruncateWithEllipsis(maxLength);

        // Assert
        Assert.That(result, Is.EqualTo("Short Text"));
    }

    [Test]
    public void FormatTruncateWithEllipsis_TextLongerThanMaxLength_ShouldReturnTruncatedTextWithEllipsis()
    {
        // Arrange
        string text = "This is a longer text that exceeds the maximum length.";
        int maxLength = 20;

        // Act
        string result = text.FormatTruncateWithEllipsis(maxLength);

        // Assert
        Assert.That(result, Is.EqualTo("This is a longer tex..."));
    }

    [Test]
    public void FormatTruncateWithEllipsis_EmptyText_ShouldReturnEmptyString()
    {
        // Arrange
        string text = "";

        // Act
        string result = text.FormatTruncateWithEllipsis();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }
}