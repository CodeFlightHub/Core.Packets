namespace Core.QuickExtend.Tests.StringExtensions.Converters;


internal class ToDateTimeTests
{
    [Test]
    public void ToDateTime_ValidInput_ShouldConvertSuccessfully()
    {
        // Arrange
        string input = "2022-01-28";
        DateTime expected = new DateTime(2022, 01, 28);

        // Act
        DateTime result = input.ToDateTime();

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void ToDateTime_InvalidInput_ShouldReturnDefaultValue()
    {
        // Arrange
        string input = "abc";
        DateTime defaultValue = DateTime.MinValue;

        // Act
        DateTime result = input.ToDateTime(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

    [Test]
    public void ToDateTime_DefaultValueProvided_ShouldReturnDefaultValueOnInvalidInput()
    {
        // Arrange
        string input = "xyz";
        DateTime defaultValue = new DateTime(2000, 01, 01);

        // Act
        DateTime result = input.ToDateTime(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }
}
