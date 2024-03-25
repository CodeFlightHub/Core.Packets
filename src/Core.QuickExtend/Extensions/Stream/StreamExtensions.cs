using System.Drawing;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Security.Cryptography;
using System.Text;

namespace Core.QuickExtend.Extensions;

public static partial class StreamExtensions
{
    /// <summary>
    /// Reads the specified number of bytes from the stream and returns them as a byte array.
    /// </summary>
    /// <param name="stream">The stream to read from.</param>
    /// <param name="byteCount">The number of bytes to read.</param>
    /// <returns>A byte array containing the read bytes.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the stream is null.</exception>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the byte count is not positive.</exception>
    public static byte[] ReadBytes(this Stream stream, int byteCount)
    {
        if (stream == null)
            throw new ArgumentNullException(nameof(stream));

        if (byteCount <= 0)
            throw new ArgumentOutOfRangeException(nameof(byteCount), "Byte count must be positive.");

        byte[] buffer = new byte[byteCount];
        int bytesRead = stream.Read(buffer, 0, byteCount);
        Array.Resize(ref buffer, bytesRead);
        return buffer;
    }

    /// <summary>
    /// Writes the specified string to the stream using UTF-8 encoding.
    /// </summary>
    /// <param name="stream">The stream to write to.</param>
    /// <param name="content">The string content to write.</param>
    /// <exception cref="ArgumentNullException">Thrown when the stream is null.</exception>
    /// <exception cref="NotSupportedException">Thrown when the stream does not support writing.</exception>
    public static void WriteString(this Stream stream, string content)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }

        if (!stream.CanWrite)
        {
            throw new NotSupportedException("Stream does not support writing.");
        }

        byte[] bytes = Encoding.UTF8.GetBytes(content);
        stream.Write(bytes, 0, bytes.Length);
    }

    /// <summary>
    /// Compresses the streams from the specified dictionary to a ZIP file.
    /// Each stream is associated with a file name in the ZIP archive.
    /// </summary>
    /// <param name="streamFileMap">A dictionary containing streams and their associated file names.</param>
    /// <param name="zipFilePath">The path to the ZIP file to be created.</param>
    /// <exception cref="ArgumentNullException">Thrown when the streamFileMap is null or empty.</exception>
    /// <exception cref="ArgumentException">Thrown when the zipFilePath is null or empty.</exception>
    public static void CompressToZip(this Dictionary<Stream, string> streamFileMap, string zipFilePath)
    {
        if (streamFileMap == null || streamFileMap.Count == 0)
        {
            throw new ArgumentNullException(nameof(streamFileMap));
        }
        if (string.IsNullOrEmpty(zipFilePath))
        {
            throw new ArgumentException("Invalid file path.", nameof(zipFilePath));
        }

        using var zipArchive = ZipFile.Open(zipFilePath, ZipArchiveMode.Create);
        foreach (var kvp in streamFileMap)
        {
            if (kvp.Key == null)
            {
                throw new ArgumentException("Stream cannot be null.");
            }

            if (string.IsNullOrEmpty(kvp.Value))
            {
                throw new ArgumentException($"File name for stream {kvp.Key} is null or empty.");
            }

            var entry = zipArchive.CreateEntry(kvp.Value);
            using var entryStream = entry.Open();
            kvp.Key.CopyTo(entryStream);
        }
    }

    /// <summary>
    /// Compresses the specified stream to a ZIP file with the given entry name.
    /// </summary>
    /// <param name="stream">The stream to compress.</param>
    /// <param name="entryName">The name to be assigned to the entry in the ZIP archive.</param>
    /// <param name="zipFilePath">The path to the ZIP file to be created.</param>
    /// <exception cref="ArgumentNullException">Thrown when the stream is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the zipFilePath or entryName is null or empty.</exception>
    public static void CompressToZip(this Stream stream, string entryName, string zipFilePath)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }
        if (string.IsNullOrEmpty(zipFilePath))
        {
            throw new ArgumentException("File path cannot be null or empty.", nameof(zipFilePath));
        }
        if (string.IsNullOrEmpty(entryName))
        {
            throw new ArgumentException("Entry name cannot be null or empty.", nameof(entryName));
        }

        using var fileStream = File.Create(zipFilePath);
        using var archive = new ZipArchive(fileStream, ZipArchiveMode.Create);
        var entry = archive.CreateEntry(entryName, CompressionLevel.Optimal);
        using var entryStream = entry.Open();

        stream.CopyTo(entryStream);
    }

    /// <summary>
    /// Creates an image from the specified stream and saves it to the specified file path in the specified format.
    /// </summary>
    /// <param name="stream">The stream containing the image data.</param>
    /// <param name="filePath">The path where the image will be saved.</param>
    /// <param name="format">The format of the image.</param>
    /// <returns>The saved image.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the stream or format is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the filePath is null or empty.</exception>
    public static Image SaveAsImage(this Stream stream, string filePath, ImageFormat format)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("File path cannot be null or empty.", nameof(filePath));
        }
        if (format == null)
        {
            throw new ArgumentNullException(nameof(format));
        }

        using var image = Image.FromStream(stream);
        image.Save(filePath, format);
        return image;
    }

    /// <summary>
    /// Writes the content of the specified stream to the specified file path.
    /// </summary>
    /// <param name="stream">The stream whose content will be written to the file.</param>
    /// <param name="filePath">The path of the file to write the content to.</param>
    /// <exception cref="ArgumentNullException">Thrown when the stream is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the filePath is null or empty.</exception>
    public static void WriteToFile(this Stream stream, string filePath)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }
        if (string.IsNullOrEmpty(filePath))
        {
            throw new ArgumentException("Invalid file path.", nameof(filePath));
        }

        using var fileStream = File.Create(filePath);
        stream.CopyTo(fileStream);
    }

    /// <summary>
    /// Encrypts the specified stream using the provided symmetric algorithm, key, and initialization vector (IV).
    /// </summary>
    /// <param name="stream">The stream to encrypt.</param>
    /// <param name="algorithm">The symmetric algorithm to use for encryption.</param>
    /// <param name="key">The secret key to use for encryption.</param>
    /// <param name="iv">The initialization vector (IV) to use for encryption.</param>
    /// <returns>The encrypted stream.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the stream, algorithm, key, or IV is null.</exception>
    public static Stream EncryptStream(this Stream stream, SymmetricAlgorithm algorithm, byte[] key, byte[] iv)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }
        if (algorithm == null)
        {
            throw new ArgumentNullException(nameof(algorithm));
        }
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        if (iv == null)
        {
            throw new ArgumentNullException(nameof(iv));
        }

        var encryptedStream = new MemoryStream();
        using var encryptor = algorithm.CreateEncryptor(key, iv);
        using var cryptoStream = new CryptoStream(encryptedStream, encryptor, CryptoStreamMode.Write);

        stream.CopyTo(cryptoStream);
        encryptedStream.Position = 0;

        return encryptedStream;
    }

    /// <summary>
    /// Decrypts the specified stream using the provided symmetric algorithm, key, and initialization vector (IV).
    /// </summary>
    /// <param name="stream">The stream to decrypt.</param>
    /// <param name="algorithm">The symmetric algorithm to use for decryption.</param>
    /// <param name="key">The secret key to use for decryption.</param>
    /// <param name="iv">The initialization vector (IV) to use for decryption.</param>
    /// <returns>The decrypted stream.</returns>
    /// <exception cref="ArgumentNullException">Thrown when the stream, algorithm, key, or IV is null.</exception>
    public static Stream DecryptStream(this Stream stream, SymmetricAlgorithm algorithm, byte[] key, byte[] iv)
    {
        if (stream == null)
        {
            throw new ArgumentNullException(nameof(stream));
        }
        if (algorithm == null)
        {
            throw new ArgumentNullException(nameof(algorithm));
        }
        if (key == null)
        {
            throw new ArgumentNullException(nameof(key));
        }
        if (iv == null)
        {
            throw new ArgumentNullException(nameof(iv));
        }

        var decryptedStream = new MemoryStream();
        using var decryptor = algorithm.CreateDecryptor(key, iv);
        using var cryptoStream = new CryptoStream(stream, decryptor, CryptoStreamMode.Read);

        cryptoStream.CopyTo(decryptedStream);
        decryptedStream.Position = 0;

        return decryptedStream;
    }
}
