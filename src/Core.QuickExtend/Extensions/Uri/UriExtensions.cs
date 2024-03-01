using System.Text.Json;
using System.Web;

namespace Core.QuickExtend.Extensions;

public static partial class UriExtensions {

    /// <summary>
    /// Parses the query parameters from the URI and returns them as a dictionary.
    /// </summary>
    /// <param name="uri">The URI to parse the query parameters from.</param>
    /// <returns>A dictionary containing the query parameters and their values.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static Dictionary<string, string> ParseQueryString(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        var queryParameters = HttpUtility.ParseQueryString(uri.Query);
        var dictionary = new Dictionary<string, string>();

        foreach (var key in queryParameters.AllKeys)
        {
            dictionary[key] = queryParameters[key];
        }

        return dictionary;
    }
}
