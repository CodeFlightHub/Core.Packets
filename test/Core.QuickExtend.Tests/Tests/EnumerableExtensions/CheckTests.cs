using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.EnumerableExtensions;

internal class CheckTests
{
    [Test]
    public void IsNullOrEmpty_WhenSourceIsEmpty_ReturnsTrue()
    {
        IEnumerable<int> source = Enumerable.Empty<int>();
        Assert.IsTrue(source.IsNullOrEmpty());
    }

    [Test]
    public void IsNullOrEmpty_WhenSourceHasElements_ReturnsFalse()
    {
        IEnumerable<int> source = new List<int> { 1, 2, 3 };
        Assert.IsFalse(source.IsNullOrEmpty());
    }

    [Test]
    public void IsNullOrEmpty_WhenSourceIsNotEmpty_ReturnsFalse()
    {
        IEnumerable<int> source = Enumerable.Range(1, 5);
        Assert.IsFalse(source.IsNullOrEmpty());
    }
}
