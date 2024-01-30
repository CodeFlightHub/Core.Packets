namespace Core.QuickExtend.Tests.EnumerableExtensions;

internal class AverageSafeTests
{
    [Test]
    public void Average_WhenSourceHasElements_ReturnsCorrectAverage()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 10, 20, 30, 40, 50 };

        // Act
        var result = source.AverageSafe();

        // Assert
        Assert.That(result, Is.EqualTo(30));
    }

    [Test]
    public void Average_WhenSourceHasNegativeElements_ReturnsCorrectAverage()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { -10, -20, -30, -40, -50 };

        // Act
        var result = source.AverageSafe();

        // Assert
        Assert.That(result, Is.EqualTo(-30));
    }
}
