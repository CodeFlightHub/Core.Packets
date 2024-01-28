namespace Core.QuickExtend.Tests.StringExtensions.Contains;

internal class ContainsOnlyLettersTests
{
    [Test]
    public void ContainsOnlyLetters_OnlyAlphabeticalCharacters_ShouldReturnTrue()
    {
        // Arrange
        string input = "ABCDE";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsOnlyLetters_NonAlphabeticalCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC123";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyLetters_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyLetters_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyLetters_MixedCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC123";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }
}
