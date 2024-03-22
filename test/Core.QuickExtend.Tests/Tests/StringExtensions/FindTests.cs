namespace Core.QuickExtend.Tests.Tests.StringExtensions;

internal class FindTests
{
    [Test]
    public void FindMostRepeatedSubstring_ValidInput_ShouldReturnMostRepeatedSubstring()
    {
        // Arrange
        string input = "abcabcabcdabcd";

        // Act
        string result = input.FindMostRepeatedSubstring(3);

        // Assert
        Assert.That(result, Is.EqualTo("abc"));
    }

    [Test]
    public void FindMostRepeatedSubstring_SubstringLengthGreaterThanInputLength_ShouldThrowArgumentException()
    {
        // Arrange
        string input = "abcdef";
        int subStringLength = 10;

        // Act and Assert
        Assert.Throws<ArgumentException>(() => input.FindMostRepeatedSubstring(subStringLength));
    }

    [Test]
    public void FindMostRepeatedSubstring_SubstringLengthZero_ShouldThrowArgumentException()
    {
        // Arrange
        string input = "abcdef";
        int subStringLength = 0;

        // Act and Assert
        Assert.Throws<ArgumentException>(() => input.FindMostRepeatedSubstring(subStringLength));
    }

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