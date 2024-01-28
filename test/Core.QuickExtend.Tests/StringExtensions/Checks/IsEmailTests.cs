namespace Core.QuickExtend.Tests.StringExtensions.Checks;

internal class IsEmailTests
{
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

}
