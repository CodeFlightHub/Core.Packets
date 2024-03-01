using Core.QuickExtend.Enums;
using System.Net;

namespace Core.QuickExtend.Tests.IPAddressExtension;

internal class IPAddressExtensionUnitTest
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
        Assert.AreEqual(expectedResult, result);
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
        Assert.AreEqual(expectedResult, result);
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
        Assert.AreEqual(expectedResult, result);
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
        Assert.AreEqual(expectedResult, result);
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
        Assert.AreEqual(expectedResult, result);
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
        Assert.AreEqual(expectedResult, result);
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
        Assert.AreEqual(expectedResult, result);
    }

    [TestCase("192.168.1.1", 8080, ExpectedResult = "192.168.1.1:8080")]
    public string ToIPEndPoint_WhenGivenIPAddressAndPort_ReturnsExpectedResult(string ipAddressString, int port)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.ToIPEndPoint(port);

        // Assert
        return result.ToString();
    }

    [TestCase("192.168.1.1", ExpectedResult = "https://192.168.1.1")]
    public string ToUrl_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.ToUrl();

        // Assert
        return result;
    }

    [TestCase("192.168.1.1", ExpectedResult = "C0A80101")]
    public string ToHex_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.ToHex();

        // Assert
        return result;
    }

    [TestCase("192.168.1.1", IpAddressType.IPv4)]
    [TestCase("::1", IpAddressType.IPv6)]
    [TestCase("::ffff:192.168.1.1", IpAddressType.IPv4MappedToIPv6)]
    [TestCase("invalid_ip_address", IpAddressType.Unknown)]
    public void GetIpAddressType_WithStringInput_ReturnsExpectedResult(string ipAddressString, IpAddressType expectedResult)
    {
        // Act
        var result = ipAddressString.GetIpAddressType();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestCase("192.168.1.1", IpAddressType.IPv4)]
    [TestCase("::1", IpAddressType.IPv6)]
    [TestCase("::ffff:192.168.1.1", IpAddressType.IPv4MappedToIPv6)]
    [TestCase(null, IpAddressType.Unknown)]
    public void GetIpAddressType_WithIPAddressInput_ReturnsExpectedResult(string ipAddressString, IpAddressType expectedResult)
    {
        // Arrange
        var ipAddress = ipAddressString != null ? IPAddress.Parse(ipAddressString) : null;

        // Act
        var result = ipAddress.GetIpAddressType();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [Test]
    public void GetNetworkAddress_ValidInputs_ReturnsExpectedResult()
    {
        // Arrange
        var ipAddress = IPAddress.Parse("192.168.1.10");
        var subnetMask = IPAddress.Parse("255.255.255.0");
        var expectedNetworkAddress = IPAddress.Parse("192.168.1.0");

        // Act
        var result = ipAddress.GetNetworkAddress(subnetMask);

        // Assert
        Assert.AreEqual(expectedNetworkAddress, result);
    }

    [Test]
    public void GetNetworkAddress_NullIPAddress_ThrowsArgumentNullException()
    {
        // Arrange
        IPAddress ipAddress = null;
        var subnetMask = IPAddress.Parse("255.255.255.0");

        // Assert
        Assert.Throws<ArgumentNullException>(() => ipAddress.GetNetworkAddress(subnetMask));
    }

    [Test]
    public void GetNetworkAddress_NullSubnetMask_ThrowsArgumentNullException()
    {
        // Arrange
        var ipAddress = IPAddress.Parse("192.168.1.10");
        IPAddress subnetMask = null;

        // Assert
        Assert.Throws<ArgumentNullException>(() => ipAddress.GetNetworkAddress(subnetMask));
    }

    [Test]
    public void GetNetworkAddress_IPAddressAndSubnetMaskLengthMismatch_ThrowsNoException()
    {
        // Arrange
        var ipAddress = IPAddress.Parse("192.168.1.10");
        var subnetMask = IPAddress.Parse("255.255.0.0");

        // Act & Assert
        Assert.DoesNotThrow(() => ipAddress.GetNetworkAddress(subnetMask));
    }

    [Test]
    public void GetNetworkAddress_IPAddressAndSubnetMaskAddressFamilyMismatch_ThrowsArgumentException()
    {
        // Arrange
        var ipAddress = IPAddress.Parse("192.168.1.10");
        var subnetMask = IPAddress.Parse("ffff:ffff:ffff:ffff:0:0:0:0");

        // Assert
        Assert.Throws<ArgumentException>(() => ipAddress.GetNetworkAddress(subnetMask));
    }

    [TestCase("192.168.1.1", "255.255.255.0", "192.168.1.255")] // IPv4 broadcast address
    public void GetBroadcastAddress_WhenGivenIPAddressAndSubnetMask_ReturnsExpectedResult(string ipAddressString, string subnetMaskString, string expectedBroadcastAddressString)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);
        var subnetMask = IPAddress.Parse(subnetMaskString);
        var expectedBroadcastAddress = IPAddress.Parse(expectedBroadcastAddressString);

        // Act
        var result = ipAddress.GetBroadcastAddress(subnetMask);

        // Assert
        Assert.AreEqual(expectedBroadcastAddress, result);
    }

    [TestCase("192.168.1.100", "255.255.255.0", "0.0.0.100")] // IPv4 address with subnet mask
    [TestCase("10.20.30.40", "255.255.0.0", "0.0.30.40")] // IPv4 address with subnet mask
    public void GetHostAddress_WhenGivenIPAddressAndSubnetMask_ReturnsExpectedResult(string ipAddressString, string subnetMaskString, string expectedHostAddressString)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);
        var subnetMask = IPAddress.Parse(subnetMaskString);
        var expectedHostAddress = IPAddress.Parse(expectedHostAddressString);

        // Act
        var result = ipAddress.GetHostAddress(subnetMask);

        // Assert
        Assert.AreEqual(expectedHostAddress, result);
    }

    [Test]
    public void IsIPv4Address_WithValidIPv4Address_ReturnsTrue()
    {
        // Arrange
        var ipAddress = IPAddress.Parse("192.168.1.1");

        // Act
        var result = ipAddress.IsIPv4Address();

        // Assert
        Assert.IsTrue(result);
    }

    [Test]
    public void IsIPv4Address_WithInvalidIPv4Address_ReturnsFalse()
    {
        // Arrange
        var ipAddress = IPAddress.Parse("2001:0db8:85a3:0000:0000:8a2e:0370:7334");

        // Act
        var result = ipAddress.IsIPv4Address();

        // Assert
        Assert.IsFalse(result);
    }

    [TestCase("192.168.1.1", true)] // Valid IPv4 address
    [TestCase("2001:0db8:85a3:0000:0000:8a2e:0370:7334", false)] // Invalid IPv4 address
    public void IsIPv4Address_WithStringInput_ReturnsExpectedResult(string input, bool expectedResult)
    {
        // Act
        var result = input.IsIPv4Address();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestCase("::ffff:192.168.1.1", true)] // IPv4-mapped IPv6 address
    [TestCase("::1", false)] // Non IPv4-mapped IPv6 address
    public void IsIPv4MappedToIPv6_WhenGivenIPAddress_ReturnsExpectedResult(string ipAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);

        // Act
        var result = ipAddress.IsIPv4MappedToIPv6();

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestCase("192.168.1.1", "192.168.0.0", "192.168.255.255", true)] // IPv4 address within range
    [TestCase("10.0.0.1", "192.168.0.0", "192.168.255.255", false)] // IPv4 address outside of range
    public void IsIPv4AddressInRange_WhenGivenIPAddressAndRange_ReturnsExpectedResult(string ipAddressString, string startAddressString, string endAddressString, bool expectedResult)
    {
        // Arrange
        var ipAddress = IPAddress.Parse(ipAddressString);
        var startAddress = IPAddress.Parse(startAddressString);
        var endAddress = IPAddress.Parse(endAddressString);

        // Act
        var result = ipAddress.IsIPv4AddressInRange(startAddress, endAddress);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

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
        Assert.AreEqual(expectedResult, result);
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
        Assert.AreEqual(expectedResult, result);
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

    [TestCase("192.168.1.1", "192.168.1.0/24", ExpectedResult = true)]
    [TestCase("192.168.1.1", "192.168.1.0/25", ExpectedResult = true)]
    [TestCase("192.168.1.1", "192.168.1.128/25", ExpectedResult = true)]
    [TestCase("192.168.1.1", "192.168.2.0/24", ExpectedResult = false)]
    [TestCase("192.168.1.1", "10.0.0.0/8", ExpectedResult = false)]
    [TestCase("192.168.1.1", "192.168.1.1", ExpectedResult = true)]
    [TestCase("192.168.1.1", "192.168.1.1/32", ExpectedResult = true)]
    [TestCase("192.168.1.1", "192.168.1.2/32", ExpectedResult = false)]
    [TestCase("192.168.1.1", "192.168.1.0/31", ExpectedResult = true)]

    [Test]
    public bool IsInSubnet_Test(string ipAddress, string subnet)
    {
        var result = IPAddress.Parse(ipAddress).IsInSubnet(subnet);
        return result;
    }

    [TestCase("192.168.1.1", "192.168.1.2", "255.255.255.0", true)] // IP addresses in the same subnet
    [TestCase("192.168.1.1", "192.168.2.1", "255.255.255.0", false)] // IP addresses not in the same subnet
    public void IsInSameSubnet_WhenGivenIPAddresses_ReturnsExpectedResult(string ipAddressString1, string ipAddressString2, string subnetMaskString, bool expectedResult)
    {
        // Arrange
        var ipAddress1 = IPAddress.Parse(ipAddressString1);
        var ipAddress2 = IPAddress.Parse(ipAddressString2);
        var subnetMask = IPAddress.Parse(subnetMaskString);

        // Act
        var result = ipAddress1.IsInSameSubnet(ipAddress2, subnetMask);

        // Assert
        Assert.AreEqual(expectedResult, result);
    }

    [TestCase("255.255.255.0", 24)] // Subnet mask length 24
    [TestCase("255.255.255.128", 25)] // Subnet mask length 25
    [TestCase("255.255.255.252", 30)] // Subnet mask length 30
    public void GetSubnetMaskLength_WhenGivenSubnetMask_ReturnsExpectedResult(string subnetMaskString, int expectedLength)
    {
        // Arrange
        var subnetMask = IPAddress.Parse(subnetMaskString);

        // Act
        var result = subnetMask.GetSubnetMaskLength();

        // Assert
        Assert.AreEqual(expectedLength, result);
    }

    [TestCase("255.255.255.0", 24)] // Subnet mask length 24
    [TestCase("255.255.255.128", 25)] // Subnet mask length 25
    [TestCase("255.255.255.252", 30)] // Subnet mask length 30
    public void GetSubnetMaskLength_WhenGivenSubnetMask_ReturnsExpectedLength(string subnetMaskString, int expectedLength)
    {
        // Arrange
        var subnetMask = IPAddress.Parse(subnetMaskString);

        // Act
        var result = subnetMask.GetSubnetMaskLength();

        // Assert
        Assert.AreEqual(expectedLength, result);
    }
}
