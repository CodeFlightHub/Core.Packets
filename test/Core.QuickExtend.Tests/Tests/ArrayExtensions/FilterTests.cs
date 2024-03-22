using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.ArrayExtensions;

internal class FilterTests
{
    [Test]
    public void FilterElements_ReturnsFilteredArray()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.FilterElements(x => x % 2 == 0);

        // Assert
        Assert.That(result, Is.EqualTo(new[] { 4, 2 }));
    }

    [Test]
    public void FilterAndSort_ReturnsFilteredAndSortedArray()
    {
        // Arrange
        int[] array = { 1, 4, 2, 5, 3 };

        // Act
        var result = array.FilterAndSort(x => x % 2 == 0, ascending: true);

        // Assert
        Assert.That(result, Is.EqualTo(new[] { 2, 4 }));
    }

    [Test]
    public void FilterAndSort_WithCustomComparison_ReturnsFilteredAndSortedArray()
    {
        // Arrange
        int[] array = { 1, 4, 2, 5, 3 };

        // Act
        var result = array.FilterAndSort(x => x % 2 == 0, (x, y) => x.CompareTo(y));

        // Assert
        Assert.That(result, Is.EqualTo(new[] { 2, 4 }));
    }
}
