namespace Core.QuickExtend.Tests.DateTimeExtensions.Gets;

internal class GetWeekOfMonthTests
{
    [Test]
    public void GetWeekOfMonth_ConvertsValidDateTime_ReturnsWeekOfMonth()
    {
        // Arrange
        DateTime dateInFirstWeek = new DateTime(2024, 1, 1); // A date in the first week
        DateTime dateInSecondWeek = new DateTime(2024, 1, 10); // A date in the second week
        DateTime dateInThirdWeek = new DateTime(2024, 1, 18); // A date in the third week
        DateTime dateInFourthWeek = new DateTime(2024, 1, 24); // A date in the fourth week

        // Act
        int resultFirstWeek = dateInFirstWeek.GetWeekOfMonth();
        int resultSecondWeek = dateInSecondWeek.GetWeekOfMonth();
        int resultThirdWeek = dateInThirdWeek.GetWeekOfMonth();
        int resultFourthWeek = dateInFourthWeek.GetWeekOfMonth();

        // Assert
        Assert.That(resultFirstWeek, Is.EqualTo(1)); // Expecting the date to be in the first week
        Assert.That(resultSecondWeek, Is.EqualTo(2)); // Expecting the date to be in the second week
        Assert.That(resultThirdWeek, Is.EqualTo(3)); // Expecting the date to be in the third week
        Assert.That(resultFourthWeek, Is.EqualTo(4)); // Expecting the date to be in the fourth week
    }
}
