using System.Net;

namespace Core.QuickExtend.Tests.Tests.IPAddressExtensions;

internal class GeneralTests
{
    [TestCase("192.168.1.1", 24, ExpectedResult = "192.168.1.0")]
    [TestCase("192.168.1.1", 16, ExpectedResult = "192.168.0.0")]
    public string ApplyPrefixMask_WhenGivenIPAddressAndPrefixLength_ReturnsExpectedResult(string ipAddressString, int prefixLength)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.ApplyPrefixMask(prefixLength);

        // Assert
        return result.ToString();
    }

    [TestCase("127.0.0.1", true)] // Loopback address
    [TestCase("192.168.1.1", false)] // Non-loopback address
    public void IsLoopback_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.IsLoopback();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("224.0.0.1", true)] // Multicast address
    [TestCase("8.8.8.8", false)] // Non-multicast address
    public void IsMulticast_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.IsMulticastAddress();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
    }

    [TestCase("8.8.8.8", ExpectedResult = "dns.google")]
    [TestCase("1.1.1.1", ExpectedResult = "one.one.one.one")]
    [TestCase("invalid", ExpectedResult = null)]
    public string ReverseDNSLookup_ValidIPAddress_ReturnsExpected(string ipAddress)
    {
        // Arrange
        IPAddress parsedIPAddress;
        bool isValidIPAddress = IPAddress.TryParse(ipAddress, out parsedIPAddress);

        // Act
        string result = isValidIPAddress ? parsedIPAddress.ReverseDNSLookup() : null;

        // Assert
        return result;
    }
}
