namespace Core.QuickExtend.Tests.StringExtensions.Removes;

internal class RemoveDuplicateCharactersTests
{
    [Test]
    public void RemoveDuplicateCharacters_NoDuplicates_ShouldReturnSameString()
    {
        // Arrange
        string input = "abcdef";

        // Act
        string result = input.RemoveDuplicateCharacters();

        // Assert
        Assert.That(result, Is.EqualTo(input));
    }

    [Test]
    public void RemoveDuplicateCharacters_WithDuplicates_ShouldRemoveDuplicates()
    {
        // Arrange
        string input = "aabbcc";

        // Act
        string result = input.RemoveDuplicateCharacters();

        // Assert
        Assert.That(result, Is.EqualTo("abc"));
    }

    [Test]
    public void RemoveDuplicateCharacters_EmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string input = "";

        // Act
        string result = input.RemoveDuplicateCharacters();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }
}

