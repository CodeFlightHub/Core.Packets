namespace Core.QuickExtend.Tests.StringExtensions.Contains;

internal class ContainsNumericTests
{
    [Test]
    public void ContainsNumeric_ContainsNumericCharacters_ShouldReturnTrue()
    {
        // Arrange
        string input = "ABC123";

        // Act
        bool result = input.ContainsNumeric();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsNumeric_NoNumericCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC";

        // Act
        bool result = input.ContainsNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsNumeric_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.ContainsNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsNumeric_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.ContainsNumeric();

        // Assert
        Assert.IsFalse(result);
    }
}
