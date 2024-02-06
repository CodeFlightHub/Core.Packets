namespace Core.QuickExtend.Tests.DateTimeExtensions.Adds;

internal class AddBusinessDaysTests
{
    [Test]
    public void AddBusinessDays_PositiveValue_ShouldAddBusinessDays()
    {
        // Arrange
        DateTime startDate = new DateTime(2022, 1, 1);
        int businessDaysToAdd = 3;

        // Act
        DateTime result = startDate.AddBusinessDays(businessDaysToAdd);

        // Assert
        Assert.That(result, Is.EqualTo(new DateTime(2022, 1, 5)));
    }

    [Test]
    public void AddBusinessDays_NegativeValue_ShouldSubtractBusinessDays()
    {
        // Arrange
        DateTime startDate = new DateTime(2022, 1, 6);
        int businessDaysToAdd = -3;

        // Act
        DateTime result = startDate.AddBusinessDays(businessDaysToAdd);

        // Assert
        Assert.That(result, Is.EqualTo(new DateTime(2022, 1, 3)));
    }
}
