namespace Core.QuickExtend.Tests.DateTimeExtensions.Checks;

internal class IsBusinessDayTests
{
    [Test]
    public void IsBusinessDay_Weekday_ReturnsTrue()
    {
        // Arrange
        DateTime weekday = new DateTime(2024, 2, 7);

        // Action
        bool result = weekday.IsBusinessDay();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsBusinessDay_Saturday_ReturnsFalse()
    {
        // Arrange
        DateTime saturday = new DateTime(2024, 2, 10);

        // Action
        bool result = saturday.IsBusinessDay();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsBusinessDay_Sunday_ReturnsFalse()
    {
        // Arrange
        DateTime sunday = new DateTime(2024, 2, 11);

        // Action
        bool result = sunday.IsBusinessDay();

        // Assert
        Assert.IsFalse(result);
    }
}
