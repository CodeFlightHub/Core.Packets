namespace Core.QuickExtend.Tests.DateTimeExtensions.Checks;

internal class IsPastDateTests
{
    [Test]
    public void IsPastDate_DateInPast_ReturnsTrue()
    {
        // Arrange
        DateTime pastDate = DateTime.Now.AddDays(-1);

        // Action
        bool result = pastDate.IsPastDate();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsPastDate_DateInFuture_ReturnsFalse()
    {
        // Arrange
        DateTime futureDate = DateTime.Now.AddDays(1);

        // Action
        bool result = futureDate.IsPastDate();

        // Assert
        Assert.IsFalse(result);
    }
}
