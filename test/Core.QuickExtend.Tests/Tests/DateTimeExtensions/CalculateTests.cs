using Core.QuickExtend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.DateTimeExtensions;

internal class CalculateTests
{
    [Test]
    public void CalculateAge_ShouldReturnCorrectAge()
    {
        // Arrange
        DateTime birthDate = new DateTime(1990, 1, 1);

        // Act
        var age = birthDate.CalculateAge();

        // Assert
        Assert.That(age, Is.EqualTo(34)); // 2024 - 1990 = 34
    }

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

    [Test]
    public void CalculateMonthsBetween_ShouldReturnZero_WhenDatesAreSame()
    {
        // Arrange
        DateTime startDate = new DateTime(2024, 2, 1);
        DateTime endDate = new DateTime(2024, 2, 1);

        // Act
        var monthsBetween = startDate.CalculateMonthsBetween(endDate);

        // Assert
        Assert.That(monthsBetween, Is.EqualTo(0));
    }

    [Test]
    public void CalculateMonthsBetween_ShouldReturnOne_WhenDatesAreOneMonthApart()
    {
        // Arrange
        DateTime startDate = new DateTime(2024, 2, 1);
        DateTime endDate = new DateTime(2024, 3, 1);

        // Act
        var monthsBetween = startDate.CalculateMonthsBetween(endDate);

        // Assert
        Assert.That(monthsBetween, Is.EqualTo(1));
    }

    [Test]
    public void CalculateMonthsBetween_ShouldReturnTwelve_WhenDatesAreOneYearApart()
    {
        // Arrange
        DateTime startDate = new DateTime(2023, 2, 1);
        DateTime endDate = new DateTime(2024, 2, 1);

        // Act
        var monthsBetween = startDate.CalculateMonthsBetween(endDate);

        // Assert
        Assert.That(monthsBetween, Is.EqualTo(12));
    }

    [Test]
    public void CalculateWeeksBetween_ShouldReturnZero_WhenDatesAreSame()
    {
        // Arrange
        DateTime startDate = new DateTime(2022, 2, 1);
        DateTime endDate = new DateTime(2022, 2, 1);

        // Act
        var weeksBetween = startDate.CalculateWeeksBetween(endDate);

        // Assert
        Assert.That(weeksBetween, Is.EqualTo(0));
    }

    [Test]
    public void CalculateWeeksBetween_ShouldReturnOne_WhenDatesAreOneWeekApart()
    {
        // Arrange
        DateTime startDate = new DateTime(2022, 2, 1);
        DateTime endDate = new DateTime(2022, 2, 8);

        // Act
        var weeksBetween = startDate.CalculateWeeksBetween(endDate);

        // Assert
        Assert.That(weeksBetween, Is.EqualTo(1));
    }

    [Test]
    public void CalculateWeeksBetween_ShouldReturnTwo_WhenDatesAreTwoWeeksApart()
    {
        // Arrange
        DateTime startDate = new DateTime(2022, 2, 1);
        DateTime endDate = new DateTime(2022, 2, 15);

        // Act
        var weeksBetween = startDate.CalculateWeeksBetween(endDate);

        // Assert
        Assert.That(weeksBetween, Is.EqualTo(2));
    }
}
