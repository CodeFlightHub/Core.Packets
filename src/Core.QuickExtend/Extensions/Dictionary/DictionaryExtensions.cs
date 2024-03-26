using System.Collections.Concurrent;
using System.Text;

namespace CodeFlightHub.CorePackets.QuickExtend.Dictionary;

public static partial class DictionaryExtensions
{
    /// <summary>
    /// Adds a new key-value pair to the dictionary if the key does not exist; otherwise, updates the value associated with the existing key.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to add or update the key-value pair.</param>
    /// <param name="key">The key of the key-value pair.</param>
    /// <param name="value">The value of the key-value pair.</param>
    public static void AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        if (dictionary.ContainsKey(key))
            dictionary[key] = value;
        else
            dictionary.Add(key, value);
    }

    /// <summary>
    /// Determines whether the dictionary contains the specified key, ignoring case sensitivity for string keys.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to check for the specified key.</param>
    /// <param name="key">The key to locate in the dictionary.</param>
    /// <returns>True if the dictionary contains the specified key; otherwise, false.</returns>
    public static bool ContainsKeyIgnoreCase<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        var comparer = EqualityComparer<TKey>.Default;
        foreach (var dictionaryKey in dictionary.Keys)
        {
            if (comparer.Equals(dictionaryKey, key))
                return true;
        }
        return false;
    }

    /// <summary>
    /// Merges the key-value pairs from the source dictionary into the destination dictionary.
    /// If a key already exists in the destination dictionary, its value will be updated with the value from the source dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionaries.</typeparam>
    /// <param name="destination">The destination dictionary where key-value pairs will be merged.</param>
    /// <param name="source">The source dictionary from which key-value pairs will be merged.</param>
    public static void Merge<TKey, TValue>(this IDictionary<TKey, TValue> destination, IDictionary<TKey, TValue> source)
    {
        if (destination == null)
            throw new ArgumentNullException(nameof(destination));
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        foreach (var kvp in source)
        {
            destination[kvp.Key] = kvp.Value;
        }
    }

    /// <summary>
    /// Returns a new dictionary containing key-value pairs that exist in both the first and second dictionaries.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionaries.</typeparam>
    /// <param name="first">The first dictionary to intersect.</param>
    /// <param name="second">The second dictionary to intersect.</param>
    /// <returns>A new dictionary containing key-value pairs that exist in both dictionaries.</returns>
    public static IDictionary<TKey, TValue> Intersect<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
    {
        if (first == null)
            throw new ArgumentNullException(nameof(first));
        if (second == null)
            throw new ArgumentNullException(nameof(second));

        return first.Where(kvp => second.ContainsKey(kvp.Key))
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    /// <summary>
    /// Returns a new dictionary containing key-value pairs from the first dictionary that do not exist in the second dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionaries.</typeparam>
    /// <param name="first">The first dictionary to subtract from.</param>
    /// <param name="second">The second dictionary to subtract.</param>
    /// <returns>A new dictionary containing key-value pairs from the first dictionary that do not exist in the second dictionary.</returns>
    public static IDictionary<TKey, TValue> Subtract<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
    {
        if (first == null)
            throw new ArgumentNullException(nameof(first));
        if (second == null)
            throw new ArgumentNullException(nameof(second));

        return first.Where(kvp => !second.ContainsKey(kvp.Key))
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    /// <summary>
    /// Returns a collection of keys from the dictionary that have the specified value.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to search for keys with the specified value.</param>
    /// <param name="value">The value to search for.</param>
    /// <returns>A collection of keys from the dictionary that have the specified value.</returns>
    public static IEnumerable<TKey> ValuesEquals<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue value)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        return dictionary.Where(kvp => EqualityComparer<TValue>.Default.Equals(kvp.Value, value))
                         .Select(kvp => kvp.Key);
    }

    /// <summary>
    /// Returns a new dictionary sorted by the values in ascending or descending order.
    /// </summary>
    /// <typeparam name="TKey">The type of the keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of the values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to sort.</param>
    /// <param name="ascending">True to sort in ascending order, false to sort in descending order.</param>
    /// <returns>A new dictionary sorted by the values in ascending or descending order.</returns>
    public static IDictionary<TKey, TValue> OrderByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, bool ascending = true)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        if (ascending)
        {
            var sortedValues = dictionary.OrderBy(kvp => kvp.Value);
            var sortedDictionary = new Dictionary<TKey, TValue>();
            foreach (var kvp in sortedValues)
            {
                sortedDictionary.Add(kvp.Key, kvp.Value);
            }
            return sortedDictionary;
        }
        else
        {
            var sortedValues = dictionary.OrderByDescending(kvp => kvp.Value);
            var sortedDictionary = new Dictionary<TKey, TValue>();
            foreach (var kvp in sortedValues)
            {
                sortedDictionary.Add(kvp.Key, kvp.Value);
            }
            return sortedDictionary;
        }
    }

    /// <summary>
    /// Returns the difference of keys between two dictionaries.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionaries.</typeparam>
    /// <param name="first">The first dictionary.</param>
    /// <param name="second">The second dictionary.</param>
    /// <returns>An enumerable collection of keys that are in the first dictionary but not in the second.</returns>
    public static IEnumerable<TKey> KeyDifference<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
    {
        if (first == null)
            throw new ArgumentNullException(nameof(first));
        if (second == null)
            throw new ArgumentNullException(nameof(second));

        return first.Keys.Except(second.Keys);
    }

    /// <summary>
    /// Returns the difference of values between two dictionaries.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionaries.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionaries.</typeparam>
    /// <param name="first">The first dictionary.</param>
    /// <param name="second">The second dictionary.</param>
    /// <returns>An enumerable collection of values that are in the first dictionary but not in the second.</returns>
    public static IEnumerable<TValue> ValueDifference<TKey, TValue>(this IDictionary<TKey, TValue> first, IDictionary<TKey, TValue> second)
    {
        if (first == null)
            throw new ArgumentNullException(nameof(first));
        if (second == null)
            throw new ArgumentNullException(nameof(second));

        return first.Values.Except(second.Values);
    }

    /// <summary>
    /// Shuffles the dictionary by randomizing the order of key-value pairs.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to shuffle.</param>
    /// <returns>A new dictionary containing the same key-value pairs as the input dictionary, but with a shuffled order.</returns>
    public static IDictionary<TKey, TValue> Shuffle<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));

        var rnd = new Random();
        var shuffledDict = new Dictionary<TKey, TValue>();
        var kvpList = dictionary.ToList();

        while (kvpList.Count > 0)
        {
            int index = rnd.Next(kvpList.Count);
            var kvp = kvpList[index];
            shuffledDict.Add(kvp.Key, kvp.Value);
            kvpList.RemoveAt(index);
        }

        return shuffledDict;
    }

    /// <summary>
    /// Performs the specified action on each key-value pair in the dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    /// <param name="dictionary">The dictionary to iterate over.</param>
    /// <param name="action">The action to perform on each key-value pair.</param>
    /// <exception cref="ArgumentNullException">Thrown when either dictionary or action is null.</exception>
    public static void ForEach<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, Action<TKey, TValue> action)
    {
        if (dictionary == null)
            throw new ArgumentNullException(nameof(dictionary));
        if (action == null)
            throw new ArgumentNullException(nameof(action));

        foreach (var kvp in dictionary)
        {
            action(kvp.Key, kvp.Value);
        }
    }
}
