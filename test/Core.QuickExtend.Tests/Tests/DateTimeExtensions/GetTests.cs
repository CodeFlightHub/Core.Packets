using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.DateTimeExtensions;

internal class GetTests
{
    [Test]
    public void GetDayOfWeekIndex_ConvertsValidDateTime_ReturnsDayOfWeekIndex()
    {
        // Arrange
        DateTime monday = new DateTime(2024, 2, 5); // Monday
        DateTime wednesday = new DateTime(2024, 2, 7); // Wednesday
        DateTime sunday = new DateTime(2024, 2, 11); // Sunday

        // Act
        int resultMonday = monday.GetDayOfWeekIndex();
        int resultWednesday = wednesday.GetDayOfWeekIndex();
        int resultSunday = sunday.GetDayOfWeekIndex();

        // Assert
        Assert.That(resultMonday, Is.EqualTo(1)); // Expecting Monday to have an index of 1
        Assert.That(resultWednesday, Is.EqualTo(3)); // Expecting Wednesday to have an index of 3
        Assert.That(resultSunday, Is.EqualTo(7)); // Expecting Sunday to have an index of 7
    }

    [Test]
    public void GetWeekOfMonth_ConvertsValidDateTime_ReturnsWeekOfMonth()
    {
        // Arrange
        DateTime dateInFirstWeek = new DateTime(2024, 1, 1); // A date in the first week
        DateTime dateInSecondWeek = new DateTime(2024, 1, 10); // A date in the second week
        DateTime dateInThirdWeek = new DateTime(2024, 1, 18); // A date in the third week
        DateTime dateInFourthWeek = new DateTime(2024, 1, 24); // A date in the fourth week

        // Act
        int resultFirstWeek = dateInFirstWeek.GetWeekOfMonth();
        int resultSecondWeek = dateInSecondWeek.GetWeekOfMonth();
        int resultThirdWeek = dateInThirdWeek.GetWeekOfMonth();
        int resultFourthWeek = dateInFourthWeek.GetWeekOfMonth();

        // Assert
        Assert.That(resultFirstWeek, Is.EqualTo(1)); // Expecting the date to be in the first week
        Assert.That(resultSecondWeek, Is.EqualTo(2)); // Expecting the date to be in the second week
        Assert.That(resultThirdWeek, Is.EqualTo(3)); // Expecting the date to be in the third week
        Assert.That(resultFourthWeek, Is.EqualTo(4)); // Expecting the date to be in the fourth week
    }

    [Test]
    public void GetYearQuarter_ConvertsValidDateTime_ReturnsQuarter()
    {
        // Arrange
        DateTime dateTimeQ1 = new DateTime(2024, 2, 7); // A date in the first quarter
        DateTime dateTimeQ2 = new DateTime(2024, 5, 15); // A date in the second quarter
        DateTime dateTimeQ3 = new DateTime(2024, 8, 22); // A date in the third quarter
        DateTime dateTimeQ4 = new DateTime(2024, 11, 30); // A date in the fourth quarter

        // Act
        int resultQ1 = dateTimeQ1.GetYearQuarter();
        int resultQ2 = dateTimeQ2.GetYearQuarter();
        int resultQ3 = dateTimeQ3.GetYearQuarter();
        int resultQ4 = dateTimeQ4.GetYearQuarter();

        // Assert
        Assert.That(resultQ1, Is.EqualTo(1)); // Expecting the first quarter
        Assert.That(resultQ2, Is.EqualTo(2)); // Expecting the second quarter
        Assert.That(resultQ3, Is.EqualTo(3)); // Expecting the third quarter
        Assert.That(resultQ4, Is.EqualTo(4)); // Expecting the fourth quarter
    }
}
