using System.Net;
using System.Net.Sockets;

namespace CodeFlightHub.CorePackets.QuickExtend;

/// <summary>
/// Extension methods related to IP addresses.
/// </summary>
public static partial class IPAddressExtensions
{
    /// <summary>
    /// Performs a reverse DNS lookup for the given IP address and returns the corresponding domain name, or null if not available.
    /// </summary>
    /// <param name="ipAddress">The IP address to perform the reverse DNS lookup.</param>
    /// <returns>The domain name corresponding to the IP address, or null if not available.</returns>
    public static string ReverseDNSLookup(this IPAddress ipAddress)
    {
        try
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(ipAddress);
            return hostEntry.HostName;
        }
        catch (SocketException)
        {
            return null; // DNS lookup failed
        }
    }

    /// <summary>
    /// Reverses the IP address (e.g., "192.168.1.1" => "1.1.168.192").
    /// </summary>
    /// <param name="ipAddress">The IP address to reverse.</param>
    /// <returns>The reversed IP address string.</returns>
    public static string ReverseIPAddress(this IPAddress ipAddress)
    {
        if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        {
            byte[] bytes = ipAddress.GetAddressBytes();
            Array.Reverse(bytes);
            return new IPAddress(bytes).ToString();
        }
        throw new ArgumentException("IPv4 address expected.");
    }

    /// <summary>
    /// Masks the IP address based on the specified prefix length.
    /// </summary>
    /// <param name="ipAddress">The IP address to mask.</param>
    /// <param name="prefixLength">The prefix length for masking.</param>
    /// <returns>The masked IP address.</returns>
    /// <exception cref="ArgumentException">Thrown when an IPv4 address is expected.</exception>
    public static IPAddress ApplyPrefixMask(this IPAddress ipAddress, int prefixLength)
    {
        if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        {
            byte[] ipBytes = ipAddress.GetAddressBytes();
            byte[] maskBytes = new byte[ipBytes.Length];

            for (int i = 0; i < ipBytes.Length; i++)
            {
                if (prefixLength >= 8)
                {
                    maskBytes[i] = 0xFF;
                    prefixLength -= 8;
                }
                else if (prefixLength > 0)
                {
                    maskBytes[i] = (byte)(0xFF << (8 - prefixLength));
                    prefixLength = 0;
                }
                else
                {
                    maskBytes[i] = 0x00;
                }
            }

            return new IPAddress(ipBytes.Zip(maskBytes, (b1, b2) => (byte)(b1 & b2)).ToArray());
        }
        throw new ArgumentException("IPv4 address expected.");
    }
}
