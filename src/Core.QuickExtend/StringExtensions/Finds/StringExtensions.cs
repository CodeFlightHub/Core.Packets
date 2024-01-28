namespace Core.QuickExtend.StringExtensions;

public static partial class StringExtensions
{
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
    /// Finds the most repeated substring of a given length in a string.
    /// </summary>
    /// <param name="input">String in which substrings will be searched.</param>
    /// <param name="subStringLength">Length of the substrings to search for.</param>
    /// <returns>Most repeated substring of the specified length.</returns>
    public static string FindMostRepeatedSubstring(this string input, int subStringLength)
    {
        if (subStringLength <= 0 || subStringLength > input.Length)
        {
            throw new ArgumentException("Invalid substring length.");
        }

        var substringCounts = new System.Collections.Generic.Dictionary<string, int>();

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
}
