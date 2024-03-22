using Core.QuickExtend.Tests.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.EnumExtensions;

internal class GetTests
{
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
