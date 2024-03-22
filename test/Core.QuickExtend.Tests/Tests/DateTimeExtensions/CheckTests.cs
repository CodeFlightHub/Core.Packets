using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.DateTimeExtensions;

internal class CheckTests
{
    [Test]
    public void IsBetween_Inclusive_StartAndEndDates_ReturnsTrue()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15);
        DateTime start = new DateTime(2024, 1, 1);
        DateTime end = new DateTime(2024, 1, 31);

        // Action
        bool result = dateTime.IsBetween(start, end);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsBetween_Inclusive_StartAndEndDates_ReturnsFalse()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 2, 15);
        DateTime start = new DateTime(2024, 1, 1);
        DateTime end = new DateTime(2024, 1, 31);

        // Action
        bool result = dateTime.IsBetween(start, end);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsBetween_Exclusive_StartAndEndDates_ReturnsTrue()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15);
        DateTime start = new DateTime(2024, 1, 1);
        DateTime end = new DateTime(2024, 1, 31);

        // Action
        bool result = dateTime.IsBetween(start, end, inclusive: false);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsBetween_Exclusive_StartAndEndDates_ReturnsFalse()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 31);
        DateTime start = new DateTime(2024, 1, 1);
        DateTime end = new DateTime(2024, 1, 31);

        // Action
        bool result = dateTime.IsBetween(start, end, inclusive: false);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsBetween_Inclusive_TimeRange_ReturnsTrue()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15, 12, 30, 0);
        DateTime start = new DateTime(2024, 1, 15, 10, 0, 0);
        DateTime end = new DateTime(2024, 1, 15, 15, 0, 0);

        // Action
        bool result = dateTime.IsBetween(start, end, "HH:mm:ss", inclusive: true);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsBetween_Inclusive_TimeRange_ReturnsFalse()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15, 16, 0, 0);
        DateTime start = new DateTime(2024, 1, 15, 10, 0, 0);
        DateTime end = new DateTime(2024, 1, 15, 15, 0, 0);

        // Action
        bool result = dateTime.IsBetween(start, end, "HH:mm:ss", inclusive: true);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsBetween_Exclusive_TimeRange_ReturnsTrue()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15, 14, 30, 0);
        DateTime start = new DateTime(2024, 1, 15, 10, 0, 0);
        DateTime end = new DateTime(2024, 1, 15, 15, 0, 0);

        // Action
        bool result = dateTime.IsBetween(start, end, "HH:mm:ss", inclusive: false);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsBetween_Exclusive_TimeRange_ReturnsFalse()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15, 15, 0, 0);
        DateTime start = new DateTime(2024, 1, 15, 10, 0, 0);
        DateTime end = new DateTime(2024, 1, 15, 15, 0, 0);

        // Action
        bool result = dateTime.IsBetween(start, end, "HH:mm:ss", inclusive: false);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsBusinessDay_Weekday_ReturnsTrue()
    {
        // Arrange
        DateTime weekday = new DateTime(2024, 2, 7);

        // Action
        bool result = weekday.IsBusinessDay();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsBusinessDay_Saturday_ReturnsFalse()
    {
        // Arrange
        DateTime saturday = new DateTime(2024, 2, 10);

        // Action
        bool result = saturday.IsBusinessDay();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsBusinessDay_Sunday_ReturnsFalse()
    {
        // Arrange
        DateTime sunday = new DateTime(2024, 2, 11);

        // Action
        bool result = sunday.IsBusinessDay();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsLunchTime_LunchTime_ReturnsTrue()
    {
        // Arrange
        DateTime lunchTime = new DateTime(2024, 2, 7, 12, 0, 0); // 12:00 PM

        // Action
        bool result = lunchTime.IsLunchTime();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsLunchTime_NotLunchTime_ReturnsFalse()
    {
        // Arrange
        DateTime notLunchTime = new DateTime(2024, 2, 7, 15, 30, 0); // 3:30 PM

        // Action
        bool result = notLunchTime.IsLunchTime();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsMidnight_Midnight_ReturnsTrue()
    {
        // Arrange
        DateTime midnight = new DateTime(2024, 2, 7, 0, 0, 0); // 00:00 AM

        // Action
        bool result = midnight.IsMidnight();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsMidnight_NotMidnight_ReturnsFalse()
    {
        // Arrange
        DateTime notMidnight = new DateTime(2024, 2, 7, 15, 30, 0); // 3:30 PM

        // Action
        bool result = notMidnight.IsMidnight();

        // Assert
        Assert.IsFalse(result);
    }


    [Test]
    public void IsPastDate_DateInPast_ReturnsTrue()
    {
        // Arrange
        DateTime pastDate = DateTime.Now.AddDays(-1);

        // Action
        bool result = pastDate.IsPastDate();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsPastDate_DateInFuture_ReturnsFalse()
    {
        // Arrange
        DateTime futureDate = DateTime.Now.AddDays(1);

        // Action
        bool result = futureDate.IsPastDate();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsWeekday_Weekday_ReturnsTrue()
    {
        // Arrange
        DateTime weekday = new DateTime(2024, 2, 7);

        // Action
        bool result = weekday.IsWeekday();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsWeekday_Saturday_ReturnsFalse()
    {
        // Arrange
        DateTime saturday = new DateTime(2024, 2, 10);

        // Action
        bool result = saturday.IsWeekday();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsWeekday_Sunday_ReturnsFalse()
    {
        // Arrange
        DateTime sunday = new DateTime(2024, 2, 11);

        // Action
        bool result = sunday.IsWeekday();

        // Assert
        Assert.IsFalse(result);
    }
}
