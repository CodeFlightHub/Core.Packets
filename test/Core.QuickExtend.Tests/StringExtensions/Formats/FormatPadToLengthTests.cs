namespace Core.QuickExtend.Tests.StringExtensions.Formats;

internal class FormatPadToLengthTests
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
}
