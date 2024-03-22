using Core.QuickExtend.Enums;
using System.Net;

namespace Core.QuickExtend.Tests.Tests.IPAddressExtensions;

internal class GetTests
{
    [TestCase("192.168.1.1", IpAddressType.IPv4)]
    [TestCase("::1", IpAddressType.IPv6)]
    [TestCase("::ffff:192.168.1.1", IpAddressType.IPv4MappedToIPv6)]
    [TestCase("invalid_ip_address", IpAddressType.Unknown)]
    public void GetIpAddressType_WithStringInput_ReturnsExpectedResult(string ipAddressString, IpAddressType expectedResult)
    {
        // Act
        var result = ipAddressString.GetIpAddressType();

        // Assert
        Assert.That(result, Is.EqualTo(expectedResult));
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
        Assert.That(result, Is.EqualTo(expectedResult));
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
        Assert.That(result, Is.EqualTo(expectedNetworkAddress));
    }

    [Test]
    public void GetNetworkAddress_NullSubnetMask_ThrowsArgumentNullException()
    {
        // Arrange
        var ipAddress = IPAddress.Parse("192.168.1.10");
        IPAddress? subnetMask = null;

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
        Assert.That(result, Is.EqualTo(expectedBroadcastAddress));
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
        Assert.That(result, Is.EqualTo(expectedHostAddress));
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
        Assert.That(result, Is.EqualTo(expectedNetworkAddress));
    }
}
