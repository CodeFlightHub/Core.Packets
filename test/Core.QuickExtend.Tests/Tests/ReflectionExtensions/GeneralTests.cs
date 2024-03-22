namespace Core.QuickExtend.Tests.Tests.ReflectionExtensions;

internal class GeneralTests
{
    [Test]
    public void InvokeMethodByName_ShouldNotThrowException_WhenObjectIsNull()
    {
        // Arrange
        object? obj = null;

        // Act & Assert
        Assert.DoesNotThrow(() => obj?.InvokeMethodByName("SampleMethod", "test"));
    }
}