namespace Core.QuickExtend.Tests.StringExtensions.Adds;

internal class AddSuffixTests
{
    [Test]
    public void AddSuffix_IncludeSpaceTrue_ShouldAddSuffixWithSpace()
    {
        // Arrange
        string input = "hello";
        string suffix = "world";

        // Act
        string result = input.AddSuffix(suffix, includeSpace: true);

        // Assert
        Assert.That(result, Is.EqualTo("hello world"));
    }

    [Test]
    public void AddSuffix_IncludeSpaceFalse_ShouldAddSuffixWithoutSpace()
    {
        // Arrange
        string input = "hello";
        string suffix = "world";

        // Act
        string result = input.AddSuffix(suffix, includeSpace: false);

        // Assert
        Assert.That(result, Is.EqualTo("helloworld"));
    }
}
