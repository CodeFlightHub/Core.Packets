using System.Reflection;

namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class ReflectionExtensions
{
    /// <summary>
    /// Extension method that sets the value of a specified property for an object.
    /// </summary>
    /// <param name="obj">The object whose property will be modified.</param>
    /// <param name="propertyName">The name of the property to be modified.</param>
    /// <param name="newValue">The new value to be set for the property.</param>
    public static void SetPropertyByName(this object obj, string propertyName, object newValue)
    {
        if (obj == null)
            return;

        Type objectType = obj.GetType();
        PropertyInfo? propertyInfo = objectType.GetProperty(propertyName);

        if (propertyInfo != null)
            propertyInfo.SetValue(obj, newValue);
    }

    /// <summary>
    /// Extension method that sets the values of all properties for an object to a specified value.
    /// </summary>
    /// <param name="obj">The object whose properties will be modified.</param>
    /// <param name="value">The new value to be set for all properties.</param>
    public static void SetAllPropertyValues(this object obj, object value)
    {
        if (obj == null)
            return;

        Type objectType = obj.GetType();
        PropertyInfo[] properties = objectType.GetProperties();

        foreach (var property in properties)
        {
            property.SetValue(obj, value);
        }
    }
}
