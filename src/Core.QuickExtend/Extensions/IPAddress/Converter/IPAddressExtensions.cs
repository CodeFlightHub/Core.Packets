using System.Net;

namespace Core.QuickExtend.Extensions;

public static partial class IPAddressExtensions
{

    /// <summary>
    /// Converts the IP address to an IPEndPoint with the specified port number.
    /// </summary>
    /// <param name="ipAddress">The IP address to convert.</param>
    /// <param name="port">The port number for the IPEndPoint.</param>
    /// <returns>The resulting IPEndPoint.</returns>
    public static IPEndPoint ToIPEndPoint(this IPAddress ipAddress, int port)
    {
        return new IPEndPoint(ipAddress, port);
    }


    /// <summary>
    /// Converts the IP address to a URL string with the specified protocol (default is "http://").
    /// </summary>
    /// <param name="ipAddress">The IP address to convert.</param>
    /// <param name="protocol">The protocol to use in the URL (default is "http://").</param>
    /// <returns>The URL string representation of the IP address.</returns>
    public static string ToUrl(this IPAddress ipAddress, string protocol = "https://")
    {
        return $"{protocol}{ipAddress}";
    }


    /// <summary>
    /// Converts the IP address to a hexadecimal string representation.
    /// </summary>
    /// <param name="ipAddress">The IP address to convert.</param>
    /// <returns>The hexadecimal string representation of the IP address.</returns>
    public static string ToHex(this IPAddress ipAddress)
    {
        byte[] bytes = ipAddress.GetAddressBytes();
        return BitConverter.ToString(bytes).Replace("-", "");
    }


}
