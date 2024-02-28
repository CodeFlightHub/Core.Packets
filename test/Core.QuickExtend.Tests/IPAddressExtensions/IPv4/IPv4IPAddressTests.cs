using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.IPAddressExtensions.IPv4
{
    internal interface IPv4IPAddressTests
    {

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


    }
}
