using Core.QuickExtend.EnumExtensions.Gets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.EnumExtensions.Gets;

internal class GetDisplayNameTests
{
    public enum SampleEnum
    {
        [Display(Name = "Description of Value1")]
        Value1,

        [Display(Name = "Description of Value2")]
        Value2,

        Value3
    }

    [Test]
    public void GetDisplayName_WithDisplayAttribute_ShouldReturnDisplay()
    {
        // Arrange
        SampleEnum enumValue = SampleEnum.Value1;

        // Act
        string displayName = enumValue.GetDisplayName();

        // Assert
        Assert.That(displayName, Is.EqualTo("Description of Value1"));
    }

    [Test]
    public void GetDisplayName_WithoutDisplayAttribute_ShouldReturnEnumName()
    {
        // Arrange
        SampleEnum enumValue = SampleEnum.Value3;

        // Act
        string displayName = enumValue.GetDisplayName();

        // Assert
        Assert.That(displayName, Is.EqualTo("Value3"));
    }
}
