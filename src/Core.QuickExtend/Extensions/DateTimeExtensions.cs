using Core.QuickExtend.Enums;

namespace Core.QuickExtend.Extensions;

public static class DateTimeExtensions
{
    /// <summary>
    /// Calculates the number of days between two dates.
    /// </summary>
    /// <param name="startDate">Start date.</param>
    /// <param name="endDate">End date.</param>
    /// <returns>Number of days.</returns>
    public static int DaysBetween(this DateTime startDate, DateTime endDate)
    {
        return (endDate - startDate).Days;
    }

    /// <summary>
    /// Checks if a date is within a specified time range.
    /// </summary>
    /// <param name="dateTime">Date to be checked.</param>
    /// <param name="start">Start date.</param>
    /// <param name="end">End date.</param>
    /// <returns>True if the date is within the specified time range; otherwise, false.</returns>
    public static bool IsBetween(this DateTime dateTime, DateTime start, DateTime end)
    {
        return dateTime >= start && dateTime <= end;
    }

    /// <summary>
    /// Checks if a specified date is within a certain start and end date range.
    /// </summary>
    /// <param name="dateTime">Date to be checked.</param>
    /// <param name="start">Start date.</param>
    /// <param name="end">End date.</param>
    /// <param name="inclusive">Is the end date inclusive? Default is true.</param>
    /// <returns>True if the date is within the specified range; otherwise, false.</returns>
    public static bool IsBetween(this DateTime dateTime, DateTime start, DateTime end, bool inclusive = true)
    {
        if (inclusive)
            return dateTime >= start && dateTime <= end;
        else
            return dateTime > start && dateTime < end;
    }

    /// <summary>
    /// Checks if a date is within a specified time range based on the time format.
    /// </summary>
    /// <param name="dateTime">Date to be checked.</param>
    /// <param name="start">Start date.</param>
    /// <param name="end">End date.</param>
    /// <param name="timeFormat">Time format (HH:mm:ss).</param>
    /// <param name="inclusive">Is the end date inclusive?</param>
    /// <returns>True if the date is within the specified time range; otherwise, false.</returns>
    public static bool IsBetween(this DateTime dateTime, DateTime start, DateTime end, string timeFormat, bool inclusive)
    {
        var startTime = DateTime.ParseExact(start.ToString(timeFormat), timeFormat, null);
        var endTime = DateTime.ParseExact(end.ToString(timeFormat), timeFormat, null);
        var checkTime = DateTime.ParseExact(dateTime.ToString(timeFormat), timeFormat, null);

        if (inclusive)
            return checkTime >= startTime && checkTime <= endTime;
        else
            return checkTime > startTime && checkTime < endTime;
    }

    /// <summary>
    /// Calculates a person's age based on their birthdate.
    /// </summary>
    /// <param name="birthDate">Birthdate.</param>
    /// <returns>Person's age.</returns>
    public static int CalculateAge(this DateTime birthDate)
    {
        var today = DateTime.Today;
        var age = today.Year - birthDate.Year;

        if (birthDate.Date > today.AddYears(-age))
            age--;

        return age;
    }

    /// <summary>
    /// Checks if a date is in the past.
    /// </summary>
    /// <param name="dateTime">Date to be checked.</param>
    /// <returns>True if the date is in the past; otherwise, false.</returns>
    public static bool IsPastDate(this DateTime dateTime)
    {
        return dateTime < DateTime.Now;
    }

    /// <summary>
    /// Finds the quarter of the year for a given date.
    /// </summary>
    /// <param name="dateTime">Date to find the quarter for.</param>
    /// <returns>Quarter number of the year.</returns>
    public static int GetYearQuarter(this DateTime dateTime)
    {
        return (dateTime.Month - 1) / 3 + 1;
    }

    /// <summary>
    /// Calculates the number of business days between two dates.
    /// </summary>
    /// <param name="startDate">Start date.</param>
    /// <param name="endDate">End date.</param>
    /// <returns>Number of business days between two dates.</returns>
    public static int CalculateBusinessDays(this DateTime startDate, DateTime endDate)
    {
        int businessDays = 0;
        while (startDate <= endDate)
        {
            if (startDate.DayOfWeek != DayOfWeek.Saturday && startDate.DayOfWeek != DayOfWeek.Sunday)
                businessDays++;

            startDate = startDate.AddDays(1);
        }

        return businessDays;
    }

    /// <summary>
    /// Calculates the difference between two dates in a specified time unit.
    /// </summary>
    /// <param name="startDate">Start date.</param>
    /// <param name="endDate">End date.</param>
    /// <param name="timeUnit">Time unit (e.g., days, hours, minutes).</param>
    /// <returns>Difference between two dates.</returns>
    public static double CalculateDateDifference(this DateTime startDate, DateTime endDate, TimeUnit timeUnit)
    {
        TimeSpan span = endDate - startDate;
        switch (timeUnit)
        {
            case TimeUnit.Days:
                return span.TotalDays;
            case TimeUnit.Hours:
                return span.TotalHours;
            case TimeUnit.Minutes:
                return span.TotalMinutes;

            default:
                throw new ArgumentOutOfRangeException(nameof(timeUnit), "Invalid time unit.");
        }
    }

    /// <summary>
    /// Calculates the number of weeks between two dates.
    /// </summary>
    /// <param name="startDate">Start date.</param>
    /// <param name="endDate">End date.</param>
    /// <returns>Number of weeks between two dates.</returns>
    public static int CalculateWeeksBetween(this DateTime startDate, DateTime endDate)
    {
        TimeSpan timeSpan = endDate - startDate;
        return timeSpan.Days / 7;
    }

    /// <summary>
    /// Calculates the number of months between two dates.
    /// </summary>
    /// <param name="startDate">Start date.</param>
    /// <param name="endDate">End date.</param>
    /// <returns>Number of months between two dates.</returns>
    public static int CalculateMonthsBetween(this DateTime startDate, DateTime endDate)
    {
        return (endDate.Year - startDate.Year) * 12 + endDate.Month - startDate.Month;
    }

}
