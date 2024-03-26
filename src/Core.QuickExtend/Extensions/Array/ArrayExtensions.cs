namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class ArrayExtensions
{
    private static Random rng = new Random();

    /// <summary>
    /// Randomly shuffles the elements of the specified array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to shuffle.</param>
    public static void Shuffle<T>(this T[] array)
    {

        if (array == null)
            throw new ArgumentNullException(nameof(array));

        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }

    /// <summary>
    /// Fills the elements of an array with the specified value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to fill.</param>
    /// <param name="value">The value to fill the array with.</param>
    public static void Fill<T>(this T[] array, T value)
    {
        if (array.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(array));

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }
    }

    /// <summary>
    /// Computes the sum of the elements in an integer array.
    /// </summary>
    /// <param name="array">The integer array to compute the sum of.</param>
    /// <returns>The sum of the elements in the array.</returns>
    public static int Sum(this int[] array)
    {
        if (array.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(array));

        int sum = 0;
        foreach (int item in array)
        {
            sum += item;
        }
        return sum;
    }

    /// <summary>
    /// Computes the average of the elements in an integer array.
    /// </summary>
    /// <param name="array">The integer array to compute the average of.</param>
    /// <returns>The average of the elements in the array.</returns>
    public static double Average(this int[] array)
    {
        if (array.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(array));


        int sum = array.Sum();
        return (double)sum / array.Length;
    }

    /// <summary>
    /// Resizes the specified array to the specified new size.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to resize.</param>
    /// <param name="newSize">The new size of the array.</param>
    /// <returns>The resized array.</returns>
    public static T[] Resize<T>(this T[] array, int newSize)
    {
        if (array.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(array));


        Array.Resize(ref array, newSize);
        return array;
    }

    /// <summary>
    /// Determines whether all elements in the array match the conditions defined by the specified predicate.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to check.</param>
    /// <param name="match">The predicate function that defines the conditions to check against the elements.</param>
    /// <returns>true if all elements in the array match the conditions defined by the specified predicate; otherwise, false.</returns>
    public static bool AllElements<T>(this T[] array, Predicate<T> match)
    {
        if (array.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(array));

        return Array.TrueForAll(array, match);
    }

    /// <summary>
    /// Partitions the elements of the array into two groups based on a specified predicate function.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to partition.</param>
    /// <param name="predicate">A function to test each element for a condition.</param>
    /// <returns>A tuple containing two arrays: the first array contains elements that satisfy the predicate, and the second array contains elements that do not satisfy the predicate.</returns>
    public static Tuple<T[], T[]> Partition<T>(this T[] array, Func<T, bool> predicate)
    {
        if (array.IsNullOrEmpty())
            return new Tuple<T[], T[]>(new T[0], new T[0]);

        var partitioned = array.GroupBy(predicate);
        var trueGroup = partitioned.FirstOrDefault(g => g.Key);
        var falseGroup = partitioned.FirstOrDefault(g => !g.Key);

        return new Tuple<T[], T[]>(trueGroup?.ToArray() ?? new T[0], falseGroup?.ToArray() ?? new T[0]);
    }

    /// <summary>
    /// Replaces all occurrences of a specified value in the array with a new value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array in which to perform replacements.</param>
    /// <param name="oldValue">The value to replace.</param>
    /// <param name="newValue">The new value.</param>
    public static void Replace<T>(this T[] array, T oldValue, T newValue)
    {
        if (array.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(array));

        for (int i = 0; i < array.Length; i++)
        {
            if (EqualityComparer<T>.Default.Equals(array[i], oldValue))
            {
                array[i] = newValue;
            }
        }
    }

    /// <summary>
    /// Sets all elements of the array to the specified value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to set all elements.</param>
    /// <param name="value">The value to set all elements to.</param>
    public static void SetAll<T>(this T[] array, T value)
    {
        if (array.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(array));

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = value;
        }
    }

    /// <summary>
    /// Returns a new array that is a shallow copy of a portion of the original array between the specified start and end indices.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array to slice.</param>
    /// <param name="start">The starting index of the slice (inclusive).</param>
    /// <param name="end">The ending index of the slice (exclusive).</param>
    /// <returns>A new array containing elements from the original array between the specified start and end indices.</returns>
    public static T[] Slice<T>(this T[] array, int start, int end)
    {
        if (array.IsNullOrEmpty())
            throw new ArgumentNullException(nameof(array));

        if (start < 0) start = array.Length + start;
        if (end < 0) end = array.Length + end;
        int length = end - start;
        T[] result = new T[length];
        Array.Copy(array, start, result, 0, length);
        return result;
    }

    /// <summary>
    /// Returns a new array containing only the unique elements from the original array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="array">The array from which to remove duplicates.</param>
    /// <returns>An array containing only the unique elements from the original array.</returns>
    public static T[] RemoveDuplicates<T>(this T[] array)
    {
        HashSet<T> uniqueElements = new HashSet<T>();
        return array.Where(x => uniqueElements.Add(x)).ToArray();
    }

    /// <summary>
    /// Determines whether the elements in the array are sorted in non-descending order.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array, which must implement the <see cref="IComparable"/> interface.</typeparam>
    /// <param name="array">The array to check for sortedness.</param>
    /// <returns>true if the elements in the array are sorted in non-descending order; otherwise, false.</returns>
    public static bool IsSorted<T>(this T[] array) where T : IComparable
    {
        if (array.IsNullOrEmpty())
            return true;


        for (int i = 1; i < array.Length; i++)
        {
            if (array[i - 1].CompareTo(array[i]) > 0)
            {
                return false;
            }
        }
        return true;
    }
}
