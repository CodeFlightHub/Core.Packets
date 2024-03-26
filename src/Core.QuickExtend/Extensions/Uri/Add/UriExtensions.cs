using System.Web;

namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class UriExtensions
{
    /// <summary>
    /// Appends the specified <paramref name="newPath"/> to the end of the URI path.
    /// </summary>
    /// <param name="uri">The base URI.</param>
    /// <param name="newPath">The new path segment to append.</param>
    /// <returns>A new URI with the appended path.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="newPath"/> is null or empty.</exception>
    public static Uri AppendPath(this Uri uri, string newPath)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        if (string.IsNullOrWhiteSpace(newPath))
            throw new ArgumentException("New path cannot be null or empty.", nameof(newPath));

        UriBuilder builder = new UriBuilder(uri);
        string baseUrl = builder.Scheme + "://" + builder.Host;
        if (builder.Port != 80 && builder.Port != 443)
        {
            baseUrl += ":" + builder.Port;
        }

        string newPathWithSlash = newPath.StartsWith("/") ? newPath : "/" + newPath;
        builder.Path = builder.Path.TrimEnd('/') + newPathWithSlash;

        return builder.Uri;
    }

    /// <summary>
    /// Adds or updates the query parameter with the specified <paramref name="key"/> and <paramref name="value"/> to the URI.
    /// </summary>
    /// <param name="uri">The base URI.</param>
    /// <param name="key">The key of the query parameter.</param>
    /// <param name="value">The value of the query parameter.</param>
    /// <returns>A new URI with the added or updated query parameter.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="uri"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when <paramref name="key"/> is null or empty.</exception>
    public static Uri AddOrUpdateQueryParameter(this Uri uri, string key, string value)
    {
        if (uri == null)
            throw new ArgumentNullException(nameof(uri));

        if (string.IsNullOrWhiteSpace(key))
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));

        string query = uri.Query;
        var queryParameters = HttpUtility.ParseQueryString(query);
        queryParameters[key] = value;

        var uriBuilder = new UriBuilder(uri)
        {
            Query = queryParameters.ToString()
        };

        return uriBuilder.Uri;
    }

    /// <summary>
    /// Appends the query parameter with the specified <paramref name="key"/> and <paramref name="value"/> to the URI.
    /// If the query parameter with the specified <paramref name="key"/> already exists, updates its value.
    /// </summary>
    /// <param name="uri">The base URI.</param>
    /// <param name="key">The key of the query parameter.</param>
    /// <param name="value">The value of the query parameter.</param>
    /// <returns>A new URI with the appended or updated query parameter.</returns>
    public static Uri AppendQueryParameter(this Uri uri, string key, string value)
    {
        var uriBuilder = new UriBuilder(uri);
        var query = HttpUtility.ParseQueryString(uriBuilder.Query);

        if (query.AllKeys.Contains(key))
            query[key] = value;
        else
            query.Add(key, value);

        uriBuilder.Query = query.ToString();
        return new Uri(uriBuilder.ToString());
    }
}
