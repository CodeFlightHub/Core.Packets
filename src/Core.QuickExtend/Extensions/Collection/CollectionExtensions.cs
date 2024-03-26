namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class CollectionExtensions
{
    /// <summary>
    /// Takes elements from the ICollection starting from a specific index and returns a collection with a specified number of elements.
    /// </summary>
    /// <typeparam name="T">Type of elements in the ICollection.</typeparam>
    /// <param name="collection">The ICollection to take elements from.</param>
    /// <param name="startIndex">The starting index to begin taking elements.</param>
    /// <param name="count">The number of elements to take.</param>
    /// <returns>An IEnumerable containing the specified range of elements.</returns>
    public static IEnumerable<T> TakeRange<T>(this ICollection<T> collection, int startIndex, int count)
    {
        return collection.Skip(startIndex).Take(count);
    }

    /// <summary>
    /// Splits the ICollection into batches of a specified size.
    /// </summary>
    /// <typeparam name="T">Type of elements in the ICollection.</typeparam>
    /// <param name="collection">The ICollection to be batched.</param>
    /// <param name="batchSize">The size of each batch.</param>
    /// <returns>A collection of batches, where each batch is an ICollection.</returns>
    public static IEnumerable<ICollection<T>> Batch<T>(this ICollection<T> collection, int batchSize)
    {
        for (int i = 0; i < collection.Count; i += batchSize)
        {
            yield return collection.Skip(i).Take(batchSize).ToList();
        }
    }

    /// <summary>
    /// Removes duplicate elements from the ICollection based on a specified key.
    /// </summary>
    /// <typeparam name="T">Type of elements in the ICollection.</typeparam>
    /// <typeparam name="TKey">Type of the key to determine uniqueness.</typeparam>
    /// <param name="collection">The ICollection to remove duplicates from.</param>
    /// <param name="keySelector">A function to extract the key for each element.</param>
    /// <returns>A new ICollection with duplicates removed.</returns>
    public static ICollection<T> DistinctBy<T, TKey>(this ICollection<T> collection, Func<T, TKey> keySelector)
    {
        return collection.GroupBy(keySelector).Select(group => group.First()).ToList();
    }

    /// <summary>
    /// Merges two collections into a single collection by interleaving their elements.
    /// </summary>
    /// <typeparam name="T">Type of elements in the ICollection.</typeparam>
    /// <param name="collection1">The first ICollection.</param>
    /// <param name="collection2">The second ICollection.</param>
    /// <returns>A new ICollection containing interleaved elements from both collections.</returns>
    public static ICollection<T> Interleave<T>(this ICollection<T> collection1, ICollection<T> collection2)
    {
        var result = new List<T>();
        using (var enumerator1 = collection1.GetEnumerator())
        using (var enumerator2 = collection2.GetEnumerator())
        {
            while (enumerator1.MoveNext() && enumerator2.MoveNext())
            {
                result.Add(enumerator1.Current);
                result.Add(enumerator2.Current);
            }
        }
        return result;
    }
}
