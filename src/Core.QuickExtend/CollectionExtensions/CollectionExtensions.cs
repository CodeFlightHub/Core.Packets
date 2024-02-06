namespace Core.QuickExtend.CollectionExtensions;

public static class CollectionExtensions
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

}
