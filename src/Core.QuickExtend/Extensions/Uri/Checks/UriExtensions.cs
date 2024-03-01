namespace Core.QuickExtend.Extensions;

public static partial class UriExtensions
{
    /// <summary>
    /// Determines whether the URI represents a web resource using the HTTP or HTTPS scheme.
    /// </summary>
    /// <param name="uri">The URI to check.</param>
    /// <returns>True if the URI is a web resource (HTTP or HTTPS), otherwise false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static bool IsWebResource(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        return uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps;
    }


    /// <summary>
    /// Determines whether the URI is secure, i.e., it uses the HTTPS scheme.
    /// </summary>
    /// <param name="uri">The URI to check.</param>
    /// <returns>True if the URI uses the HTTPS scheme, otherwise false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static bool IsSecure(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        return uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase);
    }


    /// <summary>
    /// Determines whether the URI has a specific query parameter.
    /// </summary>
    /// <param name="uri">The URI to check.</param>
    /// <param name="parameterName">The name of the query parameter to search for.</param>
    /// <returns>True if the URI has the specified query parameter, otherwise false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="parameterName"/> is null or empty.</exception>
    public static bool HasQueryParameter(this Uri uri, string parameterName)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        if (string.IsNullOrEmpty(parameterName))
            throw new ArgumentException("Parameter name cannot be null or empty.", nameof(parameterName));

        var queryParameters = uri.Query.TrimStart('?')
            .Split('&')
            .Select(p => p.Split('=')[0])
            .ToList();

        return queryParameters.Contains(parameterName);
    }


    /// <summary>
    /// Determines whether the URI represents a mailto URI.
    /// </summary>
    /// <param name="uri">The URI to check.</param>
    /// <returns>True if the URI represents a mailto URI, otherwise false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static bool IsMailtoUri(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        return uri.Scheme == Uri.UriSchemeMailto;
    }


    /// <summary>
    /// Determines whether the URI represents a tel URI.
    /// </summary>
    /// <param name="uri">The URI to check.</param>
    /// <returns>True if the URI represents a tel URI, otherwise false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static bool IsTelUri(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        return uri.Scheme == "tel";
    }


    /// <summary>
    /// Determines whether the URI has the specified subdomain.
    /// </summary>
    /// <param name="uri">The URI to check.</param>
    /// <param name="subdomain">The subdomain to search for.</param>
    /// <returns>True if the URI has the specified subdomain, otherwise false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="subdomain"/> is null or empty.</exception>
    public static bool HasSubdomain(this Uri uri, string subdomain)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        if (string.IsNullOrEmpty(subdomain))
            throw new ArgumentException("Subdomain cannot be null or empty.", nameof(subdomain));

        string[] hostSegments = uri.Host.Split('.');
        return hostSegments.Length > 2 && hostSegments[0] == subdomain;
    }

    /// <summary>
    /// Determines whether the URI contains the specified path.
    /// </summary>
    /// <param name="uri">The URI to check.</param>
    /// <param name="path">The path to search for.</param>
    /// <returns>True if the URI contains the specified path, otherwise false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="path"/> is null or empty.</exception>
    public static bool ContainsPath(this Uri uri, string path)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        if (string.IsNullOrEmpty(path))
            throw new ArgumentException("Path cannot be null or empty.", nameof(path));

        return uri.AbsolutePath.Contains(path);
    }


    /// <summary>
    /// Determines whether the URI has the specified file name in its path.
    /// </summary>
    /// <param name="uri">The URI to check.</param>
    /// <param name="fileName">The file name to search for.</param>
    /// <returns>True if the URI has the specified file name, otherwise false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="fileName"/> is null or empty.</exception>
    public static bool HasFileName(this Uri uri, string fileName)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        if (string.IsNullOrEmpty(fileName))
            throw new ArgumentException("File name cannot be null or empty.", nameof(fileName));

        string path = uri.AbsolutePath;
        int index = path.LastIndexOf('/');
        if (index >= 0 && index < path.Length - 1)
        {
            string uriFileName = path.Substring(index + 1);
            return uriFileName.Equals(fileName, StringComparison.OrdinalIgnoreCase);
        }
        return false;
    }


    /// <summary>
    /// Determines whether the URI is a valid HTTP or HTTPS URL.
    /// </summary>
    /// <param name="uri">The URI to check.</param>
    /// <returns>True if the URI is a valid HTTP or HTTPS URL, otherwise false.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    public static bool IsValidUrl(this Uri uri)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        return Uri.TryCreate(uri.AbsoluteUri, UriKind.Absolute, out _) &&
               (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }

}
