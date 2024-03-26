namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class DateTimeExtensions
{
    #region IsBetween Methods
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
    #endregion

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
    /// Checks if the specified date is a business day.
    /// </summary>
    /// <param name="dateTime">Date to be checked.</param>
    /// <returns>True if it's a business day; otherwise, false.</returns>
    public static bool IsBusinessDay(this DateTime dateTime)
    {
        return dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday;
    }

    /// <summary>
    /// Checks if the specified date is a weekday.
    /// </summary>
    /// <param name="dateTime">Date to be checked.</param>
    /// <returns>True if it's a weekday; otherwise, false.</returns>
    public static bool IsWeekday(this DateTime dateTime)
    {
        return dateTime.DayOfWeek != DayOfWeek.Saturday && dateTime.DayOfWeek != DayOfWeek.Sunday;
    }

    /// <summary>
    /// Checks if the specified date and time is lunchtime (12:00).
    /// </summary>
    /// <param name="dateTime">Date and time to be checked.</param>
    /// <returns>True if it's lunchtime; otherwise, false.</returns>
    public static bool IsLunchTime(this DateTime dateTime)
    {
        return dateTime.Hour == 12 && dateTime.Minute == 0 && dateTime.Second == 0;
    }

    /// <summary>
    /// Checks if the specified date and time is midnight (00:00).
    /// </summary>
    /// <param name="dateTime">Date and time to be checked.</param>
    /// <returns>True if it's midnight; otherwise, false.</returns>
    public static bool IsMidnight(this DateTime dateTime)
    {
        return dateTime.Hour == 0 && dateTime.Minute == 0 && dateTime.Second == 0;
    }
}
