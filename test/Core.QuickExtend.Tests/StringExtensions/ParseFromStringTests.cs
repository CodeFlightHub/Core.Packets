using Core.QuickExtend.StringExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.StringExtensions;

internal class ParseFromStringTests
{
    public enum SampleEnum
    {
        Value1,
        Value2,
        Value3
    }

    [Test]
    public void ParseFromString_ValidValue_ShouldReturnEnumItem()
    {
        // Arrange
        string validValue = "Value2";

        // Act
        SampleEnum result = validValue.ParseFromString<SampleEnum>();

        // Assert
        Assert.That(result, Is.EqualTo(SampleEnum.Value2));
    }

    [Test]
    public void ParseFromString_InvalidValue_ShouldReturnDefaultEnumItem()
    {
        // Arrange
        string invalidValue = "InvalidValue";

        // Act
        SampleEnum result = invalidValue.ParseFromString<SampleEnum>();

        // Assert
        Assert.That(result, Is.EqualTo(default(SampleEnum)));
    }

    [Test]
    public void ParseFromString_CaseInsensitiveValidValue_ShouldReturnEnumItem()
    {
        // Arrange
        string validValue = "value3";

        // Act
        SampleEnum result = validValue.ParseFromString<SampleEnum>();

        // Assert
        Assert.That(result, Is.EqualTo(SampleEnum.Value3));
    }
}
