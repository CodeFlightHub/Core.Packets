using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.ArrasExtentions
{
    internal class PartitionTests
    {
        [Test]
        public void Partition_PartitionsArrayBasedOnPredicate_ReturnsTupleWithTwoArrays()
        {
            // Arrange
            int[] array = { 1, 2, 3, 4, 5, 6 };

            // Act
            var result = array.Partition(x => x % 2 == 0);

            // Assert
            Assert.AreEqual(3, result.Item1.Length);
            Assert.AreEqual(3, result.Item2.Length);
        }

        [Test]
        public void Partition_EmptyArray_ReturnsTupleWithTwoEmptyArrays()
        {
            // Arrange
            int[] array = new int[0];

            // Act
            var result = array.Partition(x => x % 2 == 0);

            // Assert
            Assert.IsEmpty(result.Item1);
            Assert.IsEmpty(result.Item2);
        }
    }
}
