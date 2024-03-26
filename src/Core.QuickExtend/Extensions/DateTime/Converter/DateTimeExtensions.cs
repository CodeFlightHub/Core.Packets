namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class DateTimeExtensions
{
    /// <summary>
    /// Converts the specified date to the total number of minutes passed in the day.
    /// </summary>
    /// <param name="dateTime">Date to be converted.</param>
    /// <returns>Total number of minutes passed in the day.</returns>
    public static int ToMinutesOfDay(this DateTime dateTime)
    {
        return dateTime.Hour * 60 + dateTime.Minute;
    }
}
