using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.DateTimeExtensions;

internal class GeneralTests
{
    [Test]
    public void DaysBetween_ValidDates_ReturnsCorrectNumberOfDays()
    {
        // Arrange
        DateTime startDate = new DateTime(2024, 2, 5);
        DateTime endDate = new DateTime(2024, 2, 10);

        // Action
        int result = startDate.DaysBetween(endDate);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void DaysBetween_SameDate_ReturnsZeroDays()
    {
        // Arrange
        DateTime sameDate = new DateTime(2024, 2, 7);

        // Action
        int result = sameDate.DaysBetween(sameDate);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void RandomDateInRange_ValidDates_ReturnsRandomDateWithinRange()
    {
        // Arrange
        DateTime startDate = new DateTime(2024, 2, 1);
        DateTime endDate = new DateTime(2024, 2, 10);

        // Act
        DateTime result = startDate.RandomDateInRange(endDate);

        // Assert
        Assert.GreaterOrEqual(result, startDate);
        Assert.LessOrEqual(result, endDate);
    }

    [Test]
    public void StartOfDay_ValidDate_ReturnsStartOfDay()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 2, 7, 14, 30, 0);

        // Action
        DateTime result = dateTime.StartOfDay();

        // Assert
        Assert.That(result, Is.EqualTo(new DateTime(2024, 2, 7, 0, 0, 0)));
    }
}
