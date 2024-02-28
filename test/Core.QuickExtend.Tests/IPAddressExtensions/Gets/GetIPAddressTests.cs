using Core.QuickExtend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.IPAddressExtensions.Gets
{
    internal class GetIPAddressTests
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


    }
}
