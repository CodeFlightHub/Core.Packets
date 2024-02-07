namespace Core.QuickExtend.Tests.DateTimeExtensions.Others;

internal class DaysBetweenTests
{
    [Test]
    public void DaysBetween_ValidDates_ReturnsCorrectNumberOfDays()
    {
        // Arrange
        DateTime startDate = new DateTime(2024, 2, 5);
        DateTime endDate = new DateTime(2024, 2, 10);

        // Action
        int result = startDate.DaysBetween(endDate);

        // Assert
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void DaysBetween_SameDate_ReturnsZeroDays()
    {
        // Arrange
        DateTime sameDate = new DateTime(2024, 2, 7);

        // Action
        int result = sameDate.DaysBetween(sameDate);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }
}
