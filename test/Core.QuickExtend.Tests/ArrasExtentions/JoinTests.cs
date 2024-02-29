using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.ArrasExtentions
{
    internal class JoinTests
    {
        [Test]
        public void JoinElements_Should_ReturnCorrectString()
        {
            // Arrange
            string[] array = { "Hello", "World", "!" };
            string separator = " ";

            // Act
            string result = array.JoinElements(separator);

            // Assert
            Assert.AreEqual("Hello World !", result);
        }

        [Test]
        public void JoinElements_Should_ThrowException_When_ArrayIsNull()
        {
            // Arrange
            string[] array = null;
            string separator = " ";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => array.JoinElements(separator));
        }
    }
}
