namespace Core.QuickExtend.Tests.UriExtension;

internal class UriExtensionUnitTest
{
    [Test]
    public void AddOrUpdateQueryParameter_NullUri_ThrowsArgumentNullException()
    {
        Uri uri = null;
        Assert.Throws<ArgumentNullException>(() => uri.AddOrUpdateQueryParameter("key", "value"));
    }

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
        Assert.AreEqual("https://www.example.com/?key=value", newUri.ToString());
    }

    [Test]
    public void AddOrUpdateQueryParameter_ValidUriWithExistingParameter_UpdatesParameter()
    {
        Uri uri = new Uri("https://www.example.com/?key1=value1");
        Uri newUri = uri.AddOrUpdateQueryParameter("key1", "newvalue");
        Assert.AreEqual("https://www.example.com/?key1=newvalue", newUri.ToString());
    }

    [Test]
    public void AddOrUpdateQueryParameter_ValidUriWithExistingParameters_AddsNewParameter()
    {
        Uri uri = new Uri("https://www.example.com/?key1=value1");
        Uri newUri = uri.AddOrUpdateQueryParameter("key2", "value2");
        Assert.AreEqual("https://www.example.com/?key1=value1&key2=value2", newUri.ToString());
    }

    [Test]
    public void AddOrUpdateQueryParameter_ValidUriWithQueryAndFragment_AddsParameter()
    {
        Uri uri = new Uri("https://www.example.com/path?param=value#fragment");
        Uri newUri = uri.AddOrUpdateQueryParameter("key", "value");
        Assert.AreEqual("https://www.example.com/path?param=value&key=value#fragment", newUri.ToString());
    }

    [Test]
    public void AppendPath_NullUri_ThrowsArgumentNullException()
    {
        Uri uri = null;
        Assert.Throws<ArgumentNullException>(() => uri.AppendPath("newpath"));
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
        Assert.AreEqual("https://www.example.com/newpath", newUri.ToString());
    }

    [Test]
    public void AppendPath_UriWithPathAndNewPath_ReturnsUriWithAppendedPath()
    {
        Uri uri = new Uri("https://www.example.com/existingpath");
        Uri newUri = uri.AppendPath("newpath");
        Assert.AreEqual("https://www.example.com/existingpath/newpath", newUri.ToString());
    }

    [Test]
    public void AppendPath_UriWithTrailingSlashAndNewPath_ReturnsUriWithAppendedPath()
    {
        Uri uri = new Uri("https://www.example.com/");
        Uri newUri = uri.AppendPath("newpath");
        Assert.AreEqual("https://www.example.com/newpath", newUri.ToString());
    }

    [Test]
    public void AppendPath_UriWithQueryAndNewPath_ReturnsUriWithAppendedPath()
    {
        Uri uri = new Uri("https://www.example.com/path?param=value");
        Uri newUri = uri.AppendPath("newpath");
        Assert.AreEqual("https://www.example.com/path/newpath?param=value", newUri.ToString());
    }

    [Test]
    public void AppendPath_UriWithFragmentAndNewPath_ReturnsUriWithAppendedPath()
    {
        Uri uri = new Uri("https://www.example.com/path#fragment");
        Uri newUri = uri.AppendPath("newpath");
        Assert.AreEqual("https://www.example.com/path/newpath#fragment", newUri.ToString());
    }

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


    [Test]
    public void ContainsPath_WithPath_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var containsPath = uri.ContainsPath("/api");

        // Assert
        Assert.IsTrue(containsPath);
    }

    [Test]
    public void ContainsPath_WithoutPath_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act
        var containsPath = uri.ContainsPath("/api");

        // Assert
        Assert.IsFalse(containsPath);
    }

    [Test]
    public void ContainsPath_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.ContainsPath("/api"));
    }

    [Test]
    public void ContainsPath_EmptyPath_ThrowsArgumentException()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => uri.ContainsPath(""));
    }

    [Test]
    public void HasFileName_WithFileName_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/sample.txt");

        // Act
        var hasFileName = uri.HasFileName("sample.txt");

        // Assert
        Assert.IsTrue(hasFileName);
    }

    [Test]
    public void HasFileName_WithoutFileName_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/");

        // Act
        var hasFileName = uri.HasFileName("sample.txt");

        // Assert
        Assert.IsFalse(hasFileName);
    }

    [Test]
    public void HasFileName_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.HasFileName("sample.txt"));
    }

    [Test]
    public void HasFileName_EmptyFileName_ThrowsArgumentException()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/sample.txt");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => uri.HasFileName(""));
    }

    [Test]
    public void HasQueryParameter_ExistingParameter_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act
        var hasParameter = uri.HasQueryParameter("page");

        // Assert
        Assert.IsTrue(hasParameter);
    }

    [Test]
    public void HasQueryParameter_NonExistingParameter_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act
        var hasParameter = uri.HasQueryParameter("filter");

        // Assert
        Assert.IsFalse(hasParameter);
    }

    [Test]
    public void HasQueryParameter_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.HasQueryParameter("page"));
    }

    [Test]
    public void HasQueryParameter_EmptyParameterName_ThrowsArgumentException()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource?page=2&sort=desc");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => uri.HasQueryParameter(""));
    }

    [Test]
    public void HasSubdomain_WithSubdomain_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("http://sub.example.com/api/resource");

        // Act
        var hasSubdomain = uri.HasSubdomain("sub");

        // Assert
        Assert.IsTrue(hasSubdomain);
    }

    [Test]
    public void HasSubdomain_WithoutSubdomain_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var hasSubdomain = uri.HasSubdomain("sub");

        // Assert
        Assert.IsFalse(hasSubdomain);
    }

    [Test]
    public void HasSubdomain_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.HasSubdomain("sub"));
    }

    [Test]
    public void HasSubdomain_EmptySubdomain_ThrowsArgumentException()
    {
        // Arrange
        var uri = new Uri("http://sub.example.com/api/resource");

        // Act & Assert
        Assert.Throws<ArgumentException>(() => uri.HasSubdomain(""));
    }

    [Test]
    public void IsMailtoUri_ValidMailtoUri_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("mailto:test@example.com");

        // Act
        var isMailtoUri = uri.IsMailtoUri();

        // Assert
        Assert.IsTrue(isMailtoUri);
    }

    [Test]
    public void IsMailtoUri_InvalidScheme_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act
        var isMailtoUri = uri.IsMailtoUri();

        // Assert
        Assert.IsFalse(isMailtoUri);
    }

    [Test]
    public void IsMailtoUri_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.IsMailtoUri());
    }

    [Test]
    public void IsSecure_WithHttpsScheme_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("https://example.com");

        // Act
        var result = uri.IsSecure();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsSecure_WithHttpScheme_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act
        var result = uri.IsSecure();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsSecure_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.IsSecure());
    }

    [Test]
    public void IsTelUri_ValidTelUri_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("tel:1234567890");

        // Act
        var isTelUri = uri.IsTelUri();

        // Assert
        Assert.IsTrue(isTelUri);
    }

    [Test]
    public void IsTelUri_InvalidScheme_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act
        var isTelUri = uri.IsTelUri();

        // Assert
        Assert.IsFalse(isTelUri);
    }

    [Test]
    public void IsTelUri_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.IsTelUri());
    }

    [Test]
    public void IsValidUrl_ValidHttpUrl_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var isValidUrl = uri.IsValidUrl();

        // Assert
        Assert.IsTrue(isValidUrl);
    }

    [Test]
    public void IsValidUrl_ValidHttpsUrl_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("https://example.com/api/resource");

        // Act
        var isValidUrl = uri.IsValidUrl();

        // Assert
        Assert.IsTrue(isValidUrl);
    }

    [Test]
    public void IsValidUrl_InvalidScheme_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("ftp://example.com/api/resource");

        // Act
        var isValidUrl = uri.IsValidUrl();

        // Assert
        Assert.IsFalse(isValidUrl);
    }

    [Test]
    public void IsValidUrl_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.IsValidUrl());
    }


    [Test]
    public void IsWebResource_WithHttpScheme_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act
        var result = uri.IsWebResource();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsWebResource_WithHttpsScheme_ReturnsTrue()
    {
        // Arrange
        var uri = new Uri("https://example.com");

        // Act
        var result = uri.IsWebResource();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsWebResource_WithFtpScheme_ReturnsFalse()
    {
        // Arrange
        var uri = new Uri("ftp://example.com");

        // Act
        var result = uri.IsWebResource();

        // Assert
        Assert.IsFalse(result);
    }

    [Test]
    public void IsWebResource_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.IsWebResource());
    }

    [Test]
    public void GetEmailAddress_ValidMailtoUri_ReturnsEmailAddress()
    {
        // Arrange
        var uri = new Uri("mailto:test@example.com");

        // Act
        var emailAddress = uri.GetEmailAddress();

        // Assert
        Assert.AreEqual("test@example.com", emailAddress);
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
        Assert.AreEqual(".txt", fileExtension);
    }

    [Test]
    public void GetFileExtension_WithoutExtension_ReturnsEmptyString()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/sample");

        // Act
        var fileExtension = uri.GetFileExtension();

        // Assert
        Assert.AreEqual(string.Empty, fileExtension);
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
        Assert.AreEqual("sample.txt", fileName);
    }

    [Test]
    public void GetFileName_WithoutFileName_ReturnsEmptyString()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource/");

        // Act
        var fileName = uri.GetFileName();

        // Assert
        Assert.AreEqual(string.Empty, fileName);
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
        Assert.AreEqual("+1234567890", phoneNumber);
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
        Assert.AreEqual(2, queryParameters.Count);
        Assert.IsTrue(queryParameters.ContainsKey("page"));
        Assert.AreEqual("2", queryParameters["page"]);
        Assert.IsTrue(queryParameters.ContainsKey("sort"));
        Assert.AreEqual("desc", queryParameters["sort"]);
    }

    [Test]
    public void GetQueryParameters_WithoutParameters_ReturnsEmptyDictionary()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var queryParameters = uri.GetQueryParameters();

        // Assert
        Assert.AreEqual(0, queryParameters.Count);
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
        Assert.AreEqual("2", parameterValue);
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
        Assert.AreEqual(expectedJson, json);
    }

    [Test]
    public void GetQueryStringAsJson_EmptyQuery_ReturnsEmptyJsonString()
    {
        // Arrange
        var uri = new Uri("http://example.com/api/resource");

        // Act
        var json = uri.GetQueryStringAsJson();

        // Assert
        Assert.AreEqual("{}", json);
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
        Assert.AreEqual("/api/resource?page=2", relativePath);
    }

    [Test]
    public void GetRelativePath_RelativeUri_ReturnsOriginalString()
    {
        // Arrange
        var uri = new Uri("/api/resource", UriKind.Relative);

        // Act
        var relativePath = uri.GetRelativePath();

        // Assert
        Assert.AreEqual("/api/resource", relativePath);
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
        Assert.AreEqual("subdomain", subdomain);
    }

    [Test]
    public void GetSubdomain_WithoutSubdomain_ReturnsEmptyString()
    {
        // Arrange
        var uri = new Uri("http://example.com");

        // Act
        var subdomain = uri.GetSubdomain();

        // Assert
        Assert.AreEqual(string.Empty, subdomain);
    }

    [Test]
    public void GetSubdomain_NullUri_ThrowsArgumentNullException()
    {
        // Arrange
        Uri uri = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => uri.GetSubdomain());
    }

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
