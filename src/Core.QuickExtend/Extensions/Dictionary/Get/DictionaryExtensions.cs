using System.Collections.Concurrent;
using System.Text;

namespace CodeFlightHub.CorePackets.QuickExtend.Dictionary;

public static partial class DictionaryExtensions
{
    /// <summary>
    /// Gets the value associated with the specified key, or creates a new value if the key does not exist.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to search for the key.</param>
    /// <param name="key">The key to search for.</param>
    /// <param name="valueFactory">The factory function to create a new value if the key does not exist.</param>
    /// <returns>The value associated with the specified key, or a new value if the key does not exist.</returns>
    public static TValue GetOrCreate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueFactory)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        if (dictionary.TryGetValue(key, out TValue existingValue))
            return existingValue;

        TValue newValue = valueFactory();
        dictionary[key] = newValue;
        return newValue;
    }

    /// <summary>
    /// Gets the value associated with the specified key, or returns the default value for the value type if the key does not exist.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to search for the key.</param>
    /// <param name="key">The key to search for.</param>
    /// <returns>The value associated with the specified key, or the default value for the value type if the key does not exist.</returns>
    public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        return dictionary.TryGetValue(key, out TValue value) ? value : default;
    }

    /// <summary>
    /// Gets the value associated with the specified key, or adds the specified default value if the key does not exist.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to search for the key.</param>
    /// <param name="key">The key to search for.</param>
    /// <param name="defaultValue">The default value to add if the key does not exist.</param>
    /// <returns>The value associated with the specified key, or the default value if the key does not exist.</returns>
    public static TValue GetOrAddDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        if (dictionary.TryGetValue(key, out TValue existingValue))
            return existingValue;

        dictionary[key] = defaultValue;
        return defaultValue;
    }


    /// <summary>
    /// Gets the keys associated with the specified value.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to search for the value.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>An enumerable collection of keys associated with the specified value.</returns>
    public static IEnumerable<TKey> GetKeysByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        return dictionary.Where(kvp => EqualityComparer<TValue>.Default.Equals(kvp.Value, value))
                         .Select(kvp => kvp.Key);
    }
}
