namespace Core.QuickExtend.Tests.Tests.StringExtensions;

internal class CheckTests
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

    [Test]
    public void IsEmail_ValidEmailAddress_ShouldReturnTrue()
    {
        // Arrange
        string input = "serhatkacmaz3@gmail.com";

        // Act
        bool result = input.IsEmail();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsEmail_InvalidEmailAddress_ShouldReturnFalse()
    {
        // Arrange
        string input = "invalid-email";

        // Act
        bool result = input.IsEmail();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsEmail_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.IsEmail();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsHtml_StringContainsHtmlTags_ShouldReturnTrue()
    {
        // Arrange
        string input = "<p>This is HTML content</p>";

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsHtml_StringDoesNotContainHtmlTags_ShouldReturnFalse()
    {
        // Arrange
        string input = "This is plain text";

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsHtml_NullInput_ShouldReturnFalse()
    {
        // Arrange
        string? input = null;

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsHtml_EmptyString_ShouldReturnFalse()
    {
        // Arrange
        string input = "";

        // Act
        bool result = input.IsHtml();

        // Assert
        Assert.IsFalse(result);
    }
}