using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace Core.QuickExtend.Extensions;

public static partial class StreamExtensions
{
    /// <summary>
    /// Converts the content of the specified stream to a string.
    /// </summary>
    /// <param name="stream">The stream to convert.</param>
    /// <returns>The content of the stream as a string.</returns>
    public static string ConvertToString(this Stream stream)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }

    /// <summary>
    /// Converts the content of the specified stream to a string asynchronously.
    /// </summary>
    /// <param name="stream">The stream to convert.</param>
    /// <returns>A task representing the asynchronous operation. The content of the stream as a string.</returns>
    public static async Task<string> ConvertToStringAsync(this Stream stream)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        using var reader = new StreamReader(stream);
        return await reader.ReadToEndAsync();
    }

    /// <summary>
    /// Converts the content of the specified stream to a byte array.
    /// </summary>
    /// <param name="stream">The stream to convert.</param>
    /// <returns>The content of the stream as a byte array.</returns>
    public static byte[] ConvertToByteArray(this Stream stream)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }

    /// <summary>
    /// Converts the specified stream to a Base64 string.
    /// </summary>
    /// <param name="stream">The stream to convert.</param>
    /// <returns>The Base64 string representation of the stream.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the stream is null.</exception>
    public static string ConvertToBase64String(this Stream stream)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        using var memoryStream = new MemoryStream();
        stream.CopyTo(memoryStream);
        return Convert.ToBase64String(memoryStream.ToArray());
    }
}
