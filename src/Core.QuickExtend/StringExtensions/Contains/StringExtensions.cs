namespace Core.QuickExtend.StringExtensions;

public static partial class StringExtensions
{
    /// <summary>
    /// Checks whether the given string consists only of numeric characters.
    /// </summary>
    /// <param name="input">The input string to be checked.</param>
    /// <returns>True if the string consists only of numeric characters; otherwise, false.</returns>
    public static bool ContainsOnlyNumeric(this string? input)
    {
        return !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
    }

    /// <summary>
    /// Checks whether the given string contains numeric characters.
    /// </summary>
    /// <param name="input">The input string to be checked.</param>
    /// <returns>True if the string contains numeric characters; otherwise, false.</returns>
    public static bool ContainsNumeric(this string? input)
    {
        return !string.IsNullOrEmpty(input) && input.Any(char.IsDigit);
    }

    /// <summary>
    /// Checks whether the given string contains only alphabetical characters.
    /// </summary>
    /// <param name="input">The input string to be checked.</param>
    /// <returns>True if the string contains only alphabetical characters; otherwise, false.</returns>
    public static bool ContainsOnlyLetters(this string? input)
    {
        return !string.IsNullOrEmpty(input) && input.All(char.IsLetter);
    }

    /// <summary>
    /// Checks whether the given string contains letter characters.
    /// </summary>
    /// <param name="input">The input string to be checked.</param>
    /// <returns>True if the string contains letter characters; otherwise, false.</returns>
    public static bool ContainsLetter(this string? input)
    {
        return !string.IsNullOrEmpty(input) && input.Any(char.IsLetter);
    }
}
