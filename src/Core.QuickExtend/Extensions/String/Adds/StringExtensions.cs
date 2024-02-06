namespace Core.QuickExtend.Extensions;

public static partial class StringExtensions
{
    /// <summary>
    /// Adds a suffix to a string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="suffix">The suffix to be added.</param>
    /// <param name="includeSpace">A parameter indicating whether to include a space (default is true).</param>
    /// <returns>String with the suffix added.</returns>
    public static string AddSuffix(this string input, string suffix, bool includeSpace = true)
    {
        string space = includeSpace ? " " : "";
        return String.Concat(input, space, suffix);
    }

    /// <summary>
    /// Adds a prefix to a string.
    /// </summary>
    /// <param name="input">The input string.</param>
    /// <param name="prefix">The prefix to be added.</param>
    /// <param name="includeSpace">A parameter indicating whether to include a space (default is true).</param>
    /// <returns>String with the prefix added.</returns>
    public static string AddPrefix(this string input, string prefix, bool includeSpace = true)
    {
        string space = includeSpace ? " " : "";
        return String.Concat(prefix, space, input);
    }
}
