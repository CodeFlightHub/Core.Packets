namespace Core.QuickExtend.Tests.StringExtensions.Adds;

internal class AddPrefixTests
{
    [Test]
    public void AddPrefix_IncludeSpaceTrue_ShouldAddPrefixWithSpace()
    {
        // Arrange
        string input = "world";
        string prefix = "hello";

        // Act
        string result = input.AddPrefix(prefix, includeSpace: true);

        // Assert
        Assert.That(result, Is.EqualTo("hello world"));
    }

    [Test]
    public void AddPrefix_IncludeSpaceFalse_ShouldAddPrefixWithoutSpace()
    {
        // Arrange
        string input = "world";
        string prefix = "hello";

        // Act
        string result = input.AddPrefix(prefix, includeSpace: false);

        // Assert
        Assert.That(result, Is.EqualTo("helloworld"));
    }

}
