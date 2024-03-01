namespace Core.QuickExtend.Tests.ArrayExtentions;

internal class RemoveDuplicatesTests
{

    [Test]
    public void RemoveDuplicates_ReturnsArrayWithUniqueElements()
    {
        // Arrange
        int[] array = { 1, 2, 2, 3, 3, 4, 5, 5 };

        // Act
        var result = array.RemoveDuplicates();

        // Assert
        Assert.AreEqual(new[] { 1, 2, 3, 4, 5 }, result);
    }


    [Test]
    public void RemoveDuplicates_EmptyArray_ReturnsEmptyArray()
    {
        // Arrange
        int[] array = new int[0];

        // Act
        var result = array.RemoveDuplicates();

        // Assert
        Assert.IsEmpty(result);
    }
}
