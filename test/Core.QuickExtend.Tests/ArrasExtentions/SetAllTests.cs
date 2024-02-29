using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.ArrasExtentions
{
    internal class SetAllTests
    {

        [Test]
        public void SetAll_SetsAllElementsOfArrayToSpecifiedValue()
        {
            // Arrange
            int[] array = new int[5];

            // Act
            array.SetAll(10);

            // Assert
            Assert.IsTrue(array.All(x => x == 10));
        }

        [Test]
        public void SetAll_EmptyArray_ThrowsArgumentNullException()
        {
            // Arrange
            int[] array = new int[0];

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => array.SetAll(0));
        }

    }
}
