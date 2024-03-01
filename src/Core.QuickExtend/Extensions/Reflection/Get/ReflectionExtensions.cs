using System.Reflection;

namespace Core.QuickExtend.Extensions;

public static partial class ReflectionExtensions
{
    /// <summary>
    /// Extension method that returns the name of the type of an object.
    /// </summary>
    public static string GetTypeName(this object obj)
    {
        if (obj == null)
            return string.Empty;

        return obj.GetType().FullName!;
    }

    /// <summary>
    /// Extension method that returns a list containing the names of properties in the type of an object.
    /// </summary>
    public static List<string>? GetPropertyNames(this object obj)
    {
        if (obj == null)
            return null;

        Type objectType = obj.GetType();
        PropertyInfo[] properties = objectType.GetProperties();

        List<string> propertyNames = new List<string>();
        foreach (var property in properties)
        {
            propertyNames.Add(property.Name);
        }

        return propertyNames;
    }

    /// <summary>
    /// Extension method that returns a dictionary containing property names and their values from the type of an object.
    /// </summary>
    public static Dictionary<string, object>? GetPropertyValues(this object obj)
    {
        if (obj == null)
            return null;

        Type objectType = obj.GetType();
        PropertyInfo[] properties = objectType.GetProperties();

        Dictionary<string, object> propertyValues = new Dictionary<string, object>();
        foreach (var property in properties)
        {
            object? value = property.GetValue(obj);
            propertyValues.Add(property.Name, value);
        }

        return propertyValues;
    }

    /// <summary>
    /// Extension method that returns a list containing the names of methods in the type of an object.
    /// </summary>
    public static List<string>? GetMethodNames(this object obj)
    {
        if (obj == null)
            return null;

        Type objectType = obj.GetType();
        MethodInfo[] methods = objectType.GetMethods();

        List<string> methodNames = new List<string>();
        foreach (var method in methods)
        {
            methodNames.Add(method.Name);
        }

        return methodNames;
    }

    /// <summary>
    /// Extension method that returns a list containing method names and parameter information from the type of an object.
    /// </summary>
    public static List<string>? GetMethodsWithParameters(this object obj)
    {
        if (obj == null)
            return null;

        Type objectType = obj.GetType();
        MethodInfo[] methods = objectType.GetMethods();

        List<string> methodsWithParameters = new List<string>();
        foreach (var method in methods)
        {
            ParameterInfo[] parameters = method.GetParameters();
            string methodSignature = $"{method.Name}(";

            for (int i = 0; i < parameters.Length; i++)
            {
                methodSignature += $"{parameters[i].ParameterType.Name} {parameters[i].Name}";
                if (i < parameters.Length - 1)
                    methodSignature += ", ";
            }

            methodSignature += ")";
            methodsWithParameters.Add(methodSignature);
        }

        return methodsWithParameters;
    }

    /// <summary>
    /// Extension method that filters methods in the type of an object based on the value of a specific attribute.
    /// </summary>
    public static MethodInfo[]? GetMethodsByAttribute(this object obj, Type attributeType)
    {
        if (obj == null)
            return null;

        Type objectType = obj.GetType();
        MethodInfo[] methods = objectType.GetMethods();

        var filteredMethods = methods.Where(method =>
            Attribute.IsDefined(method, attributeType)
        ).ToArray();

        return filteredMethods;
    }


    /// <summary>
    /// Gets an array of methods from the provided object's type that have the specified return type.
    /// </summary>
    /// <param name="obj">The object whose type is used to retrieve methods.</param>
    /// <param name="returnType">The return type to filter the methods.</param>
    /// <returns>An array of methods with the specified return type.</returns>
    public static MethodInfo[] GetMethodsByReturnType(this object obj, Type returnType)
    {
        if (obj == null)
            return Array.Empty<MethodInfo>();

        Type type = obj.GetType();
        return type.GetMethods().Where(m => m.ReturnType == returnType).ToArray();
    }
}
