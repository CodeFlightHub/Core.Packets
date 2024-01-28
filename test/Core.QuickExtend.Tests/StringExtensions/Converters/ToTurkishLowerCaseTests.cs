namespace Core.QuickExtend.Tests.StringExtensions.Converters;

internal class ToTurkishLowerCaseTests
{
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
