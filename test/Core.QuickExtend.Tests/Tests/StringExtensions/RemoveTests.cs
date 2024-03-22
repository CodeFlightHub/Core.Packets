namespace Core.QuickExtend.Tests.Tests.StringExtensions;

internal class RemoveTests
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

    [Test]
    public void RemoveSpaces_Should_Remove_Spaces_From_String()
    {
        // Arrange
        string input = "Hello World";

        // Act
        string result = input.RemoveSpaces();

        // Assert
        Assert.That(result, Is.EqualTo("HelloWorld"));
    }
}