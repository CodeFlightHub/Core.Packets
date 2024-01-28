namespace Core.QuickExtend.Tests.StringExtensions.Converters;

internal class ToTimeSpanTests
{
    [Test]
    public void ToTimeSpan_ValidInput_ShouldConvertSuccessfully()
    {
        // Arrange
        string input = "12:30:45";
        TimeSpan expected = new TimeSpan(12, 30, 45);

        // Act
        TimeSpan result = input.ToTimeSpan();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ToTimeSpan_InvalidInput_ShouldReturnDefaultValue()
    {
        // Arrange
        string input = "invalid";
        TimeSpan defaultValue = TimeSpan.FromHours(1);

        // Act
        TimeSpan result = input.ToTimeSpan(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

    [Test]
    public void ToTimeSpan_DefaultValueProvided_ShouldReturnDefaultValueOnInvalidInput()
    {
        // Arrange
        string input = "invalid";
        TimeSpan defaultValue = TimeSpan.FromMinutes(30);

        // Act
        TimeSpan result = input.ToTimeSpan(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }
}
