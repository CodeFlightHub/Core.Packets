namespace Core.QuickExtend.Tests.Tests.TaskExtensions;

internal class TimeDependentTests
{
    [Test]
    public async Task TimeoutAfter_ShouldReturnTaskResult_WhenTaskCompletesWithinTimeout()
    {
        // Arrange
        var expectedResult = "Test Result";
        var timeout = TimeSpan.FromSeconds(1);

        // Act
        var task = Task.Run(async () =>
        {
            await Task.Delay(500);
            return expectedResult;
        });

        var result = await task.TimeoutAfter(timeout);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public async Task WaitWithTimeout_ShouldReturnTrue_WhenTaskCompletesWithinTimeout()
    {
        // Arrange
        var expectedResult = "Test Result";
        var timeout = TimeSpan.FromSeconds(1);

        // Act
        var task = Task.Run(async () =>
        {
            await Task.Delay(500);
            return expectedResult;
        });

        var result = await task.WaitWithTimeout(timeout);

        // Assert
        Assert.IsTrue(result);
        Assert.That(await task, Is.EqualTo(expectedResult));
    }
}
