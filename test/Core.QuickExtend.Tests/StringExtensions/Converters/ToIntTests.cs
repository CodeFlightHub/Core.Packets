namespace Core.QuickExtend.Tests.StringExtensions.Converters;

internal class ToIntTests
{
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
}