using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.CollectionExtensions;

internal class RemoveTests
{
    [Test]
    public void RemoveAll_ShouldRemoveElementsAndReturnCorrectCollection()
    {
        // Arrange
        List<int> numbers = new List<int> { 1, 2, 3, 4, 2, 5, 2, 6 };
        int valueToRemove = 2;

        // Act
        var removedItems = numbers.RemoveAll(valueToRemove);

        // Assert
        CollectionAssert.DoesNotContain(numbers, valueToRemove);
        CollectionAssert.AreEquivalent(new List<int> { 2, 2, 2 }, removedItems);
    }

    [Test]
    public void RemoveAll_ShouldRemoveStringElementsAndReturnCorrectCollection()
    {
        // Arrange
        List<string> names = new List<string> { "Alice", "Bob", "Charlie", "Bob", "David" };
        string valueToRemove = "Bob";

        // Act
        var removedItems = names.RemoveAll(valueToRemove);

        // Assert
        CollectionAssert.DoesNotContain(names, valueToRemove);
        CollectionAssert.AreEquivalent(new List<string> { "Bob", "Bob" }, removedItems);
    }

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
