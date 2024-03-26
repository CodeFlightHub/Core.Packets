using System.Collections.Concurrent;
using System.Text;

namespace CodeFlightHub.CorePackets.QuickExtend.Dictionary;

public static partial class DictionaryExtensions
{
    /// <summary>
    /// Converts the dictionary to a string representation in a formatted manner.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to convert to a formatted string.</param>
    /// <returns>A string representation of the dictionary in a formatted manner.</returns>
    public static string ToFormattedString<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        var stringBuilder = new StringBuilder("{");
        foreach (var kvp in dictionary)
        {
            stringBuilder.Append($"{kvp.Key}: {kvp.Value}, ");
        }
        if (dictionary.Count > 0)
        {
            stringBuilder.Length -= 2;
        }
        stringBuilder.Append("}");
        return stringBuilder.ToString();
    }

    /// <summary>
    /// Converts the dictionary to a concurrent dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to convert.</param>
    /// <returns>A new instance of ConcurrentDictionary<TKey, TValue> containing the same key-value pairs as the input dictionary.</returns>
    public static ConcurrentDictionary<TKey, TValue> ToConcurrentDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        return new ConcurrentDictionary<TKey, TValue>(dictionary);
    }
}
