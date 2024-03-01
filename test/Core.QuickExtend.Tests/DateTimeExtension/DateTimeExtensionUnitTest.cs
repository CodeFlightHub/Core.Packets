using Core.QuickExtend.Enums;

namespace Core.QuickExtend.Tests.DateTimeExtension;

internal class DateTimeExtensionUnitTest
{
    [Test]
    public void AddBusinessDays_PositiveValue_ShouldAddBusinessDays()
    {
        // Arrange
        DateTime startDate = new DateTime(2022, 1, 1);
        int businessDaysToAdd = 3;

        // Act
        DateTime result = startDate.AddBusinessDays(businessDaysToAdd);

        // Assert
        Assert.That(result, Is.EqualTo(new DateTime(2022, 1, 5)));
    }

    [Test]
    public void AddBusinessDays_NegativeValue_ShouldSubtractBusinessDays()
    {
        // Arrange
        DateTime startDate = new DateTime(2022, 1, 6);
        int businessDaysToAdd = -3;

        // Act
        DateTime result = startDate.AddBusinessDays(businessDaysToAdd);

        // Assert
        Assert.That(result, Is.EqualTo(new DateTime(2022, 1, 3)));
    }

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
