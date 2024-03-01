namespace Core.QuickExtend.Tests.TaskExtension;

internal class TaskExtensionUnitTest
{
    [Test]
    public async Task WithCancellation_ShouldReturnTaskResult_WhenTaskCompletes()
    {
        // Arrange
        var expectedResult = "Test Result";
        var cancellationToken = new CancellationTokenSource().Token;

        // Act
        var result = await Task.Run(async () =>
        {
            await Task.Delay(100);
            return expectedResult;
        }).WithCancellation(cancellationToken);

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [Test]
    public void RunSync_ShouldReturnResult_WhenAsyncFunctionCompletes()
    {
        // Arrange
        var expectedResult = 42;

        var asyncFunctionMock = new Mock<Func<Task<int>>>();
        asyncFunctionMock.Setup(f => f()).ReturnsAsync(expectedResult);

        // Act
        var result = asyncFunctionMock.Object.RunSync();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
        asyncFunctionMock.Verify(f => f(), Times.Once);
    }

    [Test]
    public void RunSync_ShouldThrowException_WhenAsyncFunctionThrowsException()
    {
        // Arrange
        var expectedException = new InvalidOperationException("Async function failed.");

        var asyncFunctionMock = new Mock<Func<Task<int>>>();
        asyncFunctionMock.Setup(f => f()).ThrowsAsync(expectedException);

        try
        {
            // Act
            var result = asyncFunctionMock.Object.RunSync();

            // Assert
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException ex)
        {
            // Assert
            Assert.That(ex, Is.EqualTo(expectedException));
        }

        asyncFunctionMock.Verify(f => f(), Times.Once);
    }

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
