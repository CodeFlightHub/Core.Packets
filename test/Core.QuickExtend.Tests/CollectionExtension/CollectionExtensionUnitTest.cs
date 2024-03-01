namespace Core.QuickExtend.Tests.CollectionExtension;

internal class CollectionExtensionUnitTest
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

    [Test]
    public void Batch_ShouldSplitCollectionIntoBatches()
    {
        // Arrange
        var collection = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int batchSize = 3;

        // Act
        var result = collection.Batch(batchSize);

        // Assert
        var expectedBatches = new List<List<int>>
        {
            new List<int> { 1, 2, 3 },
            new List<int> { 4, 5, 6 },
            new List<int> { 7, 8, 9 },
            new List<int> { 10 }
        };

        CollectionAssert.AreEqual(expectedBatches, result.Select(batch => batch.ToList()));
    }

    [Test]
    public void Batch_ShouldHandleEmptyCollection()
    {
        // Arrange
        var emptyCollection = new List<int>();
        int batchSize = 3;

        // Act
        var result = emptyCollection.Batch(batchSize);

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public void Batch_ShouldHandleBatchSizeGreaterThanCollectionSize()
    {
        // Arrange
        var collection = new List<int> { 1, 2, 3, 4, 5 };
        int batchSize = 10;

        // Act
        var result = collection.Batch(batchSize);

        // Assert
        var expectedBatches = new List<List<int>> { collection };
        CollectionAssert.AreEqual(expectedBatches, result.Select(batch => batch.ToList()));
    }

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

    [Test]
    public void Interleave_ShouldMergeTwoCollectionsIntoSingleCollection()
    {
        // Arrange
        var mockCollection1 = new Mock<ICollection<int>>();
        mockCollection1.Setup(c => c.GetEnumerator()).Returns(() =>
        {
            // Simulate a collection with elements 1, 3, 5, 7, 9
            return new List<int> { 1, 3, 5, 7, 9 }.GetEnumerator();
        });

        var mockCollection2 = new Mock<ICollection<int>>();
        mockCollection2.Setup(c => c.GetEnumerator()).Returns(() =>
        {
            // Simulate another collection with elements 2, 4, 6, 8, 10
            return new List<int> { 2, 4, 6, 8, 10 }.GetEnumerator();
        });

        // Act
        var result = mockCollection1.Object.Interleave(mockCollection2.Object);

        // Assert
        CollectionAssert.AreEqual(new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, result);
    }

    [Test]
    public void Interleave_ShouldMergeStringCollectionsIntoSingleCollection()
    {
        // Arrange
        var mockCollection1 = new Mock<ICollection<string>>();
        mockCollection1.Setup(c => c.GetEnumerator()).Returns(() =>
        {
            // Simulate a collection with string elements "a", "c", "e"
            return new List<string> { "a", "c", "e" }.GetEnumerator();
        });

        var mockCollection2 = new Mock<ICollection<string>>();
        mockCollection2.Setup(c => c.GetEnumerator()).Returns(() =>
        {
            // Simulate another collection with string elements "b", "d", "f"
            return new List<string> { "b", "d", "f" }.GetEnumerator();
        });

        // Act
        var result = mockCollection1.Object.Interleave(mockCollection2.Object);

        // Assert
        CollectionAssert.AreEqual(new List<string> { "a", "b", "c", "d", "e", "f" }, result);
    }

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
