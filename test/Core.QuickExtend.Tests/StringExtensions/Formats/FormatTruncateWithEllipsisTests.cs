namespace Core.QuickExtend.Tests.StringExtensions.Formats;

internal class FormatTruncateWithEllipsisTests
{
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
