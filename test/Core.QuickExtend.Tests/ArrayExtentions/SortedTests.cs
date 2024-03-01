namespace Core.QuickExtend.Tests.ArrayExtentions;

internal class SortedTests
{

    [Test]
    public void IsSorted_ArrayIsSorted_ReturnsTrue()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        bool result = array.IsSorted();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsSorted_ArrayIsNotSorted_ReturnsFalse()
    {
        // Arrange
        int[] array = { 1, 3, 2, 4, 5 };

        // Act
        bool result = array.IsSorted();

        // Assert
        Assert.IsFalse(result);
    }


    [Test]
    public void IsSorted_EmptyArray_ReturnsTrue()
    {
        // Arrange
        int[] array = new int[0];

        // Act
        bool result = array.IsSorted();

        // Assert
        Assert.IsTrue(result);
    }
}
