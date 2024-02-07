namespace Core.QuickExtend.Tests.DateTimeExtensions.Gets;

internal class GetDayOfWeekIndexTests
{
    [Test]
    public void GetDayOfWeekIndex_ConvertsValidDateTime_ReturnsDayOfWeekIndex()
    {
        // Arrange
        DateTime monday = new DateTime(2024, 2, 5); // Monday
        DateTime wednesday = new DateTime(2024, 2, 7); // Wednesday
        DateTime sunday = new DateTime(2024, 2, 11); // Sunday

        // Act
        int resultMonday = monday.GetDayOfWeekIndex();
        int resultWednesday = wednesday.GetDayOfWeekIndex();
        int resultSunday = sunday.GetDayOfWeekIndex();

        // Assert
        Assert.That(resultMonday, Is.EqualTo(1)); // Expecting Monday to have an index of 1
        Assert.That(resultWednesday, Is.EqualTo(3)); // Expecting Wednesday to have an index of 3
        Assert.That(resultSunday, Is.EqualTo(7)); // Expecting Sunday to have an index of 7
    }
}
