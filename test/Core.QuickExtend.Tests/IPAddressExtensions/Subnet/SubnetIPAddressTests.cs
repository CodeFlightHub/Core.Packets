using Core.QuickExtend.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuickExtend.Tests.IPAddressExtensions.Checks
{

    internal class SubnetIPAddressTests
    {

        [TestCase("192.168.1.1", "192.168.1.0/24", ExpectedResult = true)]
        [TestCase("192.168.1.1", "192.168.1.0/25", ExpectedResult = true)]
        [TestCase("192.168.1.1", "192.168.1.128/25", ExpectedResult = true)]  
        [TestCase("192.168.1.1", "192.168.2.0/24", ExpectedResult = false)]
        [TestCase("192.168.1.1", "10.0.0.0/8", ExpectedResult = false)]
        [TestCase("192.168.1.1", "192.168.1.1", ExpectedResult = true)]
        [TestCase("192.168.1.1", "192.168.1.1/32", ExpectedResult = true)]
        [TestCase("192.168.1.1", "192.168.1.2/32", ExpectedResult = false)]
        [TestCase("192.168.1.1", "192.168.1.0/31", ExpectedResult = true)]

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
}
 
