using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.DateTimeExtensions;

internal class ConverterTests
{
    [Test]
    public void ToMinutesOfDay_ConvertsValidDateTime_ReturnsTotalMinutes()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 2, 7, 14, 30, 0); // 2:30 PM

        // Action
        int result = dateTime.ToMinutesOfDay();

        // Assert
        Assert.That(result, Is.EqualTo(14 * 60 + 30));
    }
}
