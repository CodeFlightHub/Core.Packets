namespace Core.QuickExtend.Tests.ArrayExtentions;

internal class FlattenTests
{
    [Test]
    public void Flatten_JaggedArray_ReturnsFlattenedArray()
    {
        // Arrange
        int[][] jaggedArray = new int[][]
        {
        new int[] { 1, 2, 3 },
        new int[] { 4, 5 },
        null,
        new int[] { 6 }
        };

        // Act
        var result = jaggedArray.Flatten();

        // Assert
        Assert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, result);
    }

    [Test]
    public void Flatten_TwoDimensionalArray_ReturnsFlattenedArray()
    {
        // Arrange
        int[,] twoDimensionalArray = new int[,]
        {
        { 1, 2, 3 },
        { 4, 5, 6 }
        };

        // Act
        var result = twoDimensionalArray.Flatten();

        // Assert
        Assert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, result);
    }

    [Test]
    public void Flatten_JaggedArrayWithNull_ReturnsFlattenedArrayWithoutNull()
    {
        // Arrange
        int[][] jaggedArray = new int[][]
        {
        new int[] { 1, 2, 3 },
        null,
        new int[] { 4, 5 },
        new int[] { 6 }
        };

        // Act
        var result = jaggedArray.Flatten();

        // Assert
        Assert.AreEqual(new[] { 1, 2, 3, 4, 5, 6 }, result);
    }

    [Test]
    public void Flatten_EmptyJaggedArray_ReturnsEmptyArray()
    {
        // Arrange
        int[][] jaggedArray = new int[0][];

        // Act
        var result = jaggedArray.Flatten();

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public void Flatten_EmptyTwoDimensionalArray_ReturnsEmptyArray()
    {
        // Arrange
        int[,] twoDimensionalArray = new int[0, 0];

        // Act
        var result = twoDimensionalArray.Flatten();

        // Assert
        Assert.IsEmpty(result);
    }
}
