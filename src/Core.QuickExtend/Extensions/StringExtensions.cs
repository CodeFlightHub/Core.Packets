using System.Globalization;
using System.Text;

namespace Core.QuickExtend.Extensions;

public static class StringExtensions
{
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
    /// Converts a string to lowercase with Turkish character sensitivity.
    /// </summary>
    /// <param name="input">String to be converted.</param>
    /// <returns>String converted to lowercase with Turkish character sensitivity.</returns>
    public static string ToTurkishLowerCase(this string input)
    {
        return input.ToLower(new CultureInfo("tr-TR"));
    }

    /// <summary>
    /// Removes spaces from a string.
    /// </summary>
    /// <param name="input">String from which spaces will be removed.</param>
    /// <returns>String with spaces removed.</returns>
    public static string RemoveSpaces(this string input)
    {
        return input.Replace(" ", string.Empty);
    }

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
    /// Removes duplicate characters from a string.
    /// </summary>
    /// <param name="input">String from which duplicate characters will be removed.</param>
    /// <returns>String with duplicate characters removed.</returns>
    public static string RemoveDuplicateCharacters(this string input)
    {
        var uniqueCharacters = new HashSet<char>();
        var result = new StringBuilder();

        foreach (var character in input)
        {
            if (uniqueCharacters.Add(character))
            {
                result.Append(character);
            }
        }

        return result.ToString();
    }

    /// <summary>
    /// Finds the most repeated word in a string.
    /// </summary>
    /// <param name="input">String in which word occurrences will be counted.</param>
    /// <returns>Most repeated word.</returns>
    public static string FindMostRepeatedWord(this string input)
    {
        var wordCounts = new Dictionary<string, int>();
        var words = input.Split(' ');

        foreach (var word in words)
        {
            string cleanedWord = new string(word.ToLower().Where(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c)).ToArray());

            if (!string.IsNullOrWhiteSpace(cleanedWord))
            {
                if (wordCounts.ContainsKey(cleanedWord))
                {
                    wordCounts[cleanedWord]++;
                }
                else
                {
                    wordCounts[cleanedWord] = 1;
                }
            }
        }

        var mostRepeatedWord = wordCounts.OrderByDescending(pair => pair.Value).FirstOrDefault().Key;

        return mostRepeatedWord ?? string.Empty;
    }

    /// <summary>
    /// Finds the most repeated substring of a certain length in a string.
    /// </summary>
    /// <param name="input">String containing the substring.</param>
    /// <param name="subStringLength">Length of the searched substring.</param>
    /// <returns>Most repeated substring.</returns>
    public static string FindMostRepeatedSubstring(this string input, int subStringLength)
    {
        if (subStringLength <= 0 || subStringLength > input.Length)
        {
            throw new ArgumentException("Invalid substring length.");
        }

        var substringCounts = new Dictionary<string, int>();

        for (int i = 0; i <= input.Length - subStringLength; i++)
        {
            string substring = input.Substring(i, subStringLength);

            if (substringCounts.ContainsKey(substring))
            {
                substringCounts[substring]++;
            }
            else
            {
                substringCounts[substring] = 1;
            }
        }

        var mostRepeatedSubstring = string.Empty;
        int maxCount = 0;

        foreach (var kvp in substringCounts)
        {
            if (kvp.Value > maxCount)
            {
                mostRepeatedSubstring = kvp.Key;
                maxCount = kvp.Value;
            }
        }

        return mostRepeatedSubstring;
    }

    /// <summary>
    /// Capitalizes the first letter of each word in a string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <returns>String with the first letter of each word capitalized.</returns>
    public static string CapitalizeFirstLetter(this string input)
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
    /// Adds a suffix to a string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="suffix">The suffix to be added.</param>
    /// <param name="includeSpace">A parameter indicating whether to include a space (default is true).</param>
    /// <returns>String with the suffix added.</returns>
    public static string AddSuffix(this string input, string suffix, bool includeSpace = true)
    {
        string space = includeSpace ? " " : "";
        return String.Concat(input, space, suffix);
    }

    /// <summary>
    /// Adds a prefix to a string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="prefix">The prefix to be added.</param>
    /// <param name="includeSpace">A parameter indicating whether to include a space (default is true).</param>
    /// <returns>String with the prefix added.</returns>
    public static string AddPrefix(this string input, string prefix, bool includeSpace = true)
    {
        string space = includeSpace ? " " : "";
        return String.Concat(prefix, space, input);
    }

    /// <summary>
    /// Formats a currency value according to a specified currency format.
    /// </summary>
    /// <param name="amount">Currency amount to be formatted.</param>
    /// <param name="currency">Currency symbol (default is "₺").</param>
    /// <param name="format">Currency format (default is "C2" - two digits after the decimal point).</param>
    /// <returns>Formatted currency string.</returns>
    public static string FormatCurrency(this decimal amount, string currency = "₺", string format = "C2")
    {
        return string.Format("{0} {1}", currency, amount.ToString(format));
    }

    /// <summary>
    /// Formats a phone number according to a specified format.
    /// </summary>
    /// <param name="phoneNumber">Phone number to be formatted.</param>
    /// <param name="format">Phone number format (default is "0(XXX)-XXX-XX-XX").</param>
    /// <returns>Formatted phone number string.</returns>
    public static string FormatPhoneNumber(this string phoneNumber, string format = "0(XXX)-XXX-XX-XX")
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

    /// <summary>
    /// Checks whether the given string consists only of alphanumeric characters.
    /// </summary>
    /// <param name="input">The input string to be checked.</param>
    /// <returns>True if the string is alphanumeric, false otherwise.</returns>
    public static bool IsAlphaNumeric(this string input)
    {
        return input.All(char.IsLetterOrDigit);
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
    public static bool IsHtml(this string input)
    {
        return !string.IsNullOrEmpty(input) && input.IndexOf('<') != -1 && input.IndexOf('>') != -1;
    }

    /// <summary>
    /// Checks whether the given string consists only of numeric characters.
    /// </summary>
    /// <param name="input">The input string to be checked.</param>
    /// <returns>True if the string consists only of numeric characters; otherwise, false.</returns>
    public static bool ContainsOnlyNumeric(this string input)
    {
        return !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
    }

    /// <summary>
    /// Checks whether the given string contains numeric characters.
    /// </summary>
    /// <param name="input">The input string to be checked.</param>
    /// <returns>True if the string contains numeric characters; otherwise, false.</returns>
    public static bool ContainsNumeric(this string input)
    {
        return !string.IsNullOrEmpty(input) && input.Any(char.IsDigit);
    }

    /// <summary>
    /// Checks whether the given string contains only alphabetical characters.
    /// </summary>
    /// <param name="input">The input string to be checked.</param>
    /// <returns>True if the string contains only alphabetical characters; otherwise, false.</returns>
    public static bool ContainsOnlyLetters(this string input)
    {
        return !string.IsNullOrEmpty(input) && input.All(char.IsLetter);
    }
}
