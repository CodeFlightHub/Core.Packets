using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.StreamExtensions
{
    internal class GeneralTests
    {
        private const string TestString = "Test string.";
        private readonly byte[] TestBytes = Encoding.UTF8.GetBytes(TestString);

        private string tempDirectory;

        [SetUp]
        public void Setup()
        {
            tempDirectory = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDirectory);
        }

        [TearDown]
        public void Cleanup()
        {
            Directory.Delete(tempDirectory, true);
        }

        [Test]
        public void ReadBytes_ValidStreamAndByteCount_ReturnsExpectedBytes()
        {
            // Arrange
            using var stream = new MemoryStream(TestBytes);
            int byteCount = TestBytes.Length;

            // Act
            var result = stream.ReadBytes(byteCount);

            // Assert
            CollectionAssert.AreEqual(TestBytes, result);
        }

        [Test]
        public void WriteString_ValidStreamAndContent_WritesContentSuccessfully()
        {
            // Arrange
            using var stream = new MemoryStream();
            string content = TestString;

            // Act
            stream.WriteString(content);

            // Assert
            stream.Position = 0;
            using var reader = new StreamReader(stream);
            var result = reader.ReadToEnd();
            Assert.AreEqual(TestString, result);
        }

        [Test]
        public void ReadBytes_NullStream_ThrowsArgumentNullException()
        {
            // Arrange
            Stream stream = null;
            int byteCount = 10; 

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.ReadBytes(byteCount));
        }

        [Test]
        public void ReadBytes_NonPositiveByteCount_ThrowsArgumentOutOfRangeException()
        {
            // Arrange
            using var stream = new MemoryStream(TestBytes);
            int nonPositiveByteCount = 0;

            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => stream.ReadBytes(nonPositiveByteCount));
        }

        [Test]
        public void WriteString_NullStream_ThrowsArgumentNullException()
        {
            // Arrange
            Stream stream = null;
            string content = TestString;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.WriteString(content));
        }

        [Test]
        public void CompressToZip_NullStreamFileMap_ThrowsArgumentNullException()
        {
            // Arrange
            Dictionary<Stream, string> streamFileMap = null;
            var zipFilePath = "test.zip";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => streamFileMap.CompressToZip(zipFilePath));
        }

        [Test]
        public void CompressToZip_EmptyStreamFileMap_ThrowsArgumentNullException()
        {
            // Arrange
            var streamFileMap = new Dictionary<Stream, string>();
            var zipFilePath = "test.zip";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => streamFileMap.CompressToZip(zipFilePath));
        }

        [Test]
        public void CompressToZip_NullZipFilePath_ThrowsArgumentException()
        {
            // Arrange
            var stream = new MemoryStream();
            var streamFileMap = new Dictionary<Stream, string> { { stream, "file.txt" } };
            string zipFilePath = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => streamFileMap.CompressToZip(zipFilePath));
        }

        [Test]
        public void CompressToZip_EmptyZipFilePath_ThrowsArgumentException()
        {
            // Arrange
            var stream = new MemoryStream();
            var streamFileMap = new Dictionary<Stream, string> { { stream, "file.txt" } };
            var zipFilePath = "";

            // Act & Assert
            Assert.Throws<ArgumentException>(() => streamFileMap.CompressToZip(zipFilePath));
        }


        [Test]
        public void CompressToZip_EmptyFileNameInStreamFileMap_ThrowsArgumentException()
        {
            // Arrange
            var stream = new MemoryStream();
            var streamFileMap = new Dictionary<Stream, string> { { stream, "" } };
            var zipFilePath = Path.GetTempFileName() + ".zip"; 

            // Act & Assert
            Assert.Throws<ArgumentException>(() => streamFileMap.CompressToZip(zipFilePath));
        }


        [Test]
        public void CompressToZip_ValidInputs_CreatesZipFileWithEntries()
        {
            // Arrange
            var stream1 = new MemoryStream(Encoding.UTF8.GetBytes("File 1 content"));
            var stream2 = new MemoryStream(Encoding.UTF8.GetBytes("File 2 content"));
            var streamFileMap = new Dictionary<Stream, string>
    {
        { stream1, "file1.txt" },
        { stream2, "file2.txt" }
    };
            var zipFilePath = "test.zip";

            // Act
            if (File.Exists(zipFilePath))
            {
                File.Delete(zipFilePath);
            }
            streamFileMap.CompressToZip(zipFilePath);

            // Assert
            using (var archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Read))
            {
                Assert.AreEqual(2, archive.Entries.Count);
                Assert.IsTrue(archive.Entries.Any(entry => entry.FullName == "file1.txt"));
                Assert.IsTrue(archive.Entries.Any(entry => entry.FullName == "file2.txt"));
            }
        }


        [Test]
        public void CompressToZip_ValidStreamAndEntryName_CreatesZipFileWithEntry()
        {
            // Arrange
            var stream = new MemoryStream(Encoding.UTF8.GetBytes("File content"));
            var entryName = "file.txt";
            var zipFilePath = "test.zip";

            // Act
            stream.CompressToZip(entryName, zipFilePath);

            // Assert
            using (var archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Read))
            {
                var entry = archive.GetEntry(entryName);
                Assert.IsNotNull(entry);
            }
        }


        [Test]
        public void SaveAsImage_NullStream_ThrowsArgumentNullException()
        {
            // Arrange
            Stream stream = null;
            string filePath = "test.jpg";
            var format = ImageFormat.Jpeg;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.SaveAsImage(filePath, format));
        }

        [Test]
        public void SaveAsImage_NullFilePath_ThrowsArgumentException()
        {
            // Arrange
            var stream = new MemoryStream();
            string filePath = null;
            var format = ImageFormat.Jpeg;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => stream.SaveAsImage(filePath, format));
        }

        [Test]
        public void SaveAsImage_NullFormat_ThrowsArgumentNullException()
        {
            // Arrange
            var stream = new MemoryStream();
            string filePath = "test.jpg";
            ImageFormat format = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.SaveAsImage(filePath, format));
        }

        [Test]
        public void WriteToFile_NullStream_ThrowsArgumentNullException()
        {
            // Arrange
            Stream stream = null;
            string filePath = "test.txt";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.WriteToFile(filePath));
        }

        [Test]
        public void WriteToFile_NullFilePath_ThrowsArgumentException()
        {
            // Arrange
            var stream = new MemoryStream();
            string filePath = null;

            // Act & Assert
            Assert.Throws<ArgumentException>(() => stream.WriteToFile(filePath));
        }

        [Test]
        public void EncryptStream_NullStream_ThrowsArgumentNullException()
        {
            // Arrange
            Stream stream = null;
            var algorithm = new AesCryptoServiceProvider();
            var key = new byte[32];
            var iv = new byte[16];

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.EncryptStream(algorithm, key, iv));
        }

        [Test]
        public void EncryptStream_NullAlgorithm_ThrowsArgumentNullException()
        {
            // Arrange
            var stream = new MemoryStream();
            SymmetricAlgorithm algorithm = null;
            var key = new byte[32];
            var iv = new byte[16];

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.EncryptStream(algorithm, key, iv));
        }

        [Test]
        public void EncryptStream_NullKey_ThrowsArgumentNullException()
        {
            // Arrange
            var stream = new MemoryStream();
            var algorithm = new AesCryptoServiceProvider();
            byte[] key = null;
            var iv = new byte[16];

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.EncryptStream(algorithm, key, iv));
        }

        [Test]
        public void EncryptStream_NullIV_ThrowsArgumentNullException()
        {
            // Arrange
            var stream = new MemoryStream();
            var algorithm = new AesCryptoServiceProvider();
            var key = new byte[32];
            byte[] iv = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.EncryptStream(algorithm, key, iv));
        }

        [Test]
        public void DecryptStream_NullStream_ThrowsArgumentNullException()
        {
            // Arrange
            Stream stream = null;
            var algorithm = new AesCryptoServiceProvider();
            var key = new byte[32];
            var iv = new byte[16];

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.DecryptStream(algorithm, key, iv));
        }

        [Test]
        public void DecryptStream_NullAlgorithm_ThrowsArgumentNullException()
        {
            // Arrange
            var stream = new MemoryStream();
            SymmetricAlgorithm algorithm = null;
            var key = new byte[32];
            var iv = new byte[16];

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.DecryptStream(algorithm, key, iv));
        }

        [Test]
        public void DecryptStream_NullKey_ThrowsArgumentNullException()
        {
            // Arrange
            var stream = new MemoryStream();
            var algorithm = new AesCryptoServiceProvider();
            byte[] key = null;
            var iv = new byte[16];

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.DecryptStream(algorithm, key, iv));
        }

        [Test]
        public void DecryptStream_NullIV_ThrowsArgumentNullException()
        {
            // Arrange
            var stream = new MemoryStream();
            var algorithm = new AesCryptoServiceProvider();
            var key = new byte[32];
            byte[] iv = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.DecryptStream(algorithm, key, iv));
        }



    }
}
