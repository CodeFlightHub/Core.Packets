namespace Core.QuickExtend.Tests.EnumerableExtensions.Others;

internal class HasDuplicatesTests
{
    [Test]
    public void HasDuplicates_WhenNoDuplicates_ReturnsFalse()
    {
        IEnumerable<string> source = new List<string> { "apple", "banana", "orange" };
        Assert.IsFalse(source.HasDuplicates());
    }

    [Test]
    public void HasDuplicates_WhenDuplicatesExist_ReturnsTrue()
    {
        IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5, 1 };
        Assert.IsTrue(source.HasDuplicates());
    }

    [Test]
    public void HasDuplicates_WhenEmptySource_ReturnsFalse()
    {
        IEnumerable<int> source = Enumerable.Empty<int>();
        Assert.IsFalse(source.HasDuplicates());
    }
}
