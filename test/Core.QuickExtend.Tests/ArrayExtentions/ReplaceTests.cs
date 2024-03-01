namespace Core.QuickExtend.Tests.ArrayExtentions;

internal class ReplaceTests
{
    [Test]
    public void Replace_ReplacesAllOccurrencesOfOldValueWithNewValue()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 3, 5 };

        // Act
        array.Replace(3, 6);

        // Assert
        Assert.IsFalse(array.Contains(3));
        Assert.IsTrue(array.Contains(6));
    }

    [Test]
    public void Replace_EmptyArray_ThrowsArgumentNullException()
    {
        // Arrange
        int[] array = new int[0];

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => array.Replace(0, 1));
    }
}
