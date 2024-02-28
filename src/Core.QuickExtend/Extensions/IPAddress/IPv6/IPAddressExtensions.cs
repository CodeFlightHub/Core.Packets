using System.Net;
using System.Net.Sockets;

namespace Core.QuickExtend.Extensions;
 
public static partial class IPAddressExtensions
{
    /// <summary>
    /// Checks if the given IP address is an IPv6 address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is an IPv6 address, otherwise false.</returns>
    public static bool IsIPv6Address(this IPAddress ipAddress)
    {
        return ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6;
    }


    /// <summary>
    /// Checks if the given string represents a valid IPv6 address.
    /// </summary>
    /// <param name="input">The string to check.</param>
    /// <returns>True if the string represents a valid IPv6 address, otherwise false.</returns>
    public static bool IsIPv6Address(this string input)
    {
        IPAddress ipAddress;
        return IPAddress.TryParse(input, out ipAddress) && ipAddress.IsIPv6Address();
    }


    /// <summary>
    /// Checks if the given IP address is an IPv6 link-local address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is an IPv6 link-local address, otherwise false.</returns>
    public static bool IsIPv6LinkLocal(this IPAddress ipAddress)
    {
        return ipAddress.AddressFamily == AddressFamily.InterNetworkV6 && ipAddress.IsIPv6LinkLocal;
    }


    /// <summary>
    /// Checks if the given IP address is an IPv6 site-local address.
    /// </summary>
    /// <param name="ipAddress">The IP address to check.</param>
    /// <returns>True if the IP address is an IPv6 site-local address, otherwise false.</returns>
    public static bool IsIPv6SiteLocal(this IPAddress ipAddress)
    {
        return ipAddress.AddressFamily == AddressFamily.InterNetworkV6 && ipAddress.IsIPv6SiteLocal;
    }


    /// <summary>
    /// Checks if the given IPv6 address is within the specified range.
    /// </summary>
    /// <param name="ipAddress">The IPv6 address to check.</param>
    /// <param name="startAddress">The start of the range.</param>
    /// <param name="endAddress">The end of the range.</param>
    /// <returns>True if the IPv6 address is within the specified range, otherwise false.</returns>
    public static bool IsIPv6AddressInRange(this IPAddress ipAddress, IPAddress startAddress, IPAddress endAddress)
    {
        byte[] startBytes = startAddress.GetAddressBytes();
        byte[] endBytes = endAddress.GetAddressBytes();
        byte[] ipBytes = ipAddress.GetAddressBytes();

        if (startBytes.Length != 16 || endBytes.Length != 16 || ipBytes.Length != 16)
            throw new ArgumentException("Invalid IPv6 address or range.");

        for (int i = 0; i < 16; i++)
        {
            if (ipBytes[i] < startBytes[i] || ipBytes[i] > endBytes[i])
                return false;
        }

        return true;
    }


    /// <summary>
    /// Gets the network address of the given IPv6 address.
    /// </summary>
    /// <param name="ipAddress">The IPv6 address.</param>
    /// <param name="subnetMask">The subnet mask.</param>
    /// <returns>The network address.</returns>
    public static IPAddress GetIPv6NetworkAddress(this IPAddress ipAddress, IPAddress subnetMask)
    {
        if (ipAddress.AddressFamily != System.Net.Sockets.AddressFamily.InterNetworkV6)
            throw new ArgumentException("IPv6 addresses are only supported.");

        byte[] ipBytes = ipAddress.GetAddressBytes();
        byte[] maskBytes = subnetMask.GetAddressBytes();

        if (ipBytes.Length != maskBytes.Length)
            throw new ArgumentException("IP address and subnet mask length mismatch.");

        byte[] networkBytes = new byte[ipBytes.Length];
        for (int i = 0; i < ipBytes.Length; i++)
        {
            networkBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
        }

        return new IPAddress(networkBytes);
    }


}




