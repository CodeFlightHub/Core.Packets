using System.Text;

namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class StringExtensions
{
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
}
