namespace Core.QuickExtend.Tests.DateTimeExtensions.Checks;

internal class IsLunchTimeTests
{
    [Test]
    public void IsLunchTime_LunchTime_ReturnsTrue()
    {
        // Arrange
        DateTime lunchTime = new DateTime(2024, 2, 7, 12, 0, 0); // 12:00 PM

        // Action
        bool result = lunchTime.IsLunchTime();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsLunchTime_NotLunchTime_ReturnsFalse()
    {
        // Arrange
        DateTime notLunchTime = new DateTime(2024, 2, 7, 15, 30, 0); // 3:30 PM

        // Action
        bool result = notLunchTime.IsLunchTime();

        // Assert
        Assert.IsFalse(result);
    }
}
