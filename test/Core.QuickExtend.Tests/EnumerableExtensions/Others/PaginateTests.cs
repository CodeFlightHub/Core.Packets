namespace Core.QuickExtend.Tests.EnumerableExtensions.Others;

internal class PaginateTests
{
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
}
