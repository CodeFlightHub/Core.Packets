using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.UriExtensions;

internal class AddTests
{
    [Test]
    public void AddOrUpdateQueryParameter_NullOrEmptyKey_ThrowsArgumentException()
    {
        Uri uri = new Uri("https://www.example.com");
        Assert.Throws<ArgumentException>(() => uri.AddOrUpdateQueryParameter(null, "value"));
        Assert.Throws<ArgumentException>(() => uri.AddOrUpdateQueryParameter("", "value"));
        Assert.Throws<ArgumentException>(() => uri.AddOrUpdateQueryParameter(" ", "value"));
    }

    [Test]
    public void AddOrUpdateQueryParameter_ValidUri_AddsNewParameter()
    {
        Uri uri = new Uri("https://www.example.com");
        Uri newUri = uri.AddOrUpdateQueryParameter("key", "value");
        Assert.That(newUri.ToString(), Is.EqualTo("https://www.example.com/?key=value"));
    }

    [Test]
    public void AddOrUpdateQueryParameter_ValidUriWithExistingParameter_UpdatesParameter()
    {
        Uri uri = new Uri("https://www.example.com/?key1=value1");
        Uri newUri = uri.AddOrUpdateQueryParameter("key1", "newvalue");
        Assert.That(newUri.ToString(), Is.EqualTo("https://www.example.com/?key1=newvalue"));
    }

    [Test]
    public void AddOrUpdateQueryParameter_ValidUriWithExistingParameters_AddsNewParameter()
    {
        Uri uri = new Uri("https://www.example.com/?key1=value1");
        Uri newUri = uri.AddOrUpdateQueryParameter("key2", "value2");
        Assert.That(newUri.ToString(), Is.EqualTo("https://www.example.com/?key1=value1&key2=value2"));
    }

    [Test]
    public void AddOrUpdateQueryParameter_ValidUriWithQueryAndFragment_AddsParameter()
    {
        Uri uri = new Uri("https://www.example.com/path?param=value#fragment");
        Uri newUri = uri.AddOrUpdateQueryParameter("key", "value");
        Assert.That(newUri.ToString(), Is.EqualTo("https://www.example.com/path?param=value&key=value#fragment"));
    }

    [Test]
    public void AppendPath_NullOrEmptyNewPath_ThrowsArgumentException()
    {
        Uri uri = new Uri("https://www.example.com");
        Assert.Throws<ArgumentException>(() => uri.AppendPath(null));
        Assert.Throws<ArgumentException>(() => uri.AppendPath(""));
        Assert.Throws<ArgumentException>(() => uri.AppendPath(" "));
    }

    [Test]
    public void AppendPath_ValidUriAndNewPath_ReturnsUriWithAppendedPath()
    {
        Uri uri = new Uri("https://www.example.com");
        Uri newUri = uri.AppendPath("newpath");
        Assert.That(newUri.ToString(), Is.EqualTo("https://www.example.com/newpath"));
    }

    [Test]
    public void AppendPath_UriWithPathAndNewPath_ReturnsUriWithAppendedPath()
    {
        Uri uri = new Uri("https://www.example.com/existingpath");
        Uri newUri = uri.AppendPath("newpath");
        Assert.That(newUri.ToString(), Is.EqualTo("https://www.example.com/existingpath/newpath"));
    }

    [Test]
    public void AppendPath_UriWithTrailingSlashAndNewPath_ReturnsUriWithAppendedPath()
    {
        Uri uri = new Uri("https://www.example.com/");
        Uri newUri = uri.AppendPath("newpath");
        Assert.That(newUri.ToString(), Is.EqualTo("https://www.example.com/newpath"));
    }

    [Test]
    public void AppendPath_UriWithQueryAndNewPath_ReturnsUriWithAppendedPath()
    {
        Uri uri = new Uri("https://www.example.com/path?param=value");
        Uri newUri = uri.AppendPath("newpath");
        Assert.That(newUri.ToString(), Is.EqualTo("https://www.example.com/path/newpath?param=value"));
    }

    [Test]
    public void AppendPath_UriWithFragmentAndNewPath_ReturnsUriWithAppendedPath()
    {
        Uri uri = new Uri("https://www.example.com/path#fragment");
        Uri newUri = uri.AppendPath("newpath");
        Assert.That(newUri.ToString(), Is.EqualTo("https://www.example.com/path/newpath#fragment"));
    }

    [Test]
    public void AppendQueryParameter_AddNewParameter_ReturnsExpectedUri()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var modifiedUri = uri.AppendQueryParameter("page", "2");

        // Assert
        Assert.That(modifiedUri.ToString(), Is.EqualTo("http://example.com/api/resource?page=2"));
    }

    [Test]
    public void AppendQueryParameter_UpdateExistingParameter_ReturnsExpectedUri()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=1");

        // Act
        var modifiedUri = uri.AppendQueryParameter("page", "2");

        // Assert
        Assert.That(modifiedUri.ToString(), Is.EqualTo("http://example.com/api/resource?page=2"));
    }

    [Test]
    public void AppendQueryParameter_AddMultipleParameters_ReturnsExpectedUri()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var modifiedUri = uri.AppendQueryParameter("page", "2").AppendQueryParameter("sort", "desc");

        // Assert
        Assert.That(modifiedUri.ToString(), Is.EqualTo("http://example.com/api/resource?page=2&sort=desc"));
    }
}
