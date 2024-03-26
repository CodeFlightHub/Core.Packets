namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class CollectionExtensions
{
    /// <summary>
    /// Removes elements from the collection that contain a specific value.
    /// </summary>
    /// <typeparam name="T">The type of the collection elements.</typeparam>
    /// <param name="source">The collection.</param>
    /// <param name="value">The value to be removed.</param>
    /// <returns>A collection of removed elements.</returns>
    public static IEnumerable<T> RemoveAll<T>(this ICollection<T> source, T value)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        var removedItems = source.Where(item => EqualityComparer<T>.Default.Equals(item, value)).ToList();

        foreach (var item in removedItems)
            source.Remove(item);

        return removedItems;
    }

    /// <summary>
    /// Removes consecutive duplicate elements from the ICollection.
    /// </summary>
    /// <typeparam name="T">Type of elements in the ICollection.</typeparam>
    /// <param name="collection">The ICollection to remove duplicates from.</param>
    /// <returns>A new ICollection with consecutive duplicate elements removed.</returns>
    public static ICollection<T> RemoveConsecutiveDuplicates<T>(this ICollection<T> collection)
    {
        var result = new List<T>();
        T previous = default!;

        foreach (var item in collection)
        {
            if (!EqualityComparer<T>.Default.Equals(item, previous))
            {
                result.Add(item);
            }
            previous = item;
        }
        return result;
    }
}
