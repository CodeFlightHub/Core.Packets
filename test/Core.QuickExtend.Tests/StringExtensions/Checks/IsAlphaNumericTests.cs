
namespace Core.QuickExtend.Tests.StringExtensions.Checks;

internal class IsAlphaNumericTests
{
    [Test]
    public void IsAlphaNumeric_ValidAlphaNumericString_ShouldReturnTrue()
    {
        // Arrange
        string input = "ABC13";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsAlphaNumeric_InvalidStringWithSpecialCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC123!";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsAlphaNumeric_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsAlphaNumeric_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsAlphaNumeric_WhitespaceInput_ShouldReturnFalse()
    {
        // Arrange
        string input = "   ";

        // Act
        bool result = input.IsAlphaNumeric();

        // Assert
        Assert.IsFalse(result);
    }
}
