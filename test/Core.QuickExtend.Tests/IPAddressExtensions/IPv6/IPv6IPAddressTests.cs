using System.Net;

namespace Core.QuickExtend.Tests.IPAddressExtensions.IPv6;

internal interface IPv6IPAddressTests
{
    [Test]
    public void IsIPv6Address_WithValidIPv6Address_ReturnsTrue()
    {
        // Arrange
        var ipAddress = IPAddress.Parse("2001:0db8:85a3:0000:0000:8a2e:0370:7334");

        // Act
        var result = ipAddress.IsIPv6Address();

        // Assert
        Assert.IsTrue(result);
    }


    [Test]
    public void IsIPv6Address_WithInvalidIPv6Address_ReturnsFalse()
    {
        // Arrange
        var ipAddress = IPAddress.Parse("192.168.1.1");

        // Act
        var result = ipAddress.IsIPv6Address();

        // Assert
        Assert.IsFalse(result);
    }


    [TestCase("2001:0db8:85a3:0000:0000:8a2e:0370:7334", true)] // Valid IPv6 address
    [TestCase("192.168.1.1", false)] // Invalid IPv6 address
    public void IsIPv6Address_WithStringInput_ReturnsExpectedResult(string input, bool expectedResult)
    {
        // Act
        var result = input.IsIPv6Address();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }


    [TestCase("fe80::1", true)] // IPv6 link-local address
    [TestCase("::1", false)] // Non IPv6 link-local address
    public void IsIPv6LinkLocal_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.IsIPv6LinkLocal();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }


    [TestCase("fec0::1", true)] // IPv6 site-local address
    [TestCase("::1", false)] // Non IPv6 site-local address
    public void IsIPv6SiteLocal_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.IsIPv6SiteLocal();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }


    [TestCase("2001:db8::1", "ffff:ffff:ffff:ffff:ffff:ffff:ffff:ff00", "2001:db8::")] // IPv6 network address
    public void GetIPv6NetworkAddress_WhenGivenIPv6AddressAndSubnetMask_ReturnsExpectedResult(string ipAddressString, string subnetMaskString, string expectedNetworkAddressString)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);
        var subnetMask = IPAddress.Parse(subnetMaskString);
        var expectedNetworkAddress = IPAddress.Parse(expectedNetworkAddressString);

        // Act
        var result = ipAddress.GetIPv6NetworkAddress(subnetMask);

        // Assert
        Assert.AreEqual(expectedNetworkAddress, result);
    }


    [TestCase("fe80::1", "fe80::", "fe80::ffff", true)] // IPv6 address within range
    [TestCase("::1", "fe80::", "fe80::ffff", false)] // IPv6 address outside of range
    public void IsIPv6AddressInRange_WhenGivenIPAddressAndRange_ReturnsExpectedResult(string ipAddressString, string startAddressString, string endAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);
        var startAddress = IPAddress.Parse(startAddressString);
        var endAddress = IPAddress.Parse(endAddressString);

        // Act
        var result = ipAddress.IsIPv6AddressInRange(startAddress, endAddress);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }



}
