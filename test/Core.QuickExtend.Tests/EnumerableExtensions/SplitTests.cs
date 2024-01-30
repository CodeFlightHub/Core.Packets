namespace Core.QuickExtend.Tests.EnumerableExtensions;

internal class SplitTests
{
    [Test]
    public void Split_WhenSeparatorNotInCollection_ReturnsSinglePartition()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { "apple", "banana", "orange" };
        string separator = "grape";

        // Act
        var result = source.Split(separator);

        // Assert
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.IsTrue(result.Single().SequenceEqual(new List<string> { "apple", "banana", "orange" }));
    }
}
