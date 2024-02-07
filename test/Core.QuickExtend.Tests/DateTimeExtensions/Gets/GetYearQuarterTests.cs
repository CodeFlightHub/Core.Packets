namespace Core.QuickExtend.Tests.DateTimeExtensions.Gets;

internal class GetYearQuarterTests
{
    [Test]
    public void GetYearQuarter_ConvertsValidDateTime_ReturnsQuarter()
    {
        // Arrange
        DateTime dateTimeQ1 = new DateTime(2024, 2, 7); // A date in the first quarter
        DateTime dateTimeQ2 = new DateTime(2024, 5, 15); // A date in the second quarter
        DateTime dateTimeQ3 = new DateTime(2024, 8, 22); // A date in the third quarter
        DateTime dateTimeQ4 = new DateTime(2024, 11, 30); // A date in the fourth quarter

        // Act
        int resultQ1 = dateTimeQ1.GetYearQuarter();
        int resultQ2 = dateTimeQ2.GetYearQuarter();
        int resultQ3 = dateTimeQ3.GetYearQuarter();
        int resultQ4 = dateTimeQ4.GetYearQuarter();

        // Assert
        Assert.That(resultQ1, Is.EqualTo(1)); // Expecting the first quarter
        Assert.That(resultQ2, Is.EqualTo(2)); // Expecting the second quarter
        Assert.That(resultQ3, Is.EqualTo(3)); // Expecting the third quarter
        Assert.That(resultQ4, Is.EqualTo(4)); // Expecting the fourth quarter
    }
}
