namespace Core.QuickExtend.Tests.EnumerableExtensions.Others;

internal class IndexOfTests
{
    [Test]
    public void IndexOf_WhenValueExists_ReturnsCorrectIndex()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 10, 20, 30, 40, 50 };
        int value = 40;

        // Act
        var result = source.IndexOf(value);

        // Assert
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void IndexOf_WhenValueDoesNotExist_ReturnsMinusOne()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 10, 20, 30, 40, 50 };
        int value = 60;

        // Act
        var result = source.IndexOf(value);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void IndexOf_WhenSourceIsEmpty_ReturnsMinusOne()
    {
        // Arrange
        IEnumerable<int> source = Enumerable.Empty<int>();
        int value = 42;

        // Act
        var result = source.IndexOf(value);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }
}
