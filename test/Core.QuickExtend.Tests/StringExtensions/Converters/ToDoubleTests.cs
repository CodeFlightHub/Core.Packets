namespace Core.QuickExtend.Tests.StringExtensions.Converters;

internal class ToDoubleTests
{
    [Test]
    public void ToDouble_ValidInput_ShouldConvertSuccessfully()
    {
        // Arrange
        string input = "123.45";
        double expected = 123.45;

        // Act
        double result = input.ToDouble();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ToDouble_InvalidInput_ShouldReturnDefaultValue()
    {
        // Arrange
        string input = "abc";
        double defaultValue = 0.0;

        // Act
        double result = input.ToDouble(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

    [Test]
    public void ToDouble_DefaultValueProvided_ShouldReturnDefaultValueOnInvalidInput()
    {
        // Arrange
        string input = "xyz";
        double defaultValue = 99.99;

        // Act
        double result = input.ToDouble(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }
}
