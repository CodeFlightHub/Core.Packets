using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.UriExtentions.Gets
{
    internal class GetSubdomainTests
    {
        [Test]
        public void GetSubdomain_WithSubdomain_ReturnsSubdomain()
        {
            // Arrange
            var uri = new Uri("http://subdomain.example.com");

            // Act
            var subdomain = uri.GetSubdomain();

            // Assert
            Assert.AreEqual("subdomain", subdomain);
        }

        [Test]
        public void GetSubdomain_WithoutSubdomain_ReturnsEmptyString()
        {
            // Arrange
            var uri = new Uri("http://example.com");

            // Act
            var subdomain = uri.GetSubdomain();

            // Assert
            Assert.AreEqual(string.Empty, subdomain);
        }

        [Test]
        public void GetSubdomain_NullUri_ThrowsArgumentNullException()
        {
            // Arrange
            Uri uri = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => uri.GetSubdomain());
        }
    }
}
