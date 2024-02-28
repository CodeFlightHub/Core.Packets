using System.Net;
using System.Net.Sockets;
namespace Core.QuickExtend.Extensions;

public static partial class IPAddressExtensions
{

    /// <summary>
    /// Checks if the given string represents a valid IP address (either IPv4 or IPv6).
    /// </summary>
    /// <param name="ipAddress">The string to check.</param>
    /// <returns>True if the string represents a valid IP address, otherwise false.</returns>
    public static bool IsValidIpAddress(this string ipAddress)
    {
        if (string.IsNullOrEmpty(ipAddress))
        {
            return false;
        }

        return IPAddress.TryParse(ipAddress, out _);
    }


    /// <summary>
    /// Checks if the IP address is within a given range.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <param name="startRange">The start of the IP address range.</param>
    /// <param name="endRange">The end of the IP address range.</param>
    /// <returns>True if the IP address is within the range, otherwise false.</returns>
    public static bool IsWithinRange(this IPAddress ipAddress, IPAddress startRange, IPAddress endRange)
    {
        byte[] startBytes = startRange.GetAddressBytes();
        byte[] endBytes = endRange.GetAddressBytes();
        byte[] ipBytes = ipAddress.GetAddressBytes();

        for (int i = 0; i < startBytes.Length; i++)
        {
            if (ipBytes[i] < startBytes[i] || ipBytes[i] > endBytes[i])
            {
                return false;
            }
        }

        return true;
    }


    /// <summary>
    /// Checks if the given IP address is a Class A address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is a Class A address, otherwise false.</returns>
    public static bool IsClassA(this IPAddress ipAddress)
    {
        // Class A addresses have the first octet value between 1 and 126.
        return ipAddress.GetAddressBytes()[0] >= 1 && ipAddress.GetAddressBytes()[0] <= 126;
    }


    /// <summary>
    /// Checks if the given IP address is a Class B address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is a Class B address, otherwise false.</returns>
    public static bool IsClassB(this IPAddress ipAddress)
    {
        // Class B addresses have the first octet value between 128 and 191.
        return ipAddress.GetAddressBytes()[0] >= 128 && ipAddress.GetAddressBytes()[0] <= 191;
    }


    /// <summary>
    /// Checks if the given IP address is a Class C address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is a Class C address, otherwise false.</returns>
    public static bool IsClassC(this IPAddress ipAddress)
    {
        // Class C addresses have the first octet value between 192 and 223.
        return ipAddress.GetAddressBytes()[0] >= 192 && ipAddress.GetAddressBytes()[0] <= 223;
    }


    /// <summary>
    /// Checks if the given IP address is a loopback address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is a loopback address, otherwise false.</returns>
    public static bool IsLoopback(this IPAddress ipAddress)
    {
        return IPAddress.IsLoopback(ipAddress);
    }


    /// <summary>
    /// Checks if the given IP address is a private network address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is a private network address, otherwise false.</returns>
    public static bool IsPrivateNetwork(this IPAddress ipAddress)
    {
        byte[] bytes = ipAddress.GetAddressBytes();

        return bytes[0] == 10 || (bytes[0] == 172 && bytes[1] >= 16 && bytes[1] < 32) || (bytes[0] == 192 && bytes[1] == 168);
    }


    /// <summary>
    /// Checks if the given IP address is a public network address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is a public network address, otherwise false.</returns>
    public static bool IsPublicNetwork(this IPAddress ipAddress)
    {
        return !ipAddress.IsLoopback() && !ipAddress.IsPrivateNetwork();
    }


    /// <summary>
    /// Checks if the given IP address is a multicast address.
    /// </summary>
    /// <param name="ipAddress">The IP address.</param>
    /// <returns>True if the IP address is a multicast address, otherwise false.</returns>
    public static bool IsMulticastAddress(this IPAddress ipAddress)
    {
        return ipAddress.AddressFamily == AddressFamily.InterNetwork && ipAddress.GetAddressBytes()[0] >= 224 && ipAddress.GetAddressBytes()[0] <= 239;
    }


    /// <summary>
    /// Checks if the given IP address is a reserved address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is a reserved address, otherwise false.</returns>
    public static bool IsReservedAddress(this IPAddress ipAddress)
    {
        return ipAddress.IsPrivateNetwork() || ipAddress.IsLoopback() || ipAddress.IsMulticastAddress() || IPAddress.IsLoopback(ipAddress) || ipAddress.IsIPv6LinkLocal;
    }


}
