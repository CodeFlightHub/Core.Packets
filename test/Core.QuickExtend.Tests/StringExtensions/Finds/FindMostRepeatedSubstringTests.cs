namespace Core.QuickExtend.Tests.StringExtensions.Finds;

internal class FindMostRepeatedSubstringTests
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
}
