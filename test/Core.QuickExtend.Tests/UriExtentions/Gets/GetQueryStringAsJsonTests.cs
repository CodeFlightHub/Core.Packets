using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.UriExtentions.Gets
{
    internal class GetQueryStringAsJsonTests
    {
        [Test]
        public void GetQueryStringAsJson_ValidUri_ReturnsJsonString()
        {
            // Arrange
            var uri = new Uri("http://example.com/api/resource?param1=value1&param2=value2");
            var expectedJson = "{\"param1\":\"value1\",\"param2\":\"value2\"}";

            // Act
            var json = uri.GetQueryStringAsJson();

            // Assert
            Assert.AreEqual(expectedJson, json);
        }

        [Test]
        public void GetQueryStringAsJson_EmptyQuery_ReturnsEmptyJsonString()
        {
            // Arrange
            var uri = new Uri("http://example.com/api/resource");

            // Act
            var json = uri.GetQueryStringAsJson();

            // Assert
            Assert.AreEqual("{}", json);
        }

        [Test]
        public void GetQueryStringAsJson_NullUri_ThrowsArgumentNullException()
        {
            // Arrange
            Uri uri = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => uri.GetQueryStringAsJson());
        }
    }
}
