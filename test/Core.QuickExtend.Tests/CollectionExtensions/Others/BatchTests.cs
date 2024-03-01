namespace Core.QuickExtend.Tests.CollectionExtensions.Others;

internal class BatchTests
{
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

}
