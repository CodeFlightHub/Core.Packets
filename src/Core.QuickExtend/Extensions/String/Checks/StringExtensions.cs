namespace Core.QuickExtend.Extensions;

public static partial class StringExtensions
{
    /// <summary>
    /// Checks if parentheses in a string are matched.
    /// </summary>
    /// <param name="input">String to be checked.</param>
    /// <returns>True if parentheses are matched, false otherwise.</returns>
    public static bool AreParenthesesMatched(this string input)
    {
        int count = 0;

        foreach (char character in input)
        {
            if (character == '(')
                count++;
            else if (character == ')')
                count--;

            if (count < 0)
                return false;
        }

        return count == 0;
    }

    /// <summary>
    /// Checks whether the given string consists only of alphanumeric characters.
    /// </summary>
    /// <param name="input">The input string to be checked.</param>
    /// <returns>True if the string is alphanumeric, false otherwise.</returns>
    public static bool IsAlphaNumeric(this string? input)
    {
        return !string.IsNullOrEmpty(input) && input.All(char.IsLetterOrDigit);
    }

    /// <summary>
    /// Checks whether the given string is a valid email address.
    /// </summary>
    /// <param name="input">The input string to be checked.</param>
    /// <returns>True if the string is a valid email address; otherwise, false.</returns>
    public static bool IsEmail(this string input)
    {
        try
        {
            var email = new System.Net.Mail.MailAddress(input);
            return email.Address == input;
        }
        catch
        {
            return false;
        }
    }

    /// <summary>
    /// Checks whether the given string contains HTML content.
    /// </summary>
    /// <param name="input">The input string to be checked.</param>
    /// <returns>True if the string contains HTML content; otherwise, false.</returns>
    public static bool IsHtml(this string? input)
    {
        return !string.IsNullOrEmpty(input) && input.IndexOf('<') != -1 && input.IndexOf('>') != -1;
    }
}
