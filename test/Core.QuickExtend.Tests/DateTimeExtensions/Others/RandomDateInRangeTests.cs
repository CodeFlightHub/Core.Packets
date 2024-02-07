namespace Core.QuickExtend.Tests.DateTimeExtensions.Others;

internal class RandomDateInRangeTests
{
    [Test]
    public void RandomDateInRange_ValidDates_ReturnsRandomDateWithinRange()
    {
        // Arrange
        DateTime startDate = new DateTime(2024, 2, 1);
        DateTime endDate = new DateTime(2024, 2, 10);

        // Act
        DateTime result = startDate.RandomDateInRange(endDate);

        // Assert
        Assert.GreaterOrEqual(result, startDate);
        Assert.LessOrEqual(result, endDate);
    }
}
