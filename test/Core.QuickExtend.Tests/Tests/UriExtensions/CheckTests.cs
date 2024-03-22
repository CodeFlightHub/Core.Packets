namespace Core.QuickExtend.Tests.Tests.UriExtensions;

internal class CheckTests
{
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
}
