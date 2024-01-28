namespace Core.QuickExtend.Tests.StringExtensions.Contains;

internal class ContainsLetterTests
{
    [Test]
    public void ContainsLetter_StringContainsLetters_ShouldReturnTrue()
    {
        // Arrange
        string input = "a123";

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsLetter_NoLetters_ShouldReturnFalse()
    {
        // Arrange
        string input = "123456";

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsLetter_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsLetter_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsFalse(result);
    }
}
