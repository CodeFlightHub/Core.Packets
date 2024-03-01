namespace Core.QuickExtend.Tests.CollectionExtensions.Removes;

internal class RemoveAllTests
{
    [Test]
    public void RemoveAll_ShouldRemoveElementsAndReturnCorrectCollection()
    {
        // Arrange
        List<int> numbers = new List<int> { 1, 2, 3, 4, 2, 5, 2, 6 };
        int valueToRemove = 2;

        // Act
        var removedItems = numbers.RemoveAll(valueToRemove);

        // Assert
        CollectionAssert.DoesNotContain(numbers, valueToRemove);
        CollectionAssert.AreEquivalent(new List<int> { 2, 2, 2 }, removedItems);
    }

    [Test]
    public void RemoveAll_ShouldRemoveStringElementsAndReturnCorrectCollection()
    {
        // Arrange
        List<string> names = new List<string> { "Alice", "Bob", "Charlie", "Bob", "David" };
        string valueToRemove = "Bob";

        // Act
        var removedItems = names.RemoveAll(valueToRemove);

        // Assert
        CollectionAssert.DoesNotContain(names, valueToRemove);
        CollectionAssert.AreEquivalent(new List<string> { "Bob", "Bob" }, removedItems);
    }
}
