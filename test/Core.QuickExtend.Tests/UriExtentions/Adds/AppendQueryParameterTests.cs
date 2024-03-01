namespace Core.QuickExtend.Tests.UriExtentions.Add;

internal class AppendQueryParameterTests
{

    [Test]
    public void AppendQueryParameter_AddNewParameter_ReturnsExpectedUri()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var modifiedUri = uri.AppendQueryParameter("page", "2");

        // Assert
        Assert.AreEqual("http://example.com/api/resource?page=2", modifiedUri.ToString());
    }

    [Test]
    public void AppendQueryParameter_UpdateExistingParameter_ReturnsExpectedUri()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=1");

        // Act
        var modifiedUri = uri.AppendQueryParameter("page", "2");

        // Assert
        Assert.AreEqual("http://example.com/api/resource?page=2", modifiedUri.ToString());
    }

    [Test]
    public void AppendQueryParameter_AddMultipleParameters_ReturnsExpectedUri()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var modifiedUri = uri.AppendQueryParameter("page", "2").AppendQueryParameter("sort", "desc");

        // Assert
        Assert.AreEqual("http://example.com/api/resource?page=2&sort=desc", modifiedUri.ToString());
    }
}
