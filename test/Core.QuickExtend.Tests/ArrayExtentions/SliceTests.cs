namespace Core.QuickExtend.Tests.ArrayExtentions;

internal class SliceTests
{
    [Test]
    public void Slice_ReturnsShallowCopyOfPortionOfArray()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.Slice(1, 4);

        // Assert
        Assert.AreEqual(new[] { 2, 3, 4 }, result);
    }


    [Test]
    public void Slice_EmptyArray_ThrowsArgumentNullException()
    {
        // Arrange
        int[] array = new int[0];

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => array.Slice(0, 1));
    }
}
