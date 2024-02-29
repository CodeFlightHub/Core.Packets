using System.Net.Http.Json;

namespace Core.QuickExtend;
public static partial class HttpClientExtensions
{
    /// <summary>
    /// Sends a PUT request with JSON content asynchronously and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="TResponse">Type to deserialize the response content to.</typeparam>
    /// <typeparam name="TRequest">Type of the request data.</typeparam>
    /// <param name="httpClient">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="requestData">The data to serialize as JSON in the request body.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the deserialized response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<TResponse> PutJsonAsync<TResponse, TRequest>(this HttpClient httpClient, string requestUri, TRequest requestData, CancellationToken cancellationToken = default)
    {
        return await PutJsonAsync<TResponse, TRequest>(httpClient, new Uri(requestUri), requestData, cancellationToken).ConfigureAwait(false);
    }


    /// <summary>
    /// Sends a PUT request with JSON content asynchronously and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="TResponse">Type to deserialize the response content to.</typeparam>
    /// <typeparam name="TRequest">Type of the request data.</typeparam>
    /// <param name="httpClient">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="requestData">The data to serialize as JSON in the request body.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the deserialized response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<TResponse> PutJsonAsync<TResponse, TRequest>(this HttpClient httpClient, Uri requestUri, TRequest requestData, CancellationToken cancellationToken = default)
    {
        if (requestUri == null)
        {
            throw new ArgumentNullException(nameof(requestUri));
        }

        if (requestData == null)
        {
            throw new ArgumentNullException(nameof(requestData));
        }

        try
        {
            using var httpResponse = await httpClient.PutAsJsonAsync(requestUri, requestData, cancellationToken).ConfigureAwait(false);
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

}


