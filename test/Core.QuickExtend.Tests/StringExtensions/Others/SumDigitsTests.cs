namespace Core.QuickExtend.Tests.StringExtensions.Others;

public class SumDigitsTests
{
    [Test]
    public void SumDigits_WhenGivenStringWithDigits_ReturnsSumOfDigits()
    {
        // Arrange
        string input = "abc123def45";

        // Action
        int result = input.SumDigits();

        // Assert
        Assert.That(result, Is.EqualTo(15));
    }

    [Test]
    public void SumDigits_WhenGivenStringWithoutDigits_ReturnsZero()
    {
        // Arrange
        string input = "abcxyz";

        // Action
        int result = input.SumDigits();

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }
}