using System.Reflection;

namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class ReflectionExtensions
{
    /// <summary>
    /// Invokes the specified method by name on the provided object with the given parameters.
    /// </summary>
    /// <param name="obj">The object on which to invoke the method.</param>
    /// <param name="methodName">The name of the method to invoke.</param>
    /// <param name="parameters">The parameters to pass to the method.</param>
    public static void InvokeMethodByName(this object obj, string methodName, params object[] parameters)
    {
        if (obj == null)
            return;

        Type type = obj.GetType();
        MethodInfo? method = type.GetMethod(methodName);

        if (method == null)
            return;

        method.Invoke(obj, parameters);
    }
}
