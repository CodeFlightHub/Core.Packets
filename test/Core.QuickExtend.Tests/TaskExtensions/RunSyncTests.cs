using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.TaskExtensions;

internal class RunSyncTests
{
    [Test]
    public void RunSync_ShouldReturnResult_WhenAsyncFunctionCompletes()
    {
        // Arrange
        var expectedResult = 42;

        // Mock asenkron bir fonksiyon
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
}
