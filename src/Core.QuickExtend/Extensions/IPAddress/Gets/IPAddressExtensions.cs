using Core.QuickExtend.Enums;
using System.Net;
using System.Net.Sockets;

namespace Core.QuickExtend.Extensions;

public static partial class IPAddressExtensions
{
    /// <summary>
    /// Determines the type of the given IP address.
    /// </summary>
    /// <param name="ipAddress">The IP address.</param>
    /// <returns>The type of the IP address.</returns>
    public static IpAddressType GetIpAddressType(this string ipAddress)
    {
        if (!IPAddress.TryParse(ipAddress, out IPAddress address))
        {
            return IpAddressType.Unknown;
        }

        if (address.AddressFamily == AddressFamily.InterNetwork)
        {
            return IpAddressType.IPv4;
        }
        else if (address.AddressFamily == AddressFamily.InterNetworkV6)
        {
            if (address.IsIPv4MappedToIPv6)
            {
                return IpAddressType.IPv4MappedToIPv6;
            }
            else
            {
                return IpAddressType.IPv6;
            }
        }
        else
        {
            return IpAddressType.Unknown;
        }
    }


    /// <summary>
    /// Determines the type of the given IP address.
    /// </summary>
    /// <param name="ipAddress">The IP address.</param>
    /// <returns>The type of the IP address.</returns>
    public static IpAddressType GetIpAddressType(this IPAddress ipAddress)
    {
        if (ipAddress == null)
        {
            return IpAddressType.Unknown;
        }

        if (ipAddress.AddressFamily == AddressFamily.InterNetwork)
        {
            return IpAddressType.IPv4;
        }
        else if (ipAddress.AddressFamily == AddressFamily.InterNetworkV6)
        {
            if (ipAddress.IsIPv4MappedToIPv6)
            {
                return IpAddressType.IPv4MappedToIPv6;
            }
            else
            {
                return IpAddressType.IPv6;
            }
        }
        else
        {
            return IpAddressType.Unknown;
        }
    }



    /// <summary>
    /// Gets the network address of the given IP address.
    /// </summary>
    /// <param name="ipAddress">The IP address.</param>
    /// <param name="subnetMask">The subnet mask.</param>
    /// <returns>The network address.</returns>
    public static IPAddress GetNetworkAddress(this IPAddress ipAddress, IPAddress subnetMask)
    {
        if (ipAddress == null)
            throw new ArgumentNullException(nameof(ipAddress));

        if (subnetMask == null)
            throw new ArgumentNullException(nameof(subnetMask));

        if (ipAddress.AddressFamily != subnetMask.AddressFamily)
            throw new ArgumentException("IP address and subnet mask are not of the same AddressFamily.");

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


    /// <summary>
    /// Gets the broadcast address of the given IP address.
    /// </summary>
    /// <param name="ipAddress">The IP address.</param>
    /// <param name="subnetMask">The subnet mask.</param>
    /// <returns>The broadcast address.</returns>
    public static IPAddress GetBroadcastAddress(this IPAddress ipAddress, IPAddress subnetMask)
    {
        byte[] ipBytes = ipAddress.GetAddressBytes();
        byte[] maskBytes = subnetMask.GetAddressBytes();

        if (ipBytes.Length != maskBytes.Length)
            throw new ArgumentException("IP address and subnet mask length mismatch.");

        byte[] broadcastBytes = new byte[ipBytes.Length];
        for (int i = 0; i < ipBytes.Length; i++)
        {
            broadcastBytes[i] = (byte)(ipBytes[i] | ~maskBytes[i]);
        }

        return new IPAddress(broadcastBytes);
    }

    /// <summary>
    /// Calculates the host address from the given IP address and subnet mask.
    /// </summary>
    /// <param name="ipAddress">The IP address.</param>
    /// <param name="subnetMask">The subnet mask.</param>
    /// <returns>The host address.</returns>
    public static IPAddress GetHostAddress(this IPAddress ipAddress, IPAddress subnetMask)
    {
        byte[] ipAddressBytes = ipAddress.GetAddressBytes();
        byte[] subnetMaskBytes = subnetMask.GetAddressBytes();

        byte[] hostAddressBytes = new byte[ipAddressBytes.Length];
        for (int i = 0; i < ipAddressBytes.Length; i++)
        {
            hostAddressBytes[i] = (byte)(ipAddressBytes[i] & ~subnetMaskBytes[i]);
        }

        return new IPAddress(hostAddressBytes);
    }


}
