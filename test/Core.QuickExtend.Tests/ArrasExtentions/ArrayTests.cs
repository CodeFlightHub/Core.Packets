using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.ArrasExtentions
{
    internal class ArrayTests
    {

        [Test]
        public void Shuffle_Should_NotThrowException_When_ArrayIsNotNull()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };

            // Act & Assert
            Assert.DoesNotThrow(() => array.Shuffle());
        }


        [Test]
        public void Fill_FillsArrayWithSpecifiedValue()
        {
            // Arrange
            int[] array = new int[5];

            // Act
            array.Fill(10);

            // Assert
            foreach (var item in array)
            {
                Assert.AreEqual(10, item);
            }
        }

        [Test]
        public void Sum_ComputesSumOfElementsInArray()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5 };

            // Act
            int result = array.Sum();

            // Assert
            Assert.AreEqual(15, result);
        }


        [Test]
        public void Resize_ResizesArrayToNewSize()
        {
            // Arrange
            int[] array = { 1, 2, 3 };

            // Act
            var resizedArray = array.Resize(5);

            // Assert
            Assert.AreEqual(5, resizedArray.Length);
        }

        [Test]
        public void AllElements_AllElementsMatchPredicate_ReturnsTrue()
        {
            // Arrange
            int[] array = { 2, 4, 6, 8 };

            // Act
            bool result = array.AllElements(x => x % 2 == 0);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void AllElements_NotAllElementsMatchPredicate_ReturnsFalse()
        {
            // Arrange
            int[] array = { 2, 4, 6, 7 };

            // Act
            bool result = array.AllElements(x => x % 2 == 0);

            // Assert
            Assert.IsFalse(result);
        }

    }
}
