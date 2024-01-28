namespace Core.QuickExtend.Tests.StringExtensions.Finds;

internal class FindMostRepeatedWordTests
{
    [Test]
    public void FindMostRepeatedWord_SingleWord_ShouldReturnSameWord()
    {
        // Arrange
        string input = "apple";

        // Act
        string result = input.FindMostRepeatedWord();

        // Assert
        Assert.That(result, Is.EqualTo("apple"));
    }

    [Test]
    public void FindMostRepeatedWord_MultipleWords_ShouldReturnMostRepeatedWord()
    {
        // Arrange
        string input = "apple banana orange banana apple apple";

        // Act
        string result = input.FindMostRepeatedWord();

        // Assert
        Assert.That(result, Is.EqualTo("apple"));
    }

    [Test]
    public void FindMostRepeatedWord_EmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string input = "";

        // Act
        string result = input.FindMostRepeatedWord();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

}
