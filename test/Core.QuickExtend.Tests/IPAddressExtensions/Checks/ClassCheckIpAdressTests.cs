using System.Net;

namespace Core.QuickExtend.Tests.IPAddressExtensions.Checks;

internal class ClassCheckIpAdressTests
{
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
}
