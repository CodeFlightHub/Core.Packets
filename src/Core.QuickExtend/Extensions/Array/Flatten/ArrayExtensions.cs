namespace Core.QuickExtend.Extensions;

public static partial class ArrayExtensions
{
    /// <summary>
    /// Flattens a jagged array (array of arrays) into a one-dimensional array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the arrays.</typeparam>
    /// <param name="array">The jagged array to flatten.</param>
    /// <returns>A one-dimensional array containing all elements of the jagged array.</returns>
    public static T[] Flatten<T>(this T[][] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        return array.Where(subArray => subArray != null)
                    .SelectMany(subArray => subArray)
                    .ToArray();
    }

    /// <summary>
    /// Flattens a two-dimensional array into a one-dimensional array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The two-dimensional array to flatten.</param>
    /// <returns>A one-dimensional array containing all elements of the two-dimensional array.</returns>
    public static T[] Flatten<T>(this T[,] array)
    {
        if (array == null)
            throw new ArgumentNullException(nameof(array));

        List<T> result = [.. array];
        return result.ToArray();
    }
}
