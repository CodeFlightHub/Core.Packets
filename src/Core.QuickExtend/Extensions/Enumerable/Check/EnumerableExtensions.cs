namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class EnumerableExtensions
{
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
}
