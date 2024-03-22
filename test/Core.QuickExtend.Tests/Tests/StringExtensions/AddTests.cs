using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.StringExtensions;

internal class AddTests
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
