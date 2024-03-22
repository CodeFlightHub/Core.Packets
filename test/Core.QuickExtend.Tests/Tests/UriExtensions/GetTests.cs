namespace Core.QuickExtend.Tests.Tests.UriExtensions;

internal class GetTests
{
    [Test]
    public void GetEmailAddress_ValidMailtoUri_ReturnsEmailAddress()
    {
        // Arrange
        var uri = new Uri("mailto:test@example.com");

        // Act
        var emailAddress = uri.GetEmailAddress();

        // Assert
        Assert.That(emailAddress, Is.EqualTo("test@example.com"));
    }

    [Test]
    public void GetEmailAddress_InvalidScheme_ThrowsInvalidOperationException()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => uri.GetEmailAddress());
    }

    [Test]
    public void GetEmailAddress_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetEmailAddress());
    }

    [Test]
    public void GetFileExtension_WithExtension_ReturnsExtension()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/sample.txt");

        // Act
        var fileExtension = uri.GetFileExtension();

        // Assert
        Assert.That(fileExtension, Is.EqualTo(".txt"));
    }

    [Test]
    public void GetFileExtension_WithoutExtension_ReturnsEmptyString()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/sample");

        // Act
        var fileExtension = uri.GetFileExtension();

        // Assert
        Assert.That(fileExtension, Is.EqualTo(string.Empty));
    }

    [Test]
    public void GetFileExtension_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetFileExtension());
    }

    [Test]
    public void GetFileName_WithFileName_ReturnsFileName()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/sample.txt");

        // Act
        var fileName = uri.GetFileName();

        // Assert
        Assert.That(fileName, Is.EqualTo("sample.txt"));
    }

    [Test]
    public void GetFileName_WithoutFileName_ReturnsEmptyString()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/");

        // Act
        var fileName = uri.GetFileName();

        // Assert
        Assert.That(fileName, Is.EqualTo(string.Empty));
    }

    [Test]
    public void GetFileName_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetFileName());
    }

    [Test]
    public void GetPhoneNumber_ValidTelUri_ReturnsPhoneNumber()
    {
        // Arrange
        var uri = new Uri("tel:+1234567890");

        // Act
        var phoneNumber = uri.GetPhoneNumber();

        // Assert
        Assert.That(phoneNumber, Is.EqualTo("+1234567890"));
    }


    [Test]
    public void GetPhoneNumber_InvalidScheme_ThrowsInvalidOperationException()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() => uri.GetPhoneNumber());
    }

    [Test]
    public void GetPhoneNumber_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetPhoneNumber());
    }

    [Test]
    public void GetQueryParameters_WithParameters_ReturnsDictionary()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act
        var queryParameters = uri.GetQueryParameters();

        // Assert
        Assert.That(queryParameters.Count, Is.EqualTo(2));
        Assert.IsTrue(queryParameters.ContainsKey("page"));
        Assert.That(queryParameters["page"], Is.EqualTo("2"));
        Assert.IsTrue(queryParameters.ContainsKey("sort"));
        Assert.That(queryParameters["sort"], Is.EqualTo("desc"));
    }

    [Test]
    public void GetQueryParameters_WithoutParameters_ReturnsEmptyDictionary()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var queryParameters = uri.GetQueryParameters();

        // Assert
        Assert.That(queryParameters.Count, Is.EqualTo(0));
    }

    [Test]
    public void GetQueryParameters_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetQueryParameters());
    }

    [Test]
    public void GetQueryParameterValue_WithParameter_ReturnsValue()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act
        var parameterValue = uri.GetQueryParameterValue("page");

        // Assert
        Assert.That(parameterValue, Is.EqualTo("2"));
    }

    [Test]
    public void GetQueryParameterValue_WithoutParameter_ReturnsNull()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act
        var parameterValue = uri.GetQueryParameterValue("filter");

        // Assert
        Assert.IsNull(parameterValue);
    }

    [Test]
    public void GetQueryParameterValue_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetQueryParameterValue("page"));
    }

    [Test]
    public void GetQueryParameterValue_EmptyParameterName_ThrowsArgumentException()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => uri.GetQueryParameterValue(""));
    }

    [Test]
    public void GetQueryStringAsJson_ValidUri_ReturnsJsonString()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?param1=value1&param2=value2");
        var expectedJson = "{\"param1\":\"value1\",\"param2\":\"value2\"}";

        // Act
        var json = uri.GetQueryStringAsJson();

        // Assert
        Assert.That(json, Is.EqualTo(expectedJson));
    }

    [Test]
    public void GetQueryStringAsJson_EmptyQuery_ReturnsEmptyJsonString()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var json = uri.GetQueryStringAsJson();

        // Assert
        Assert.That(json, Is.EqualTo("{}"));
    }

    [Test]
    public void GetQueryStringAsJson_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetQueryStringAsJson());
    }

    [Test]
    public void GetRelativePath_AbsoluteUri_ReturnsPathAndQuery()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2");

        // Act
        var relativePath = uri.GetRelativePath();

        // Assert
        Assert.That(relativePath, Is.EqualTo("/api/resource?page=2"));
    }

    [Test]
    public void GetRelativePath_RelativeUri_ReturnsOriginalString()
    {
        // Arrange
        var uri = new Uri("/api/resource", UriKind.Relative);

        // Act
        var relativePath = uri.GetRelativePath();

        // Assert
        Assert.That(relativePath, Is.EqualTo("/api/resource"));
    }

    [Test]
    public void GetRelativePath_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetRelativePath());
    }

    [Test]
    public void GetSubdomain_WithSubdomain_ReturnsSubdomain()
    {
        // Arrange
        var uri = new Uri("http://subdomain.example.com");

        // Act
        var subdomain = uri.GetSubdomain();

        // Assert
        Assert.That(subdomain, Is.EqualTo("subdomain"));
    }

    [Test]
    public void GetSubdomain_WithoutSubdomain_ReturnsEmptyString()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act
        var subdomain = uri.GetSubdomain();

        // Assert
        Assert.That(subdomain, Is.EqualTo(string.Empty));
    }

    [Test]
    public void GetSubdomain_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetSubdomain());
    }
}
