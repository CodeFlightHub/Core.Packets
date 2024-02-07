namespace Core.QuickExtend.Tests.DateTimeExtensions.Others;

internal class StartOfDayTests
{
    [Test]
    public void StartOfDay_ValidDate_ReturnsStartOfDay()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 2, 7, 14, 30, 0);

        // Action
        DateTime result = dateTime.StartOfDay();

        // Assert
        Assert.That(result, Is.EqualTo(new DateTime(2024, 2, 7, 0, 0, 0)));
    }
}
