using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.UriExtentions.Checks
{
    internal class HasFileNameTests
    {
        [Test]
        public void HasFileName_WithFileName_ReturnsTrue()
        {
            // Arrange
            var uri = new Uri("http://example.com/api/resource/sample.txt");

            // Act
            var hasFileName = uri.HasFileName("sample.txt");

            // Assert
            Assert.IsTrue(hasFileName);
        }

        [Test]
        public void HasFileName_WithoutFileName_ReturnsFalse()
        {
            // Arrange
            var uri = new Uri("http://example.com/api/resource/");

            // Act
            var hasFileName = uri.HasFileName("sample.txt");

            // Assert
            Assert.IsFalse(hasFileName);
        }

        [Test]
        public void HasFileName_NullUri_ThrowsArgumentNullException()
        {
            // Arrange
            Uri uri = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => uri.HasFileName("sample.txt"));
        }

        [Test]
        public void HasFileName_EmptyFileName_ThrowsArgumentException()
        {
            // Arrange
            var uri = new Uri("http://example.com/api/resource/sample.txt");

            // Act & Assert
            Assert.Throws<ArgumentException>(() => uri.HasFileName(""));
        }
    }
}
