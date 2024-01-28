namespace Core.QuickExtend.Tests.StringExtensions.Removes;

internal class RemoveSpacesTests
{
    [Test]
    public void RemoveSpaces_Should_Remove_Spaces_From_String()
    {
        // Arrange
        string input = "Hello World";

        // Act
        string result = input.RemoveSpaces();

        // Assert
        Assert.That(result, Is.EqualTo("HelloWorld"));
    }
}
