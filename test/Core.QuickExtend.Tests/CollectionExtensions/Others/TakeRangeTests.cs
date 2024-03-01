namespace Core.QuickExtend.Tests.CollectionExtensions.Others;

internal class TakeRangeTests
{
    [Test]
    public void TakeRange_ShouldTakeElementsFromCollectionStartingFromIndex()
    {
        // Arrange
        var mockCollection = new Mock<ICollection<int>>();
        mockCollection.Setup(c => c.GetEnumerator()).Returns(() =>
        {
            // Simulate a collection with elements from 0 to 9
            return new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }.GetEnumerator();
        });

        int startIndex = 2;
        int count = 5;

        // Act
        var result = mockCollection.Object.TakeRange(startIndex, count);

        // Assert
        CollectionAssert.AreEqual(new List<int> { 2, 3, 4, 5, 6 }, result);
    }

    [Test]
    public void TakeRange_ShouldTakeStringElementsFromCollectionStartingFromIndex()
    {
        // Arrange
        var mockCollection = new Mock<ICollection<string>>();
        mockCollection.Setup(c => c.GetEnumerator()).Returns(() =>
        {
            // Simulate a collection with string elements
            return new List<string> { "apple", "banana", "cherry", "date", "elderberry", "fig" }.GetEnumerator();
        });

        int startIndex = 1;
        int count = 3;

        // Act
        var result = mockCollection.Object.TakeRange(startIndex, count);

        // Assert
        CollectionAssert.AreEqual(new List<string> { "banana", "cherry", "date" }, result);
    }
}
