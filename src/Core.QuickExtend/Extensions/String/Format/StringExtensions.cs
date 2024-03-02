namespace Core.QuickExtend.Extensions;

public static partial class StringExtensions
{
    /// <summary>
    /// Formats a phone number according to a specified format.
    /// </summary>
    /// <param name="phoneNumber">Phone number to be formatted.</param>
    /// <param name="format">Phone number format (default is "0(XXX)-XXX-XX-XX").</param>
    /// <returns>Formatted phone number string.</returns>
    public static string? FormatPhoneNumber(this string? phoneNumber, string format = "0(XXX)-XXX-XX-XX")
    {
        if (string.IsNullOrEmpty(phoneNumber))
            return string.Empty;

        int index = 0;
        return new string(format.Select(c => c == 'X' ? phoneNumber[index++] : c).ToArray());
    }

    /// <summary>
    /// Truncates text after a certain length and adds ellipsis (...) at the end.
    /// </summary>
    /// <param name="text">Text to be formatted.</param>
    /// <param name="maxLength">Maximum length (default is 50).</param>
    /// <returns>Truncated text string with ellipsis.</returns>
    public static string FormatTruncateWithEllipsis(this string text, int maxLength = 50)
    {
        return text.Length <= maxLength ? text : text.Substring(0, maxLength) + "...";
    }

    /// <summary>
    /// Pads text with a certain character to achieve a specified length.
    /// </summary>
    /// <param name="text">Text to be formatted.</param>
    /// <param name="length">Target length.</param>
    /// <param name="paddingChar">Padding character.</param>
    /// <param name="alignLeft">True if padding from the left, false if padding from the right.</param>
    /// <returns>Text padded to the specified length.</returns>
    public static string FormatPadToLength(this string text, int length, char paddingChar = ' ', bool alignLeft = true)
    {
        if (text.Length >= length)
        {
            return text;
        }

        int paddingLength = length - text.Length;
        string padding = new string(paddingChar, paddingLength);

        return alignLeft ? text + padding : padding + text;
    }
}
