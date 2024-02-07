namespace Core.QuickExtend.Tests.DateTimeExtensions.Checks;

internal class IsWeekdayTests
{
    [Test]
    public void IsWeekday_Weekday_ReturnsTrue()
    {
        // Arrange
        DateTime weekday = new DateTime(2024, 2, 7);

        // Action
        bool result = weekday.IsWeekday();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsWeekday_Saturday_ReturnsFalse()
    {
        // Arrange
        DateTime saturday = new DateTime(2024, 2, 10);

        // Action
        bool result = saturday.IsWeekday();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsWeekday_Sunday_ReturnsFalse()
    {
        // Arrange
        DateTime sunday = new DateTime(2024, 2, 11);

        // Action
        bool result = sunday.IsWeekday();

        // Assert
        Assert.IsFalse(result);
    }
}
