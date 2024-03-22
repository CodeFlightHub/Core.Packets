using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.Tests.IPAddressExtensions;

internal class CheckTests
{
    [TestCase("192.168.1.1", true)] // Valid IP address
    [TestCase("2001:0db8:85a3:0000:0000:8a2e:0370:7334", true)] // Valid IP address
    [TestCase("", false)] // Empty string
    [TestCase("not_an_ip_address", false)] // Invalid IP address format
    public void IsValidIpAddress_WithStringInput_ReturnsExpectedResult(string input, bool expectedResult)
    {
        // Act
        var result = input.IsValidIpAddress();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("10.0.0.1", true)] // Private network address
    [TestCase("192.168.1.1", true)] // Private network address
    [TestCase("172.16.0.1", true)] // Private network address
    [TestCase("8.8.8.8", false)] // Public network address
    public void IsPrivateNetwork_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.IsPrivateNetwork();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("8.8.8.8", true)] // Public network address
    [TestCase("192.168.1.1", false)] // Private network address
    [TestCase("10.0.0.1", false)] // Private network address
    [TestCase("172.16.0.1", false)] // Private network address
    public void IsPublicNetwork_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.IsPublicNetwork();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("192.168.1.1", true)] // Reserved address (private network)
    [TestCase("127.0.0.1", true)] // Reserved address (loopback)
    [TestCase("224.0.0.1", true)] // Reserved address (multicast)
    [TestCase("::1", true)] // Reserved address (loopback)
    [TestCase("fe80::1", true)] // Reserved address (IPv6 link-local)
    [TestCase("fec0::1", false)] // Non-reserved address (IPv6 site-local is deprecated)
    [TestCase("8.8.8.8", false)] // Non-reserved address
    public void IsReservedAddress_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.IsReservedAddress();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("192.168.1.1", false)] // Class C address
    [TestCase("10.0.0.1", true)]      // Class A address
    [TestCase("172.16.0.1", false)]   // Class B address
    [TestCase("127.0.0.1", false)]    // Loopback address
    public void IsClassA_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.IsClassA();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("192.168.1.1", false)] // Class C address
    [TestCase("10.0.0.1", false)]     // Class A address
    [TestCase("172.16.0.1", true)]    // Class B address
    [TestCase("127.0.0.1", false)]    // Loopback address
    public void IsClassB_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.IsClassB();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("192.168.1.1", true)] // Class C address
    [TestCase("10.0.0.1", false)]    // Class A address
    [TestCase("172.16.0.1", false)]  // Class B address
    [TestCase("127.0.0.1", false)]   // Loopback address
    public void IsClassC_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.IsClassC();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }
}
