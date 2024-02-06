namespace Core.QuickExtend.Extensions;

public static partial class DateTimeExtensions
{
    /// <summary>
    /// Adds the specified number of business days to the given date and returns the new date.
    /// </summary>
    /// <param name="startDate">Starting date.</param>
    /// <param name="businessDaysToAdd">Number of business days to add.</param>
    /// <returns>New date.</returns>
    public static DateTime AddBusinessDays(this DateTime startDate, int businessDaysToAdd)
    {
        int increment = businessDaysToAdd < 0 ? -1 : 1;

        while (businessDaysToAdd != 0)
        {
            startDate = startDate.AddDays(increment);
            if (startDate.IsBusinessDay())
                businessDaysToAdd -= increment;
        }

        return startDate;
    }
}
