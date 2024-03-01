using System.Net;

namespace Core.QuickExtend.Extensions;

public static partial class IPAddressExtensions
{

    /// <summary>
    /// Checks if the given IP address is an IPv4 address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is an IPv4 address, otherwise false.</returns>
    public static bool IsIPv4Address(this IPAddress ipAddress)
    {
        return ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork;
    }


    /// <summary>
    /// Checks if the given string represents a valid IPv4 address.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns>True if the string represents a valid IPv4 address, otherwise false.</returns>
    public static bool IsIPv4Address(this string input)
    {
        IPAddress ipAddress;
        return IPAddress.TryParse(input, out ipAddress) && ipAddress.IsIPv4Address();
    }


    /// <summary>
    /// Checks if the given IP address is an IPv4-mapped IPv6 address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is an IPv4-mapped IPv6 address, otherwise false.</returns>
    public static bool IsIPv4MappedToIPv6(this IPAddress ipAddress)
    {
        return ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6 && ipAddress.IsIPv4MappedToIPv6;
    }



    /// <summary>
    /// Checks if the given IPv4 address is within the specified range.
    /// </summary>
    /// <param name="ipAddress">The IPv4 address to check.</param>
    /// <param name="startAddress">The start of the range.</param>
    /// <param name="endAddress">The end of the range.</param>
    /// <returns>True if the IPv4 address is within the specified range, otherwise false.</returns>
    public static bool IsIPv4AddressInRange(this IPAddress ipAddress, IPAddress startAddress, IPAddress endAddress)
    {
        byte[] startBytes = startAddress.GetAddressBytes();
        byte[] endBytes = endAddress.GetAddressBytes();
        byte[] ipBytes = ipAddress.GetAddressBytes();

        if (startBytes.Length != 4 || endBytes.Length != 4 || ipBytes.Length != 4)
            throw new ArgumentException("Invalid IPv4 address or range.");

        for (int i = 0; i < 4; i++)
        {
            if (ipBytes[i] < startBytes[i] || ipBytes[i] > endBytes[i])
                return false;
        }

        return true;
    }


}




