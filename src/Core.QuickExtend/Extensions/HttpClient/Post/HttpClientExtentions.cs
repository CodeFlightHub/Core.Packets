using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Xml.Serialization;

namespace Core.QuickExtend;

public static partial class HttpClientExtensions
{
    /// <summary>
    /// Sends a POST request with JSON content asynchronously and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="TResponse">Type to deserialize the response content to.</typeparam>
    /// <typeparam name="TRequest">Type of the request data.</typeparam>
    /// <param name="httpClient">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="requestData">The data to serialize as JSON in the request body.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the deserialized response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<TResponse> PostJsonAsync<TResponse, TRequest>(this HttpClient httpClient, string requestUri, TRequest requestData, CancellationToken cancellationToken = default)
    {
        return await PostJsonAsync<TResponse, TRequest>(httpClient, new Uri(requestUri), requestData, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a POST request with JSON content asynchronously and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="TResponse">Type to deserialize the response content to.</typeparam>
    /// <typeparam name="TRequest">Type of the request data.</typeparam>
    /// <param name="httpClient">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="requestData">The data to serialize as JSON in the request body.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the deserialized response.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<TResponse> PostJsonAsync<TResponse, TRequest>(this HttpClient httpClient, Uri requestUri, TRequest requestData, CancellationToken cancellationToken = default)
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
            using var httpResponse = await httpClient.PostAsJsonAsync(requestUri, requestData, cancellationToken).ConfigureAwait(false);
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
    /// Sends a POST request with XML content asynchronously and returns the HttpResponseMessage.
    /// </summary>
    /// <typeparam name="T">Type of the data to be serialized as XML.</typeparam>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="data">The data to serialize as XML in the request body.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the HttpResponseMessage.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<HttpResponseMessage> PostAsXmlAsync<T>(this HttpClient client, string requestUri, T data, CancellationToken cancellationToken = default)
    {
        return await PostAsXmlAsync<T>(client, new Uri(requestUri), data, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a POST request with XML content asynchronously and returns the HttpResponseMessage.
    /// </summary>
    /// <typeparam name="T">Type of the data to be serialized as XML.</typeparam>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="data">The data to serialize as XML in the request body.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the HttpResponseMessage.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<HttpResponseMessage> PostAsXmlAsync<T>(this HttpClient client, Uri requestUri, T data, CancellationToken cancellationToken = default)
    {

        if (data == null)
        {
            throw new ArgumentNullException(nameof(data));
        }


        try
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, data);
                string xmlData = writer.ToString();
                HttpContent content = new StringContent(xmlData, Encoding.UTF8, "application/xml");

                using (HttpResponseMessage response = await client.PostAsync(requestUri, content, cancellationToken).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    return response;
                }
            }
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to post XML data: {ex.Message}", ex);
        }
    }


    /// <summary>
    /// Sends a POST request with form data asynchronously and returns the HttpResponseMessage.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="formData">The form data to send in the request body.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the HttpResponseMessage.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<HttpResponseMessage> PostAsFormDataAsync(this HttpClient client, string requestUri, IEnumerable<KeyValuePair<string, string>> formData, CancellationToken cancellationToken = default)
    {
        return await PostAsFormDataAsync(client, new Uri(requestUri), formData, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a POST request with form data asynchronously and returns the HttpResponseMessage.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="formData">The form data to send in the request body.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the HttpResponseMessage.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<HttpResponseMessage> PostAsFormDataAsync(this HttpClient client, Uri requestUri, IEnumerable<KeyValuePair<string, string>> formData, CancellationToken cancellationToken = default)
    {
        try
        {
            if (formData == null)
            {
                throw new ArgumentNullException(nameof(formData), "Form data cannot be null.");
            }

            FormUrlEncodedContent content = new FormUrlEncodedContent(formData);

            using (HttpResponseMessage response = await client.PostAsync(requestUri, content, cancellationToken).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                return response;
            }
        }
        catch (ArgumentNullException)
        {
            throw;
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to post form data: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Sends a POST request with stream content asynchronously and returns the HttpResponseMessage.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="stream">The stream to send in the request body.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the HttpResponseMessage.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<HttpResponseMessage> PostAsStreamAsync(this HttpClient client, string requestUri, Stream stream, CancellationToken cancellationToken = default)
    {
        return await PostAsStreamAsync(client, new Uri(requestUri), stream, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a POST request with stream content asynchronously and returns the HttpResponseMessage.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="stream">The stream to send in the request body.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the HttpResponseMessage.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<HttpResponseMessage> PostAsStreamAsync(this HttpClient client, Uri requestUri, Stream stream, CancellationToken cancellationToken = default)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream), "Stream cannot be null.");
        }

        try
        {
            HttpContent content = new StreamContent(stream);

            using (HttpResponseMessage response = await client.PostAsync(requestUri, content, cancellationToken).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                return response;
            }
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to post stream: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Sends a POST request with byte array content asynchronously and returns the HttpResponseMessage.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="content">The byte array to send in the request body.</param>
    /// <param name="mediaType">The media type of the byte array content. Default is "application/octet-stream".</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the HttpResponseMessage.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<HttpResponseMessage> PostByteArrayAsync(this HttpClient client, string requestUri, byte[] content, string mediaType = "application/octet-stream", CancellationToken cancellationToken = default)
    {
        return await PostByteArrayAsync(client, new Uri(requestUri), content, mediaType, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a POST request with byte array content asynchronously and returns the HttpResponseMessage.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="content">The byte array to send in the request body.</param>
    /// <param name="mediaType">The media type of the byte array content. Default is "application/octet-stream".</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the HttpResponseMessage.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<HttpResponseMessage> PostByteArrayAsync(this HttpClient client, Uri requestUri, byte[] content, string mediaType = "application/octet-stream", CancellationToken cancellationToken = default)
    {
        if (content == null)
        {
            throw new ArgumentNullException(nameof(content), "Content cannot be null.");
        }

        try
        {
            HttpContent httpContent = new ByteArrayContent(content);
            httpContent.Headers.ContentType = new MediaTypeHeaderValue(mediaType);

            using (HttpResponseMessage response = await client.PostAsync(requestUri, httpContent, cancellationToken).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                return response;
            }
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to post byte array: {ex.Message}", ex);
        }
    }

    /// <summary>
    /// Sends a POST request with a file asynchronously and returns the HttpResponseMessage.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="fileBytes">The byte array representing the file to send in the request body.</param>
    /// <param name="fileName">The name of the file.</param>
    /// <param name="mediaType">The media type of the file content. Default is "application/octet-stream".</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the HttpResponseMessage.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<HttpResponseMessage> PostFileAsync(this HttpClient client, string requestUri, byte[] fileBytes, string fileName, string mediaType = "application/octet-stream", CancellationToken cancellationToken = default)
    {
        return await PostFileAsync(client, new Uri(requestUri), fileBytes, fileName, mediaType, cancellationToken).ConfigureAwait(false);
    }

    /// <summary>
    /// Sends a POST request with a file asynchronously and returns the HttpResponseMessage.
    /// </summary>
    /// <param name="client">The HttpClient instance.</param>
    /// <param name="requestUri">The URI the request is sent to.</param>
    /// <param name="fileBytes">The byte array representing the file to send in the request body.</param>
    /// <param name="fileName">The name of the file.</param>
    /// <param name="mediaType">The media type of the file content. Default is "application/octet-stream".</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the HttpResponseMessage.</returns>
    /// <exception cref="HttpRequestException">Thrown when the HTTP request fails.</exception>
    public static async Task<HttpResponseMessage> PostFileAsync(this HttpClient client, Uri requestUri, byte[] fileBytes, string fileName, string mediaType = "application/octet-stream", CancellationToken cancellationToken = default)
    {
        try
        {
            using (var formData = new MultipartFormDataContent())
            {
                formData.Add(new ByteArrayContent(fileBytes), "file", fileName);

                using (HttpResponseMessage response = await client.PostAsync(requestUri, formData, cancellationToken).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    return response;
                }
            }
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Failed to post file: {ex.Message}", ex);
        }
    }
}
