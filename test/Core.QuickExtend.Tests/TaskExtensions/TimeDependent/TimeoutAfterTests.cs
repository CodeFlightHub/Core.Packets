using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.TaskExtensions.TimeDependent;

internal class TimeoutAfterTests
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
}
