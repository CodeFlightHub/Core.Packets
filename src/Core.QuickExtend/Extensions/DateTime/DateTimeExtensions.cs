namespace Core.QuickExtend.Extensions;

public static partial class DateTimeExtensions
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
    /// Generates a random date within the specified date range.
    /// </summary>
    /// <param name="startDate">Start date.</param>
    /// <param name="endDate">End date.</param>
    /// <returns>Random date.</returns>
    public static DateTime RandomDateInRange(this DateTime startDate, DateTime endDate)
    {
        Random random = new Random();
        int range = (endDate - startDate).Days;
        return startDate.AddDays(random.Next(range));
    }

    /// <summary>
    /// Returns the start of the day for the specified date.
    /// </summary>
    /// <param name="dateTime">Date.</param>
    /// <returns>Start of the day (00:00).</returns>
    public static DateTime StartOfDay(this DateTime dateTime)
    {
        return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0);
    }
}
