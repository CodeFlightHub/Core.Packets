namespace Core.QuickExtend.Tests.EnumerableExtensions;

internal class ForEachTests
{
    [Test]
    public void ForEach_WhenValidSourceAndAction_ExecutesActionForEachElement()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 1, 2, 3 };
        List<int> result = new List<int>();
        Action<int> action = x => result.Add(x);

        // Act
        source.ForEach(action);

        // Assert
        Assert.That(result, Is.EqualTo(source));
    }
}
