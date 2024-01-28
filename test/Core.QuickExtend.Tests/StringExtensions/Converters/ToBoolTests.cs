namespace Core.QuickExtend.Tests.StringExtensions.Converters;

internal class ToBoolTests
{
    [Test]
    public void ToBool_ValidTrueInput_ShouldConvertSuccessfully()
    {
        // Arrange
        string input = "true";
        bool expected = true;

        // Act
        bool result = input.ToBool();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ToBool_ValidFalseInput_ShouldConvertSuccessfully()
    {
        // Arrange
        string input = "false";
        bool expected = false;

        // Act
        bool result = input.ToBool();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ToBool_InvalidInput_ShouldReturnDefaultValue()
    {
        // Arrange
        string input = "invalid";
        bool defaultValue = true;

        // Act
        bool result = input.ToBool(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }
}
