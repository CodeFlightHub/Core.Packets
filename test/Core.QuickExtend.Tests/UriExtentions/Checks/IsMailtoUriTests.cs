using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.UriExtentions.Checks
{
    internal class IsMailtoUriTests
    {
        [Test]
        public void IsMailtoUri_ValidMailtoUri_ReturnsTrue()
        {
            // Arrange
            var uri = new Uri("mailto:test@example.com");

            // Act
            var isMailtoUri = uri.IsMailtoUri();

            // Assert
            Assert.IsTrue(isMailtoUri);
        }

        [Test]
        public void IsMailtoUri_InvalidScheme_ReturnsFalse()
        {
            // Arrange
            var uri = new Uri("http://example.com");

            // Act
            var isMailtoUri = uri.IsMailtoUri();

            // Assert
            Assert.IsFalse(isMailtoUri);
        }

        [Test]
        public void IsMailtoUri_NullUri_ThrowsArgumentNullException()
        {
            // Arrange
            Uri uri = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => uri.IsMailtoUri());
        }
    }
}
