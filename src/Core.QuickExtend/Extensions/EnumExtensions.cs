using System.ComponentModel;

namespace Core.QuickExtend.Extensions;

public static class EnumExtensions
{
    /// <summary>
    /// Gets the description of an Enum item.
    /// </summary>
    /// <param name="value">Enum item.</param>
    /// <returns>Description of the Enum item or its name.</returns>
    public static string GetDescription(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = Attribute.GetCustomAttribute(field!, typeof(DescriptionAttribute)) as DescriptionAttribute;

        return attribute?.Description ?? value.ToString();
    }

    /// <summary>
    /// Searches for a specified string value within an Enum and returns the first matching Enum item.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    /// <param name="value">Searched string value.</param>
    /// <returns>Found Enum item or the default Enum item.</returns>
    public static T ParseFromString<T>(this string value) where T : Enum
    {
        return (T)Enum.Parse(typeof(T), value, true);
    }

    /// <summary>
    /// Gets the value (integer value) of an Enum item.
    /// </summary>
    /// <param name="enumValue">Enum item.</param>
    /// <returns>Value of the Enum item (integer).</returns>
    public static int GetValue(this Enum enumValue)
    {
        return Convert.ToInt32(enumValue);
    }

    /// <summary>
    /// Gets the count of items in an Enum type.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    /// <returns>Number of items in the Enum type.</returns>
    public static int GetCount<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T)).Length;
    }

    /// <summary>
    /// Gets all items in an Enum type as an array.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    /// <returns>Array containing all items in the Enum type.</returns>
    public static T[] GetValues<T>() where T : Enum
    {
        return (T[])Enum.GetValues(typeof(T));
    }

    /// <summary>
    /// Gets the next value of an Enum item. If it is the last item, returns the first item.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    /// <param name="enumValue">Enum item.</param>
    /// <returns>Next Enum item.</returns>
    public static T GetNextValue<T>(this T enumValue) where T : Enum
    {
        T[] values = GetValues<T>();
        int currentIndex = Array.IndexOf(values, enumValue);
        int nextIndex = (currentIndex + 1) % values.Length;
        return values[nextIndex];
    }

    /// <summary>
    /// Gets the previous value of an Enum item. If it is the first item, returns the last item.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    /// <param name="enumValue">Enum item.</param>
    /// <returns>Previous Enum item.</returns>
    public static T GetPreviousValue<T>(this T enumValue) where T : Enum
    {
        T[] values = GetValues<T>();
        int currentIndex = Array.IndexOf(values, enumValue);
        int previousIndex = (currentIndex - 1 + values.Length) % values.Length;
        return values[previousIndex];
    }

    /// <summary>
    /// Gets the values of items in an Enum type as strings in a list.
    /// </summary>
    /// <typeparam name="T">Enum type.</typeparam>
    /// <returns>List containing the values of items in the Enum type as strings.</returns>
    public static IQueryable<string> GetValuesAsStrings<T>() where T : Enum
    {
        return Enum.GetValues(typeof(T)).Cast<T>().Select(e => e.ToString()).AsQueryable();
    }

}
