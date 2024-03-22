namespace Core.QuickExtend.Tests.Tests.StringExtensions;

internal class ContainsTests
{
    [Test]
    public void ContainsLetter_StringContainsLetters_ShouldReturnTrue()
    {
        // Arrange
        string input = "a123";

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsLetter_NoLetters_ShouldReturnFalse()
    {
        // Arrange
        string input = "123456";

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsLetter_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsLetter_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.ContainsLetter();

        // Assert
        Assert.IsFalse(result);
    }

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
    [Test]
    public void ContainsOnlyLetters_OnlyAlphabeticalCharacters_ShouldReturnTrue()
    {
        // Arrange
        string input = "ABCDE";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void ContainsOnlyLetters_NonAlphabeticalCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC123";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyLetters_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyLetters_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void ContainsOnlyLetters_MixedCharacters_ShouldReturnFalse()
    {
        // Arrange
        string input = "ABC123";

        // Act
        bool result = input.ContainsOnlyLetters();

        // Assert
        Assert.IsFalse(result);
    }

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