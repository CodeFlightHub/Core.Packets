using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.ArrayExtensions;

internal class GeneralTests
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
            Assert.That(item, Is.EqualTo(10));
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
        Assert.That(result, Is.EqualTo(15));
    }


    [Test]
    public void Resize_ResizesArrayToNewSize()
    {
        // Arrange
        int[] array = { 1, 2, 3 };

        // Act
        var resizedArray = array.Resize(5);

        // Assert
        Assert.That(resizedArray.Length, Is.EqualTo(5));
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
        Assert.That(result, Is.EqualTo(3));
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
    public void Partition_PartitionsArrayBasedOnPredicate_ReturnsTupleWithTwoArrays()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5, 6 };

        // Act
        var result = array.Partition(x => x % 2 == 0);

        // Assert
        Assert.That(result.Item1.Length, Is.EqualTo(3));
        Assert.That(result.Item2.Length, Is.EqualTo(3));
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
        Assert.That(result, Is.EqualTo(new[] { 1, 2, 3, 4, 5 }));
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
        Assert.That(result, Is.EqualTo(new[] { 2, 3, 4 }));
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
