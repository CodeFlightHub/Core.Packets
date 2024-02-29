using System.Drawing;
using System.Net.Http.Json;
using System.Xml.Serialization;


namespace Core.QuickExtend;
public static partial class HttpClientExtensions
{
    /// <summary>
    /// Sends a GET request and deserializes the JSON response to the specified type.
    /// </summary>
    /// <typeparam name="TResponse">Type to deserialize the JSON response content to.</typeparam>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the deserialized response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<TResponse> GetAsJsonAsync<TResponse>(this HttpClient client, string requestUri, CancellationToken cancellationToken = default)
    {
        return await GetAsJsonAsync<TResponse>(client, new Uri(requestUri), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a GET request and deserializes the JSON response to the specified type.
    /// </summary>
    /// <typeparam name="TResponse">Type to deserialize the JSON response content to.</typeparam>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the deserialized response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<TResponse> GetAsJsonAsync<TResponse>(this HttpClient client, Uri requestUri, CancellationToken cancellationToken = default)
    {
        if (requestUri == null)
        {
            throw new ArgumentNullException(nameof(requestUri));
        }

        try
        {
            HttpResponseMessage response = await client.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            var jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(jsonResponse))
            {
                throw new InvalidOperationException("Response content is null or empty.");
            }

            return await response.Content.ReadFromJsonAsync<TResponse>().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"HTTP request failed: {ex.Message}", ex);
        }
    }


    /// <summary>
    /// Sends a GET request and deserializes the XML response to the specified type.
    /// </summary>
    /// <typeparam name="T">Type to deserialize the XML response content to.</typeparam>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the deserialized response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<T> GetAsXmlAsync<T>(this HttpClient client, string requestUri, CancellationToken cancellationToken = default)
    {
        return await GetAsXmlAsync<T>(client, new Uri(requestUri), cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a GET request and deserializes the XML response to the specified type.
    /// </summary>
    /// <typeparam name="T">Type to deserialize the XML response content to.</typeparam>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the deserialized response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<T> GetAsXmlAsync<T>(this HttpClient client, Uri requestUri, CancellationToken cancellationToken = default)
    {
        if (requestUri == null)
        {
            throw new ArgumentNullException(nameof(requestUri));
        }

        try
        {
            HttpResponseMessage response = await client.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            using var stream = await response.Content.ReadAsStreamAsync();
            if (stream == null || stream.Length == 0)
            {
                throw new InvalidOperationException("XML response is null or empty.");
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T deserializedObject = (T)serializer.Deserialize(stream);

            if (deserializedObject == null)
            {
                throw new InvalidOperationException("Deserialized object is null.");
            }

            return deserializedObject;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to deserialize XML response: {ex.Message}", ex);
        }
    }


    /// <summary>
    /// Sends a GET request and returns the response content as a byte array.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the response content as a byte array.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<byte[]> GetAsByteArrayAsync(this HttpClient client, string requestUri, CancellationToken cancellationToken = default)
    {
        return await GetAsByteArrayAsync(client, new Uri(requestUri), cancellationToken).ConfigureAwait(false);
    }


    /// <summary>
    /// Sends a GET request and returns the response content as a byte array.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the response content as a byte array.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<byte[]> GetAsByteArrayAsync(this HttpClient client, Uri requestUri, CancellationToken cancellationToken = default)
    {
        if (requestUri == null)
        {
            throw new ArgumentNullException(nameof(requestUri));
        }

        try
        {
            HttpResponseMessage response = await client.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            byte[] byteArray = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            if (byteArray == null)
            {
                throw new InvalidOperationException("Byte array is null.");
            }

            return byteArray;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to get byte array: {ex.Message}", ex);
        }
    }


    /// <summary>
    /// Sends a GET request and returns the response content as an Image object.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the response content as an Image object.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<Image> GetAsImageAsync(this HttpClient client, string requestUri, CancellationToken cancellationToken = default)
    {
        return await GetAsImageAsync(client, new Uri(requestUri), cancellationToken).ConfigureAwait(false);
    }


    /// <summary>
    /// Sends a GET request and returns the response content as an Image object.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the response content as an Image object.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<Image> GetAsImageAsync(this HttpClient client, Uri requestUri, CancellationToken cancellationToken = default)
    {
        if (requestUri == null)
        {
            throw new ArgumentNullException(nameof(requestUri));
        }

        try
        {
            byte[] imageBytes = await client.GetAsByteArrayAsync(requestUri, cancellationToken).ConfigureAwait(false);

            using (MemoryStream ms = new MemoryStream(imageBytes))
            {
                // Check if the image bytes represent a valid image
                Image image = Image.FromStream(ms);
                if (image.Width <= 0 || image.Height <= 0)
                {
                    throw new InvalidOperationException("Invalid image format.");
                }
                return image;
            }
        }
        catch (ArgumentException)
        {
            throw new InvalidOperationException("Invalid image format.");
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to get image: {ex.Message}", ex);
        }
    }


    /// <summary>
    /// Sends a GET request and returns the response content as a Stream.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the response content as a Stream.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<Stream> GetAsStreamAsync(this HttpClient client, string requestUri, CancellationToken cancellationToken = default)
    {
        return await GetAsStreamAsync(client, new Uri(requestUri), cancellationToken).ConfigureAwait(false);
    }


    /// <summary>
    /// Sends a GET request and returns the response content as a Stream.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the response content as a Stream.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<Stream> GetAsStreamAsync(this HttpClient client, Uri requestUri, CancellationToken cancellationToken = default)
    {

        if (requestUri == null)
        {
            throw new ArgumentNullException(nameof(requestUri));
        }

        try
        {
            HttpResponseMessage response = await client.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            Stream stream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
            if (stream == null)
            {
                throw new InvalidOperationException("Stream is null.");
            }

            return stream;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to get stream: {ex.Message}", ex);
        }
    }


    /// <summary>
    /// Sends a GET request and returns the response content as a string.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the response content as a string.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<string> GetAsStringAsync(this HttpClient client, string requestUri, CancellationToken cancellationToken = default)
    {
        return await GetAsStringAsync(client, new Uri(requestUri), cancellationToken).ConfigureAwait(false);
    }


    /// <summary>
    /// Sends a GET request and returns the response content as a string.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the response content as a string.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<string> GetAsStringAsync(this HttpClient client, Uri requestUri, CancellationToken cancellationToken = default)
    {
        if (requestUri == null)
        {
            throw new ArgumentNullException(nameof(requestUri));
        }


        try
        {
            HttpResponseMessage response = await client.GetAsync(requestUri, cancellationToken).ConfigureAwait(false);
            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (content == null)
            {
                throw new InvalidOperationException("String content is null.");
            }

            return content;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to get string: {ex.Message}", ex);
        }
    }

}


