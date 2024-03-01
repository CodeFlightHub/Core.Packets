using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.UriExtentions.Checks
{
    internal class IsValidUrlTests
    {
        [Test]
        public void IsValidUrl_ValidHttpUrl_ReturnsTrue()
        {
            // Arrange
            var uri = new Uri("http://example.com/api/resource");

            // Act
            var isValidUrl = uri.IsValidUrl();

            // Assert
            Assert.IsTrue(isValidUrl);
        }

        [Test]
        public void IsValidUrl_ValidHttpsUrl_ReturnsTrue()
        {
            // Arrange
            var uri = new Uri("https://example.com/api/resource");

            // Act
            var isValidUrl = uri.IsValidUrl();

            // Assert
            Assert.IsTrue(isValidUrl);
        }

        [Test]
        public void IsValidUrl_InvalidScheme_ReturnsFalse()
        {
            // Arrange
            var uri = new Uri("ftp://example.com/api/resource");

            // Act
            var isValidUrl = uri.IsValidUrl();

            // Assert
            Assert.IsFalse(isValidUrl);
        }

        [Test]
        public void IsValidUrl_NullUri_ThrowsArgumentNullException()
        {
            // Arrange
            Uri uri = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => uri.IsValidUrl());
        }
    }
}
