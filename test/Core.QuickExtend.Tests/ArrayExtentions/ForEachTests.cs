namespace Core.QuickExtend.Tests.ArrayExtentions;

internal class ForEachTests
{
    [Test]
    public void ForEach_PerformsActionOnEachElement()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };
        int sum = 0;

        // Act
        array.ForEach(x => sum += x);

        // Assert
        Assert.AreEqual(15, sum);
    }

    [Test]
    public void ForEach_DefaultActionWritesToConsole()
    {
        // Arrange
        int[] array = { 1, 2, 3 };
        var writer = new StringWriter();
        Console.SetOut(writer);

        // Act
        array.ForEach();

        // Assert
        Assert.AreEqual("1\r\n2\r\n3\r\n", writer.ToString());
    }
}
