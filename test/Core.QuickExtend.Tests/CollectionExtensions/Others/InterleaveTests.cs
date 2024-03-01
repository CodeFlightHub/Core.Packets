namespace Core.QuickExtend.Tests.CollectionExtensions.Others;

internal class InterleaveTests
{
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
}
