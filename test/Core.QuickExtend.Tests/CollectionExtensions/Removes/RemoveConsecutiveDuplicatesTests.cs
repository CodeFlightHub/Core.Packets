using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.CollectionExtensions.Removes;

internal class RemoveConsecutiveDuplicatesTests
{
    [Test]
    public void RemoveConsecutiveDuplicates_ShouldRemoveConsecutiveDuplicates()
    {
        // Arrange
        var mockCollection = new Mock<ICollection<int>>();
        mockCollection.Setup(c => c.GetEnumerator()).Returns(() =>
        {
            // Simulate a collection with consecutive duplicate elements
            return new List<int> { 1, 2, 2, 3, 4, 4, 4, 5, 6, 6 }.GetEnumerator();
        });

        // Act
        var result = mockCollection.Object.RemoveConsecutiveDuplicates();

        // Assert
        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6 }, result);
    }

    [Test]
    public void RemoveConsecutiveDuplicates_ShouldRemoveConsecutiveStringDuplicates()
    {
        // Arrange
        var mockCollection = new Mock<ICollection<string>>();
        mockCollection.Setup(c => c.GetEnumerator()).Returns(() =>
        {
            return new List<string> { "apple", "banana", "banana", "cherry", "cherry", "cherry" }.GetEnumerator();
        });

        // Act
        var result = mockCollection.Object.RemoveConsecutiveDuplicates();

        // Assert
        CollectionAssert.AreEqual(new List<string> { "apple", "banana", "cherry" }, result);
    }
}
