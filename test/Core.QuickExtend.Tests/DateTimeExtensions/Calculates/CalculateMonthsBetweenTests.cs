using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.DateTimeExtensions.Calculates;

internal class CalculateMonthsBetweenTests
{
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
}
