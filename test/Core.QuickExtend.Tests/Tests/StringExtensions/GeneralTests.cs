using Core.QuickExtend.Tests.Infrastructure.Enums;

namespace Core.QuickExtend.Tests.Tests.StringExtensions;

internal class GeneralTests
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

    [Test]
    public void ParseFromString_ValidValue_ShouldReturnEnumItem()
    {
        // Arrange
        string validValue = "Value2";

        // Act
        SampleEnum result = validValue.ParseFromString<SampleEnum>();

        // Assert
        Assert.That(result, Is.EqualTo(SampleEnum.Value2));
    }

    [Test]
    public void ParseFromString_InvalidValue_ShouldReturnDefaultEnumItem()
    {
        // Arrange
        string invalidValue = "InvalidValue";

        // Act
        SampleEnum result = invalidValue.ParseFromString<SampleEnum>();

        // Assert
        Assert.That(result, Is.EqualTo(default(SampleEnum)));
    }

    [Test]
    public void ParseFromString_CaseInsensitiveValidValue_ShouldReturnEnumItem()
    {
        // Arrange
        string validValue = "value3";

        // Act
        SampleEnum result = validValue.ParseFromString<SampleEnum>();

        // Assert
        Assert.That(result, Is.EqualTo(SampleEnum.Value3));
    }

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