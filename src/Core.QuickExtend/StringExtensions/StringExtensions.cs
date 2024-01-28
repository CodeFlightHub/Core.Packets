using System.Globalization;

namespace Core.QuickExtend.StringExtensions;

public static class StringExtensions
{
    /// <summary>
    /// Capitalizes the first letter of each word in a string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>String with the first letter of each word capitalized.</returns>
    public static string? CapitalizeFirstLetter(this string? input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;

        string[] words = input.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (!string.IsNullOrEmpty(words[i]))
            {
                words[i] = textInfo.ToTitleCase(words[i].ToLower());
            }
        }

        return string.Join(" ", words);
    }

    /// <summary>
    /// Sums the digits in a string.
    /// </summary>
    /// <param name="input">String to be summed.</param>
    /// <returns>Total digit value.</returns>
    public static int SumDigits(this string input)
    {
        int sum = 0;

        foreach (char c in input)
        {
            if (char.IsDigit(c))
            {
                sum += int.Parse(c.ToString());
            }
        }

        return sum;
    }

    /// <summary>
    /// Searches for a specified string value within an Enum and returns the first matching Enum item.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    /// <param name="value">Searched string value.</param>
    /// <returns>Found Enum item or the default Enum item.</returns>
    public static T? ParseFromString<T>(this string value) where T : Enum
    {
        try
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
        catch (ArgumentException)
        {
            return default(T);

        }
    }
}
