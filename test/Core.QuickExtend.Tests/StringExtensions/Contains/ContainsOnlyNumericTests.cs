namespace Core.QuickExtend.Tests.StringExtensions.Contains;

internal class ContainsOnlyNumericTests
{

    [Test]
    public void ContainsOnlyNumeric_OnlyNumericCharacters_ShouldReturnTrue()
    {
        // Arrange
        string input = "12345";

        // Act
        bool result = input.ContainsOnlyNumeric();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsOnlyNumeric_NonNumericCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC123";

        // Act
        bool result = input.ContainsOnlyNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyNumeric_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.ContainsOnlyNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyNumeric_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.ContainsOnlyNumeric();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyNumeric_MixedCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "123ABC";

        // Act
        bool result = input.ContainsOnlyNumeric();

        // Assert
        Assert.IsFalse(result);
    }
}
