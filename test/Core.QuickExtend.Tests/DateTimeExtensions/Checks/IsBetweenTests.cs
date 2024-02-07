namespace Core.QuickExtend.Tests.DateTimeExtensions.Checks;

internal class IsBetweenTests
{
    [Test]
    public void IsBetween_Inclusive_StartAndEndDates_ReturnsTrue()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15);
        DateTime start = new DateTime(2024, 1, 1);
        DateTime end = new DateTime(2024, 1, 31);

        // Action
        bool result = dateTime.IsBetween(start, end);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsBetween_Inclusive_StartAndEndDates_ReturnsFalse()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 2, 15);
        DateTime start = new DateTime(2024, 1, 1);
        DateTime end = new DateTime(2024, 1, 31);

        // Action
        bool result = dateTime.IsBetween(start, end);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsBetween_Exclusive_StartAndEndDates_ReturnsTrue()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15);
        DateTime start = new DateTime(2024, 1, 1);
        DateTime end = new DateTime(2024, 1, 31);

        // Action
        bool result = dateTime.IsBetween(start, end, inclusive: false);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsBetween_Exclusive_StartAndEndDates_ReturnsFalse()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 31);
        DateTime start = new DateTime(2024, 1, 1);
        DateTime end = new DateTime(2024, 1, 31);

        // Action
        bool result = dateTime.IsBetween(start, end, inclusive: false);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsBetween_Inclusive_TimeRange_ReturnsTrue()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15, 12, 30, 0);
        DateTime start = new DateTime(2024, 1, 15, 10, 0, 0);
        DateTime end = new DateTime(2024, 1, 15, 15, 0, 0);

        // Action
        bool result = dateTime.IsBetween(start, end, "HH:mm:ss", inclusive: true);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsBetween_Inclusive_TimeRange_ReturnsFalse()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15, 16, 0, 0);
        DateTime start = new DateTime(2024, 1, 15, 10, 0, 0);
        DateTime end = new DateTime(2024, 1, 15, 15, 0, 0);

        // Action
        bool result = dateTime.IsBetween(start, end, "HH:mm:ss", inclusive: true);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsBetween_Exclusive_TimeRange_ReturnsTrue()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15, 14, 30, 0);
        DateTime start = new DateTime(2024, 1, 15, 10, 0, 0);
        DateTime end = new DateTime(2024, 1, 15, 15, 0, 0);

        // Action
        bool result = dateTime.IsBetween(start, end, "HH:mm:ss", inclusive: false);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsBetween_Exclusive_TimeRange_ReturnsFalse()
    {
        // Arrange
        DateTime dateTime = new DateTime(2024, 1, 15, 15, 0, 0);
        DateTime start = new DateTime(2024, 1, 15, 10, 0, 0);
        DateTime end = new DateTime(2024, 1, 15, 15, 0, 0);

        // Action
        bool result = dateTime.IsBetween(start, end, "HH:mm:ss", inclusive: false);

        // Assert
        Assert.IsFalse(result);
    }
}
