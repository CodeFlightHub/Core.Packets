namespace Core.QuickExtend.Extensions;

public static class EnumerableExtensions
{
    /// <summary>
    /// Paginates the items in a collection based on a specified page number and page size.
    /// </summary>
    /// <typeparam name="T">Type of collection items.</typeparam>
    /// <param name="source">Collection to be paginated.</param>
    /// <param name="pageNumber">Requested page number.</param>
    /// <param name="pageSize">Page size.</param>
    /// <returns>Collection paginated based on the specified page number and size.</returns>
    public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int pageNumber, int pageSize)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        return source.Skip((pageNumber - 1) * pageSize).Take(pageSize);
    }

    /// <summary>
    /// Returns the index of an item in the collection that contains a specific value. Returns -1 if the item is not found.
    /// </summary>
    /// <typeparam name="T">Type of collection items.</typeparam>
    /// <param name="source">Collection.</param>
    /// <param name="value">Value to be searched.</param>
    /// <returns>Index of the item containing the specified value or -1.</returns>
    public static int IndexOf<T>(this IEnumerable<T> source, T value)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        var index = source.Select((item, i) => new { Item = item, Index = i })
                          .FirstOrDefault(x => EqualityComparer<T>.Default.Equals(x.Item, value))?.Index ?? -1;
        return index;
    }

    /// <summary>
    /// Divides the collection around a specific element.
    /// </summary>
    /// <typeparam name="T">Type of collection items.</typeparam>
    /// <param name="source">Collection.</param>
    /// <param name="separator">Separator element.</param>
    /// <returns>Partitioned collection.</returns>
    public static IEnumerable<IEnumerable<T>> Split<T>(this IEnumerable<T> source, T separator)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        var groups = source.GroupBy(item => EqualityComparer<T>.Default.Equals(item, separator))
                          .Select(group => group.ToList());

        return groups;
    }

    /// <summary>
    /// Finds unique items in the collection based on a specified key.
    /// </summary>
    /// <typeparam name="T">Type of collection items.</typeparam>
    /// <typeparam name="TKey">Type of the key used for distinctness.</typeparam>
    /// <param name="source">Collection.</param>
    /// <param name="keySelector">Key selector function.</param>
    /// <returns>Collection of unique items.</returns>
    public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
    {
        var uniqueKeys = new HashSet<TKey>();
        return source.Where(item => uniqueKeys.Add(keySelector(item)));
    }

}
