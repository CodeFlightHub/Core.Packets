using System.Reflection;

namespace Core.QuickExtend.Extensions;

public static partial class ReflectionExtensions
{
    /// <summary>
    /// Bir nesnenin belirli bir özelliğinin değerini değiştiren extension metot.
    /// </summary>
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
    /// Bir nesnenin türündeki tüm property'lerine belirli bir değeri atayan extension metot.
    /// </summary>
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
