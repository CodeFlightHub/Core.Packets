using System.Globalization;

namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class StringExtensions
{
    /// <summary>
    /// Converts a string to an integer. Returns the default value if conversion fails.
    /// </summary>
    /// <param name="input">String to be converted.</param>
    /// <param name="defaultValue">Default value to be returned if conversion fails (default is 0).</param>
    /// <returns>String converted to an integer or the default value.</returns>
    public static int ToInt(this string input, int defaultValue = 0)
    {
        if (int.TryParse(input, out int result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Converts a string to a double. Returns the default value if conversion fails.
    /// </summary>
    /// <param name="input">String to be converted.</param>
    /// <param name="defaultValue">Default value to be returned if conversion fails (default is 0.0).</param>
    /// <returns>String converted to a double or the default value.</returns>
    public static double ToDouble(this string input, double defaultValue = 0.0)
    {
        if (double.TryParse(input, out double result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Converts a string to a boolean. Returns the default value if conversion fails.
    /// </summary>
    /// <param name="input">String to be converted.</param>
    /// <param name="defaultValue">Default value to be returned if conversion fails (default is false).</param>
    /// <returns>String converted to a boolean or the default value.</returns>
    public static bool ToBool(this string input, bool defaultValue = false)
    {
        if (bool.TryParse(input, out bool result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Converts a string to a DateTime. Returns the default value if conversion fails.
    /// </summary>
    /// <param name="input">String to be converted.</param>
    /// <param name="defaultValue">Default value to be returned if conversion fails (default is DateTime.MinValue).</param>
    /// <returns>String converted to a DateTime or the default value.</returns>
    public static DateTime ToDateTime(this string input, DateTime defaultValue = default)
    {
        if (DateTime.TryParse(input, out DateTime result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Converts a string to a TimeSpan. Returns the default value if conversion fails.
    /// </summary>
    /// <param name="input">String to be converted.</param>
    /// <param name="defaultValue">Default value to be returned if conversion fails (default is TimeSpan.MinValue).</param>
    /// <returns>String converted to a TimeSpan or the default value.</returns>
    public static TimeSpan ToTimeSpan(this string input, TimeSpan defaultValue = default)
    {
        if (TimeSpan.TryParse(input, out TimeSpan result))
        {
            return result;
        }
        return defaultValue;
    }

    /// <summary>
    /// Converts a string to lowercase with Turkish character sensitivity.
    /// </summary>
    /// <param name="input">String to be converted.</param>
    /// <returns>String converted to lowercase with Turkish character sensitivity.</returns>
    public static string ToTurkishLowerCase(this string input)
    {
        return input.ToLower(new CultureInfo("tr-TR"));
    }
}
