using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.UriExtentions.Checks
{
    internal class IsTelUriTests
    {
        [Test]
        public void IsTelUri_ValidTelUri_ReturnsTrue()
        {
            // Arrange
            var uri = new Uri("tel:1234567890");

            // Act
            var isTelUri = uri.IsTelUri();

            // Assert
            Assert.IsTrue(isTelUri);
        }

        [Test]
        public void IsTelUri_InvalidScheme_ReturnsFalse()
        {
            // Arrange
            var uri = new Uri("http://example.com");

            // Act
            var isTelUri = uri.IsTelUri();

            // Assert
            Assert.IsFalse(isTelUri);
        }

        [Test]
        public void IsTelUri_NullUri_ThrowsArgumentNullException()
        {
            // Arrange
            Uri uri = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => uri.IsTelUri());
        }
    }
}
