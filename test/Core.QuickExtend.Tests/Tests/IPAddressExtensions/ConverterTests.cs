using System.Net;

namespace Core.QuickExtend.Tests.Tests.IPAddressExtensions;

internal class ConverterTests
{
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
}
