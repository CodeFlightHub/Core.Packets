using System.ComponentModel.DataAnnotations;

namespace Core.QuickExtend.Extensions;

public static partial class EnumExtensions
{
    /// <summary>
    /// Gets the display name of an Enum item using the DisplayAttribute.
    /// If the DisplayAttribute is not present, returns the name of the Enum item.
    /// </summary>
    /// <param name="value">Enum item.</param>
    /// <returns>Display name of the Enum item or its name.</returns>
    public static string GetDisplayName(this Enum value)
    {
        var field = value.GetType().GetField(value.ToString());
        var attribute = Attribute.GetCustomAttribute(field!, typeof(DisplayAttribute)) as DisplayAttribute;

        return attribute?.Name ?? value.ToString();
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
}
