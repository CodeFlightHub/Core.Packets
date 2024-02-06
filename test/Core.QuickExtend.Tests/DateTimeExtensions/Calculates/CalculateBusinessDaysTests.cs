using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.DateTimeExtensions.Calculates;

internal class CalculateBusinessDaysTests
{
    [Test]
    public void CalculateBusinessDays_ShouldReturnCorrectBusinessDays_WeekdayOnly()
    {
        // Arrange
        DateTime startDate = new DateTime(2024, 1, 20);
        DateTime endDate = new DateTime(2024, 1, 22);

        // Act
        var businessDays = startDate.CalculateBusinessDays(endDate);

        // Assert
        Assert.That(businessDays, Is.EqualTo(1));
    }
}
