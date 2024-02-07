namespace Core.QuickExtend.Tests.DateTimeExtensions.Checks;

internal class IsMidnightTests
{
    [Test]
    public void IsMidnight_Midnight_ReturnsTrue()
    {
        // Arrange
        DateTime midnight = new DateTime(2024, 2, 7, 0, 0, 0); // 00:00 AM

        // Action
        bool result = midnight.IsMidnight();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsMidnight_NotMidnight_ReturnsFalse()
    {
        // Arrange
        DateTime notMidnight = new DateTime(2024, 2, 7, 15, 30, 0); // 3:30 PM

        // Action
        bool result = notMidnight.IsMidnight();

        // Assert
        Assert.IsFalse(result);
    }
}
