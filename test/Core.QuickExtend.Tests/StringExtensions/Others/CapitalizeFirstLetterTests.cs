namespace Core.QuickExtend.Tests.StringExtensions.Others;

internal class CapitalizeFirstLetterTests
{
    [Test]
    public void CapitalizeFirstLetter_ValidInput_ShouldCapitalizeFirstLetterOfEachWord()
    {
        // Arrange
        string input = "hello world";

        // Act
        string? result = input.CapitalizeFirstLetter();

        // Assert
        Assert.That(result, Is.EqualTo("Hello World"));
    }

    [Test]
    public void CapitalizeFirstLetter_EmptyInput_ShouldReturnEmptyString()
    {
        // Arrange
        string input = "";

        // Act
        string? result = input.CapitalizeFirstLetter();

        // Assert
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void CapitalizeFirstLetter_NullInput_ShouldReturnNull()
    {
        // Arrange
        string? input = null;

        // Act
        string? result = input.CapitalizeFirstLetter();

        // Assert
        Assert.IsNull(result);
    }
}
