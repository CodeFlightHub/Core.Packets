using Core.QuickExtend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.DateTimeExtensions.Calculates;

internal class CalculateDateDifferenceTests
{
    [Test]
    public void CalculateDateDifference_ShouldReturnCorrectDays()
    {
        // Arrange
        DateTime startDate = new DateTime(2024, 2, 1);
        DateTime endDate = new DateTime(2024, 2, 10);

        // Act
        var daysDifference = startDate.CalculateDateDifference(endDate, TimeUnit.Days);

        // Assert
        Assert.That(daysDifference, Is.EqualTo(9)); // 10 - 1 = 9 days
    }

    [Test]
    public void CalculateDateDifference_ShouldReturnCorrectHours()
    {
        // Arrange
        DateTime startDate = new DateTime(2024, 2, 1, 12, 0, 0);
        DateTime endDate = new DateTime(2024, 2, 2, 12, 0, 0);

        // Act
        var hoursDifference = startDate.CalculateDateDifference(endDate, TimeUnit.Hours);

        // Assert
        Assert.That(hoursDifference, Is.EqualTo(24)); // 12:00 PM - 12:00 PM = 24 hours
    }

    [Test]
    public void CalculateDateDifference_ShouldReturnCorrectMinutes()
    {
        // Arrange
        DateTime startDate = new DateTime(2024, 2, 1, 12, 0, 0);
        DateTime endDate = new DateTime(2024, 2, 1, 12, 30, 0);

        // Act
        var minutesDifference = startDate.CalculateDateDifference(endDate, TimeUnit.Minutes);

        // Assert
        Assert.That(minutesDifference, Is.EqualTo(30));
    }
}
