namespace Core.QuickExtend.Tests.ArrayExtension;

internal class ArrayExtensionUnitTest
{
    [Test]
    public void Shuffle_Should_NotThrowException_When_ArrayIsNotNull()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act & Assert
        Assert.DoesNotThrow(() => array.Shuffle());
    }


    [Test]
    public void Fill_FillsArrayWithSpecifiedValue()
    {
        // Arrange
        int[] array = new int[5];

        // Act
        array.Fill(10);

        // Assert
        foreach (var item in array)
        {
            Assert.AreEqual(10, item);
        }
    }

    [Test]
    public void Sum_ComputesSumOfElementsInArray()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        int result = array.Sum();

        // Assert
        Assert.AreEqual(15, result);
    }


    [Test]
    public void Resize_ResizesArrayToNewSize()
    {
        // Arrange
        int[] array = { 1, 2, 3 };

        // Act
        var resizedArray = array.Resize(5);

        // Assert
        Assert.AreEqual(5, resizedArray.Length);
    }

    [Test]
    public void AllElements_AllElementsMatchPredicate_ReturnsTrue()
    {
        // Arrange
        int[] array = { 2, 4, 6, 8 };

        // Act
        bool result = array.AllElements(x => x % 2 == 0);

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void AllElements_NotAllElementsMatchPredicate_ReturnsFalse()
    {
        // Arrange
        int[] array = { 2, 4, 6, 7 };

        // Act
        bool result = array.AllElements(x => x % 2 == 0);

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void Average_ComputesAverageOfElementsInArray()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        double result = array.Average();

        // Assert
        Assert.AreEqual(3, result);
    }

    [Test]
    public void Average_EmptyArray_ThrowsArgumentNullException()
    {
        // Arrange
        int[] array = new int[0];

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => array.Average());
    }

    [Test]
    public void FilterElements_ReturnsFilteredArray()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.FilterElements(x => x % 2 == 0);

        // Assert
        Assert.AreEqual(new[] { 4, 2 }, result);
    }

    [Test]
    public void FilterAndSort_ReturnsFilteredAndSortedArray()
    {
        // Arrange
        int[] array = { 1, 4, 2, 5, 3 };

        // Act
        var result = array.FilterAndSort(x => x % 2 == 0, ascending: true);

        // Assert
        Assert.AreEqual(new[] { 2, 4 }, result);
    }

    [Test]
    public void FilterAndSort_WithCustomComparison_ReturnsFilteredAndSortedArray()
    {
        // Arrange
        int[] array = { 1, 4, 2, 5, 3 };

        // Act
        var result = array.FilterAndSort(x => x % 2 == 0, (x, y) => x.CompareTo(y));

        // Assert
        Assert.AreEqual(new[] { 2, 4 }, result);
    }

    [Test]
    public void Partition_PartitionsArrayBasedOnPredicate_ReturnsTupleWithTwoArrays()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5, 6 };

        // Act
        var result = array.Partition(x => x % 2 == 0);

        // Assert
        Assert.AreEqual(3, result.Item1.Length);
        Assert.AreEqual(3, result.Item2.Length);
    }

    [Test]
    public void Partition_EmptyArray_ReturnsTupleWithTwoEmptyArrays()
    {
        // Arrange
        int[] array = new int[0];

        // Act
        var result = array.Partition(x => x % 2 == 0);

        // Assert
        Assert.IsEmpty(result.Item1);
        Assert.IsEmpty(result.Item2);
    }

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

    [Test]
    public void SetAll_SetsAllElementsOfArrayToSpecifiedValue()
    {
        // Arrange
        int[] array = new int[5];

        // Act
        array.SetAll(10);

        // Assert
        Assert.IsTrue(array.All(x => x == 10));
    }

    [Test]
    public void SetAll_EmptyArray_ThrowsArgumentNullException()
    {
        // Arrange
        int[] array = new int[0];

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => array.SetAll(0));
    }

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
