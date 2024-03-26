using System.Text.Json;
using System.Web;

namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class UriExtensions
{
    /// <summary>
    /// Gets the file extension from the URI's absolute path.
    /// </summary>
    /// <param name="uri">The URI to extract the file extension from.</param>
    /// <returns>The file extension, including the dot, if found; otherwise, an empty string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static string GetFileExtension(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        string path = uri.AbsolutePath;
        int lastDotIndex = path.LastIndexOf('.');
        return lastDotIndex != -1 ? path.Substring(lastDotIndex) : string.Empty;
    }

    /// <summary>
    /// Gets the query parameters from the URI.
    /// </summary>
    /// <param name="uri">The URI to extract query parameters from.</param>
    /// <returns>A dictionary containing the query parameters and their values.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static Dictionary<string, string> GetQueryParameters(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        var queryString = uri.Query.TrimStart('?');
        var parameters = HttpUtility.ParseQueryString(queryString);

        return parameters.AllKeys.ToDictionary(key => key, key => parameters[key]);
    }

    /// <summary>
    /// Gets the relative path from the URI.
    /// </summary>
    /// <param name="uri">The URI to extract the relative path from.</param>
    /// <returns>The relative path portion of the URI.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static string GetRelativePath(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        return uri.IsAbsoluteUri ? uri.PathAndQuery : uri.OriginalString;
    }

    /// <summary>
    /// Gets the value of a specific query parameter from the URI.
    /// </summary>
    /// <param name="uri">The URI to extract the query parameter value from.</param>
    /// <param name="parameterName">The name of the query parameter to retrieve the value for.</param>
    /// <returns>The value of the query parameter if found; otherwise, null.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="parameterName"/> is null or empty.</exception>
    public static string GetQueryParameterValue(this Uri uri, string parameterName)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        if (string.IsNullOrEmpty(parameterName))
            throw new ArgumentException("Parameter name cannot be null or empty.", nameof(parameterName));

        var queryParameters = uri.Query.TrimStart('?')
            .Split('&')
            .Select(p => p.Split('='))
            .ToDictionary(pair => pair[0], pair => pair.Length > 1 ? pair[1] : null);

        if (queryParameters.ContainsKey(parameterName))
            return queryParameters[parameterName];
        else
            return null;
    }

    /// <summary>
    /// Gets the email address from the URI if it represents a mailto URI.
    /// </summary>
    /// <param name="uri">The URI to extract the email address from.</param>
    /// <returns>The email address if the URI is a mailto URI; otherwise, an InvalidOperationException is thrown.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the URI is not a mailto URI.</exception>
    public static string GetEmailAddress(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        if (!uri.IsMailtoUri())
            throw new InvalidOperationException("The URI is not a mailto URI.");

        return uri.AbsoluteUri.Substring("mailto:".Length);
    }

    /// <summary>
    /// Gets the phone number from the tel URI.
    /// </summary>
    /// <param name="uri">The tel URI to extract the phone number from.</param>
    /// <returns>The phone number.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when the URI is not a tel URI.</exception>
    public static string GetPhoneNumber(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        if (!uri.IsTelUri())
            throw new InvalidOperationException("The URI is not a tel URI.");

        string phoneNumber = uri.AbsolutePath;
        // 'tel:' kısmını çıkar
        phoneNumber = phoneNumber.Replace("tel:", "");
        return phoneNumber;
    }

    /// <summary>
    /// Gets the subdomain from the URI's host.
    /// </summary>
    /// <param name="uri">The URI to extract the subdomain from.</param>
    /// <returns>The subdomain, or an empty string if not found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static string GetSubdomain(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        string[] hostSegments = uri.Host.Split('.');
        return hostSegments.Length > 2 ? hostSegments[0] : string.Empty;
    }

    /// <summary>
    /// Gets the file name from the URI's absolute path.
    /// </summary>
    /// <param name="uri">The URI to extract the file name from.</param>
    /// <returns>The file name, or an empty string if not found.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static string GetFileName(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        string path = uri.AbsolutePath;
        int index = path.LastIndexOf('/');
        if (index >= 0 && index < path.Length - 1)
            return path.Substring(index + 1);
        return string.Empty;
    }

    /// <summary>
    /// Parses the query parameters from the URI and returns them as a JSON string.
    /// </summary>
    /// <param name="uri">The URI to extract the query parameters from.</param>
    /// <returns>A JSON string representing the query parameters.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static string GetQueryStringAsJson(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        var queryParameters = System.Web.HttpUtility.ParseQueryString(uri.Query);
        var dictionary = new Dictionary<string, string>();

        foreach (var key in queryParameters.AllKeys)
        {
            dictionary[key] = queryParameters[key];
        }

        return JsonSerializer.Serialize(dictionary);
    }
}
