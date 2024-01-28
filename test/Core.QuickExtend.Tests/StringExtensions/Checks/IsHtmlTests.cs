namespace Core.QuickExtend.Tests.StringExtensions.Checks;

internal class IsHtmlTests
{
    [Test]
    public void IsHtml_StringContainsHtmlTags_ShouldReturnTrue()
    {
        // Arrange
        string input = "<p>This is HTML content</p>";

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsHtml_StringDoesNotContainHtmlTags_ShouldReturnFalse()
    {
        // Arrange
        string input = "This is plain text";

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsHtml_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsHtml_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsFalse(result);
    }
}
