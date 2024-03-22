namespace Core.QuickExtend.Tests.Tests.StringExtensions;

internal class ConverterTests
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

    [Test]
    public void ToInt_Should_Convert_String_To_Integer()
    {
        // Arrange
        string input = "123";

        // Act
        int result = input.ToInt();

        // Assert
        Assert.That(result, Is.EqualTo(123));
    }

    [Test]
    public void ToInt_Should_Return_Default_Value_If_Conversion_Fails()
    {
        // Arrange
        string input = "abc";

        // Act
        int result = input.ToInt();

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void ToInt_Should_Return_Custom_Default_Value_If_Conversion_Fails()
    {
        // Arrange
        string input = "abc";
        int defaultValue = -1;

        // Act
        int result = input.ToInt(defaultValue);

        // Assert
        Assert.That(result, Is.EqualTo(defaultValue));
    }

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

    [Test]
    public void ToTurkishLowerCase_Should_Convert_String_To_Lowercase_With_Turkish_Character_Sensitivity()
    {
        // Arrange
        string input = "Merhaba Dünya";

        // Act
        string result = input.ToTurkishLowerCase();

        // Assert
        Assert.That(result, Is.EqualTo("merhaba dünya"));
    }

    [Test]
    public void ToTurkishLowerCase_Should_Handle_Empty_String()
    {
        // Arrange
        string input = string.Empty;

        // Act
        string result = input.ToTurkishLowerCase();

        // Assert
        Assert.That(result, Is.EqualTo(string.Empty));
    }
}