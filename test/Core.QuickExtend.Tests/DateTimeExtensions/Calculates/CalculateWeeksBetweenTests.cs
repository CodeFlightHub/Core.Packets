namespace Core.QuickExtend.Tests.DateTimeExtensions.Calculates;

internal class CalculateWeeksBetweenTests
{
    [Test]
    public void CalculateWeeksBetween_ShouldReturnZero_WhenDatesAreSame()
    {
        // Arrange
        DateTime startDate = new DateTime(2022, 2, 1);
        DateTime endDate = new DateTime(2022, 2, 1);

        // Act
        var weeksBetween = startDate.CalculateWeeksBetween(endDate);

        // Assert
        Assert.That(weeksBetween, Is.EqualTo(0));
    }

    [Test]
    public void CalculateWeeksBetween_ShouldReturnOne_WhenDatesAreOneWeekApart()
    {
        // Arrange
        DateTime startDate = new DateTime(2022, 2, 1);
        DateTime endDate = new DateTime(2022, 2, 8);

        // Act
        var weeksBetween = startDate.CalculateWeeksBetween(endDate);

        // Assert
        Assert.That(weeksBetween, Is.EqualTo(1));
    }

    [Test]
    public void CalculateWeeksBetween_ShouldReturnTwo_WhenDatesAreTwoWeeksApart()
    {
        // Arrange
        DateTime startDate = new DateTime(2022, 2, 1);
        DateTime endDate = new DateTime(2022, 2, 15);

        // Act
        var weeksBetween = startDate.CalculateWeeksBetween(endDate);

        // Assert
        Assert.That(weeksBetween, Is.EqualTo(2));
    }
}
