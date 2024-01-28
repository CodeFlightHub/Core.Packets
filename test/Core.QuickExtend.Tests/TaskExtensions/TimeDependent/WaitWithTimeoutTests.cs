using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.TaskExtensions.TimeDependent;

internal class WaitWithTimeoutTests
{
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
