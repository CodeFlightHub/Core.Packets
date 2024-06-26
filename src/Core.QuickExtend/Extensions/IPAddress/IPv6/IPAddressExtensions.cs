﻿using System.Net;
using System.Net.Sockets;

namespace CodeFlightHub.CorePackets.QuickExtend;

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
}
