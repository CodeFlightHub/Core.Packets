namespace Core.QuickExtend.Tests.UriExtentions.Others;

internal class ParseQueryStringTests
{
    [Test]
    public void ParseQueryString_ValidUri_ReturnsDictionary()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?param1=value1&param2=value2");
        var expectedDictionary = new Dictionary<string, string>
    {
        { "param1", "value1" },
        { "param2", "value2" }
    };

        // Act
        var dictionary = uri.ParseQueryString();

        // Assert
        Assert.AreEqual(expectedDictionary.Count, dictionary.Count);
        foreach (var key in expectedDictionary.Keys)
        {
            Assert.IsTrue(dictionary.ContainsKey(key));
            Assert.AreEqual(expectedDictionary[key], dictionary[key]);
        }
    }

    [Test]
    public void ParseQueryString_EmptyQuery_ReturnsEmptyDictionary()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var dictionary = uri.ParseQueryString();

        // Assert
        Assert.AreEqual(0, dictionary.Count);
    }

    [Test]
    public void ParseQueryString_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.ParseQueryString());
    }
}
