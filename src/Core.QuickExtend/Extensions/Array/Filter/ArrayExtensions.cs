namespace Core.QuickExtend.Extensions;

public static partial class ArrayExtensions
{
    /// <summary>
    /// Filters the elements of an array based on a specified predicate function and returns a new array containing the filtered elements in reverse order.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to filter.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>An array containing the filtered elements in reverse order.</returns>
    public static T[] FilterElements<T>(this T[] array, Func<T, bool> predicate)
    {
        if (array.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(array));

        var filteredArray = array.Where(predicate).ToArray();
        Array.Reverse(filteredArray);
        return filteredArray;
    }

    /// <summary>
    /// Filters the elements of an array based on a specified predicate function and sorts the filtered elements using the specified comparison function.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to filter and sort.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="comparison">A comparison function to compare elements.</param>
    /// <returns>An array containing the filtered and sorted elements.</returns>
    public static T[] FilterAndSort<T>(this T[] array, Func<T, bool> predicate, Comparison<T> comparison)
    {
        if (array.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(array));

        var filteredArray = array.Where(predicate).ToArray();
        Array.Sort(filteredArray, comparison);
        return filteredArray;
    }

    /// <summary>
    /// Filters the elements of an array based on a specified predicate function and optionally sorts the filtered elements in ascending or descending order.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to filter and sort.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <param name="ascending">A boolean value indicating whether to sort the filtered elements in ascending order (default is true).</param>
    /// <returns>An array containing the filtered and optionally sorted elements.</returns>
    public static T[] FilterAndSort<T>(this T[] array, Func<T, bool> predicate, bool ascending = true)
    {
        if (array.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(array));

        var filteredArray = array.Where(predicate).ToArray();

        if (ascending)
        {
            Array.Sort(filteredArray);
        }
        else
        {
            Array.Sort(filteredArray, (x, y) => Comparer<T>.Default.Compare(y, x));
        }

        return filteredArray;
    }
}
