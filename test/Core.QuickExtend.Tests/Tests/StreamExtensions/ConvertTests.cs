using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.StreamExtensions
{
    internal class ConvertTests
    {
        private const string TestString = "Test string.";
        private readonly byte[] TestBytes = Encoding.UTF8.GetBytes(TestString);

        [Test]
        public void ConvertToString_ValidStream_ReturnsExpectedString()
        {
            // Arrange
            using var stream = new MemoryStream(TestBytes);

            // Act
            var result = stream.ConvertToString();

            // Assert
            Assert.AreEqual(TestString, result);
        }

        [Test]
        public async Task ConvertToStringAsync_ValidStream_ReturnsExpectedStringAsync()
        {
            // Arrange
            using var stream = new MemoryStream(TestBytes);

            // Act
            var result = await stream.ConvertToStringAsync();

            // Assert
            Assert.AreEqual(TestString, result);
        }

        [Test]
        public void ConvertToByteArray_ValidStream_ReturnsExpectedByteArray()
        {
            // Arrange
            using var stream = new MemoryStream(TestBytes);

            // Act
            var result = stream.ConvertToByteArray();

            // Assert
            CollectionAssert.AreEqual(TestBytes, result);
        }

        [Test]
        public void ConvertToBase64String_ValidStream_ReturnsExpectedBase64String()
        {
            // Arrange
            using var stream = new MemoryStream(TestBytes);

            // Act
            var result = stream.ConvertToBase64String();

            // Assert
            var expectedBase64String = Convert.ToBase64String(TestBytes);
            Assert.AreEqual(expectedBase64String, result);
        }

        [Test]
        public void ConvertToString_NullStream_ThrowsArgumentNullException()
        {
            // Arrange
            Stream stream = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.ConvertToString());
        }

        [Test]
        public void ConvertToStringAsync_NullStream_ThrowsArgumentNullExceptionAsync()
        {
            // Arrange
            Stream stream = null;

            // Act & Assert
            Assert.ThrowsAsync<ArgumentNullException>(async () => await stream.ConvertToStringAsync());
        }

        [Test]
        public void ConvertToByteArray_NullStream_ThrowsArgumentNullException()
        {
            // Arrange
            Stream stream = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.ConvertToByteArray());
        }

        [Test]
        public void ConvertToBase64String_NullStream_ThrowsArgumentNullException()
        {
            // Arrange
            Stream stream = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => stream.ConvertToBase64String());
        }
    }
}
