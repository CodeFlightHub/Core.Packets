namespace Core.QuickExtend.Tests.EnumerableExtensions;

internal class JoinTests
{
    [Test]
    public void Join_WhenSourceIsEmpty_ReturnsEmptyString()
    {
        IEnumerable<string> source = new List<string>();
        string separator = ",";
        Assert.That(source.Join(separator), Is.EqualTo(""));
    }

    [Test]
    public void Join_WhenValidSourceAndSeparator_ReturnsJoinedString()
    {
        IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5 };
        string separator = "-";
        Assert.That(source.Join(separator), Is.EqualTo("1-2-3-4-5"));
    }
}
