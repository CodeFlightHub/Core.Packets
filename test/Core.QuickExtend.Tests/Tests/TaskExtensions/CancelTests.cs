namespace Core.QuickExtend.Tests.Tests.TaskExtensions;

internal class CancelTests
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
}
