using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.CollectionExtensions.Others;

internal class DistinctByTests
{
    [Test]
    public void DistinctBy_ShouldRemoveDuplicateElementsBasedOnKey()
    {
        // Arrange
        var mockCollection = new Mock<ICollection<int>>();
        mockCollection.Setup(c => c.GetEnumerator()).Returns(() =>
        {
            return new List<int> { 1, 2, 2, 3, 4, 4, 4, 5, 6, 6 }.GetEnumerator();
        });

        Func<int, int> keySelector = item => item;

        // Act
        var result = mockCollection.Object.DistinctBy(keySelector);

        // Assert
        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
    }
}
