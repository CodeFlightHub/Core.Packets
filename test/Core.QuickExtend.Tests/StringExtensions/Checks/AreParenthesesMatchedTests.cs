namespace Core.QuickExtend.Tests.StringExtensions.Checks;

internal class AreParenthesesMatchedTests
{
    [Test]
    public void AreParenthesesMatched_ValidInput_ShouldReturnTrue()
    {
        // Arrange
        string input = "((a + b) * (c - d))";

        // Act
        bool result = input.AreParenthesesMatched();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void AreParenthesesMatched_InvalidInput_ShouldReturnFalse()
    {
        // Arrange
        string input = "((a + b) * (c - d)";

        // Act
        bool result = input.AreParenthesesMatched();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void AreParenthesesMatched_EmptyInput_ShouldReturnTrue()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.AreParenthesesMatched();

        // Assert
        Assert.IsTrue(result);
    }
}
