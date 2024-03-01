namespace Core.QuickExtend.Tests.EnumerableExtension;

internal class EnumerableExtensionUnitTest
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

    [Test]
    public void Average_WhenSourceHasElements_ReturnsCorrectAverage()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 10, 20, 30, 40, 50 };

        // Act
        var result = source.AverageSafe();

        // Assert
        Assert.That(result, Is.EqualTo(30));
    }

    [Test]
    public void Average_WhenSourceHasNegativeElements_ReturnsCorrectAverage()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { -10, -20, -30, -40, -50 };

        // Act
        var result = source.AverageSafe();

        // Assert
        Assert.That(result, Is.EqualTo(-30));
    }

    [Test]
    public void ForEach_WhenValidSourceAndAction_ExecutesActionForEachElement()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 1, 2, 3 };
        List<int> result = new List<int>();
        Action<int> action = x => result.Add(x);

        // Act
        source.ForEach(action);

        // Assert
        Assert.That(result, Is.EqualTo(source));
    }

    [Test]
    public void HasDuplicates_WhenNoDuplicates_ReturnsFalse()
    {
        IEnumerable<string> source = new List<string> { "apple", "banana", "orange" };
        Assert.IsFalse(source.HasDuplicates());
    }

    [Test]
    public void HasDuplicates_WhenDuplicatesExist_ReturnsTrue()
    {
        IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5, 1 };
        Assert.IsTrue(source.HasDuplicates());
    }

    [Test]
    public void HasDuplicates_WhenEmptySource_ReturnsFalse()
    {
        IEnumerable<int> source = Enumerable.Empty<int>();
        Assert.IsFalse(source.HasDuplicates());
    }

    [Test]
    public void IndexOf_WhenValueExists_ReturnsCorrectIndex()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 10, 20, 30, 40, 50 };
        int value = 40;

        // Act
        var result = source.IndexOf(value);

        // Assert
        Assert.That(result, Is.EqualTo(3));
    }

    [Test]
    public void IndexOf_WhenValueDoesNotExist_ReturnsMinusOne()
    {
        // Arrange
        IEnumerable<int> source = new List<int> { 10, 20, 30, 40, 50 };
        int value = 60;

        // Act
        var result = source.IndexOf(value);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void IndexOf_WhenSourceIsEmpty_ReturnsMinusOne()
    {
        // Arrange
        IEnumerable<int> source = Enumerable.Empty<int>();
        int value = 42;

        // Act
        var result = source.IndexOf(value);

        // Assert
        Assert.That(result, Is.EqualTo(-1));
    }

    [Test]
    public void Join_WhenSourceIsEmpty_ReturnsEmptyString()
    {
        IEnumerable<string> source = new List<string>();
        string separator = ",";
        Assert.That(source.Join(separator), Is.EqualTo(""));
    }

    [Test]
    public void Join_WhenValidSourceAndSeparator_ReturnsJoinedString()
    {
        IEnumerable<int> source = new List<int> { 1, 2, 3, 4, 5 };
        string separator = "-";
        Assert.That(source.Join(separator), Is.EqualTo("1-2-3-4-5"));
    }

    [Test]
    public void Paginate_WhenValidPageAndSize_ReturnsCorrectPage()
    {
        // Arrange
        IEnumerable<int> source = Enumerable.Range(1, 100);
        int pageNumber = 3;
        int pageSize = 10;

        // Act
        var result = source.Paginate(pageNumber, pageSize);

        // Assert
        Assert.That(result, Is.EqualTo(Enumerable.Range(21, 10)));
    }

    [Test]
    public void Paginate_WhenPageNumberExceedsTotalPages_ReturnsEmptyCollection()
    {
        // Arrange
        IEnumerable<int> source = Enumerable.Range(1, 100);
        int pageNumber = 11;
        int pageSize = 10;

        // Act
        var result = source.Paginate(pageNumber, pageSize);

        // Assert
        Assert.IsEmpty(result);
    }

    [Test]
    public void Split_WhenSeparatorNotInCollection_ReturnsSinglePartition()
    {
        // Arrange
        IEnumerable<string> source = new List<string> { "apple", "banana", "orange" };
        string separator = "grape";

        // Act
        var result = source.Split(separator);

        // Assert
        Assert.That(result.Count(), Is.EqualTo(1));
        Assert.IsTrue(result.Single().SequenceEqual(new List<string> { "apple", "banana", "orange" }));
    }
}
