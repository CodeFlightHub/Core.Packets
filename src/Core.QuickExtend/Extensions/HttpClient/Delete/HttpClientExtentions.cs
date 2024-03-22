using System.Net.Http.Json;

namespace Core.QuickExtend;

public static partial class HttpClientExtensions
{
    /// <summary>
    /// Sends a DELETE request asynchronously and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="TResponse">Type to deserialize the response content to.</typeparam>
    /// <param name="httpClient">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the deserialized response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<TResponse> CustomDeleteAsync<TResponse>(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken = default)
    {
        return await CustomDeleteAsync<TResponse>(httpClient, new Uri(requestUri), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a DELETE request asynchronously and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="TResponse">Type to deserialize the response content to.</typeparam>
    /// <param name="httpClient">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the deserialized response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<TResponse> CustomDeleteAsync<TResponse>(this HttpClient httpClient, Uri requestUri, CancellationToken cancellationToken = default)
    {
        if (requestUri == null)
        {
            throw new ArgumentNullException(nameof(requestUri));
        }

        try
        {
            using var httpResponse = await httpClient.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
            httpResponse.EnsureSuccessStatusCode();

            var response = await httpResponse.Content.ReadFromJsonAsync<TResponse>().ConfigureAwait(false);
            if (response == null)
            {
                throw new InvalidOperationException("Response is null.");
            }

            return response;
        }
        catch (HttpRequestException ex)
        {
            throw new HttpRequestException($"HTTP request failed: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Sends a DELETE request to the specified URI asynchronously and returns a boolean value indicating whether the request was successful.
    /// </summary>
    /// <param name="httpClient">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A task representing the asynchronous operation. 
    /// The task result contains a boolean value indicating whether the request was successful.
    /// Returns true if the request was successful and false if the request failed.
    /// </returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<bool> CustomDeleteAsync(this HttpClient httpClient, string requestUri, CancellationToken cancellationToken = default)
    {
        return await CustomDeleteAsync(httpClient, new Uri(requestUri), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a DELETE request to the specified URI asynchronously and returns a boolean value indicating whether the request was successful.
    /// </summary>
    /// <param name="httpClient">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>
    /// A task representing the asynchronous operation. 
    /// The task result contains a boolean value indicating whether the request was successful.
    /// Returns true if the request was successful and false if the request failed.
    /// </returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<bool> CustomDeleteAsync(this HttpClient httpClient, Uri requestUri, CancellationToken cancellationToken = default)
    {
        if (requestUri == null)
        {
            throw new ArgumentNullException(nameof(requestUri));
        }

        try
        {
            using var httpResponse = await httpClient.DeleteAsync(requestUri, cancellationToken).ConfigureAwait(false);
            httpResponse.EnsureSuccessStatusCode();
            return true;
        }
        catch (HttpRequestException ex)
        {
            throw new HttpRequestException($"HTTP request failed: {ex.Message}", ex);
        }
        catch (Exception)
        {
            return false;
        }
    }
}
