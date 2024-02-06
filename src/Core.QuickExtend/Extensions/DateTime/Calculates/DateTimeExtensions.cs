using Core.QuickExtend.Enums;

namespace Core.QuickExtend.Extensions;

public static partial class DateTimeExtensions
{
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
