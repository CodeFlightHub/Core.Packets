namespace Core.QuickExtend.Extensions;

public static partial class DateTimeExtensions
{
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
    /// Returns the day of the week index for the specified date.
    /// </summary>
    /// <param name="dateTime">Date to be checked.</param>
    /// <returns>Day of the week index (1-7).</returns>
    public static int GetDayOfWeekIndex(this DateTime dateTime)
    {
        int dayOfWeekIndex = (int)dateTime.DayOfWeek;
        return dayOfWeekIndex == 0 ? 7 : dayOfWeekIndex;
    }

    /// <summary>
    /// Returns the week number of the month for the specified date.
    /// </summary>
    /// <param name="dateTime">Date to be checked.</param>
    /// <returns>Week number of the month.</returns>
    public static int GetWeekOfMonth(this DateTime dateTime)
    {
        DateTime firstDayOfMonth = new DateTime(dateTime.Year, dateTime.Month, 1);
        int offset = (int)firstDayOfMonth.DayOfWeek - 1;
        int daysInFirstWeek = 7 - offset;

        int dayOfMonth = dateTime.Day;
        if (dayOfMonth <= daysInFirstWeek)
            return 1;

        return (dayOfMonth - daysInFirstWeek - 1) / 7 + 2;
    }
}
