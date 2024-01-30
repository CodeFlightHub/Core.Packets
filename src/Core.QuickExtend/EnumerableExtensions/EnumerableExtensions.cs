namespace Core.QuickExtend.EnumerableExtensions;

public static partial class EnumerableExtensions
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
    /// Checks if the collection is null or has no elements.
    /// </summary>
    /// <typeparam name="T">Type of collection items.</typeparam>
    /// <param name="source">Collection to be checked.</param>
    /// <returns>True if the collection is null or empty, false otherwise.</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
    {
        return source == null || !source.Any();
    }

    /// <summary>
    /// Executes an action for each element in the collection.
    /// </summary>
    /// <typeparam name="T">Type of collection items.</typeparam>
    /// <param name="source">Collection to iterate over.</param>
    /// <param name="action">Action to be executed for each element.</param>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        if (source == null)
            throw new ArgumentNullException(nameof(source));

        foreach (var item in source)
        {
            action(item);
        }
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
    /// Splits the collection into two based on a predicate.
    /// </summary>
    /// <typeparam name="T">Type of collection items.</typeparam>
    /// <param name="source">Collection.</param>
    /// <param name="predicate">Predicate for splitting.</param>
    /// <returns>Tuple with two collections - one satisfying the predicate and the other not.</returns>
    public static (IEnumerable<T> matching, IEnumerable<T> notMatching) Split<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        var matching = source.Where(predicate);
        var notMatching = source.Where(item => !predicate(item));
        return (matching, notMatching);
    }

    /// <summary>
    /// Finds the average value of a numeric collection.
    /// </summary>
    /// <param name="source">Numeric collection.</param>
    /// <returns>Average value of the numeric collection.</returns>
    public static double AverageSafe(this IEnumerable<int> source)
    {
        return source.Any() ? source.Average() : 0;
    }

    /// <summary>
    /// Checks if the collection contains any duplicate elements.
    /// </summary>
    /// <typeparam name="T">Type of collection items.</typeparam>
    /// <param name="source">Collection to be checked.</param>
    /// <returns>True if any duplicate elements are found, false otherwise.</returns>
    public static bool HasDuplicates<T>(this IEnumerable<T> source)
    {
        var seen = new HashSet<T>();
        return source.Any(item => !seen.Add(item));
    }

    /// <summary>
    /// Converts the collection to a string using a specified separator between elements.
    /// </summary>
    /// <typeparam name="T">Type of collection items.</typeparam>
    /// <param name="source">Collection to be converted.</param>
    /// <param name="separator">Separator between elements in the resulting string.</param>
    /// <returns>String representation of the collection with elements separated by the specified separator.</returns>
    public static string Join<T>(this IEnumerable<T> source, string separator)
    {
        return string.Join(separator, source);
    }
}
