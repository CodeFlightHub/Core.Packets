using System.Net;

namespace CodeFlightHub.CorePackets.QuickExtend;

public static partial class IPAddressExtensions
{
    /// <summary>
    /// Gets the subnet mask of the given IP address.
    /// </summary>
    /// <param name="ipAddress">The IP address.</param>
    /// <returns>The subnet mask.</returns>
    public static IPAddress GetSubnetMask(this IPAddress ipAddress)
    {
        if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        {
            byte[] bytes = ipAddress.GetAddressBytes();
            if (bytes.Length != 4)
                throw new ArgumentException("Invalid IPv4 address.");

            uint mask = (uint)BitConverter.ToInt32(bytes.Reverse().ToArray(), 0);
            int maskLength = BitConverter.GetBytes(mask).Count(b => b == 1);

            return new IPAddress(BitConverter.GetBytes(mask).Reverse().ToArray());
        }
        else
        {
            throw new ArgumentException("IPv6 addresses are not supported.");
        }
    }

    /// <summary>
    /// Gets the length of the subnet mask in CIDR notation.
    /// </summary>
    /// <param name="subnetMask">The subnet mask.</param>
    /// <returns>The length of the subnet mask in CIDR notation.</returns>
    public static int GetSubnetMaskLength(this IPAddress subnetMask)
    {
        byte[] maskBytes = subnetMask.GetAddressBytes();
        int maskLength = 0;

        foreach (byte b in maskBytes)
        {
            for (int i = 7; i >= 0; i--)
            {
                if ((b & (1 << i)) == 0)
                    return maskLength;

                maskLength++;
            }
        }

        return maskLength;
    }

    /// <summary>
    /// Checks if the given IP addresses are in the same subnet.
    /// </summary>
    /// <param name="ipAddress1">The first IP address.</param>
    /// <param name="ipAddress2">The second IP address.</param>
    /// <param name="subnetMask">The subnet mask.</param>
    /// <returns>True if the IP addresses are in the same subnet, otherwise false.</returns>
    public static bool IsInSameSubnet(this IPAddress ipAddress1, IPAddress ipAddress2, IPAddress subnetMask)
    {
        byte[] ipBytes1 = ipAddress1.GetAddressBytes();
        byte[] ipBytes2 = ipAddress2.GetAddressBytes();
        byte[] maskBytes = subnetMask.GetAddressBytes();

        if (ipBytes1.Length != maskBytes.Length || ipBytes2.Length != maskBytes.Length)
            throw new ArgumentException("IP address and subnet mask length mismatch.");

        for (int i = 0; i < ipBytes1.Length; i++)
        {
            if ((ipBytes1[i] & maskBytes[i]) != (ipBytes2[i] & maskBytes[i]))
                return false;
        }

        return true;
    }

    /// <summary>
    /// Checks if the specified IP address is within the specified subnet.
    /// </summary>
    /// <param name="address">The IP address to check.</param>
    /// <param name="subnet">The subnet in CIDR notation (e.g., "192.168.1.0/24").</param>
    /// <returns>True if the IP address is within the subnet; otherwise, false.</returns>
    /// <remarks>
    /// This method determines whether the specified IP address falls within the specified subnet range.
    /// It compares the given IP address with the subnet address using the subnet mask to determine the network portion of the address.
    /// If the network portions match and the remaining bits (if any) match the subnet mask, the IP address is considered to be within the subnet.
    /// </remarks>
    public static bool IsInSubnet(this IPAddress address, string subnet)
    {
        var subnetParts = subnet.Split('/');
        var subnetAddress = IPAddress.Parse(subnetParts[0]);
        var subnetMask = subnetParts.Length > 1 ? int.Parse(subnetParts[1]) : 32;
        var addressBytes = address.GetAddressBytes();
        var subnetBytes = subnetAddress.GetAddressBytes();

        if (addressBytes.Length != subnetBytes.Length)
            return false;

        var mask = subnetMask / 8;
        var remainder = subnetMask % 8;

        for (int i = 0; i < mask; i++)
        {
            if (addressBytes[i] != subnetBytes[i])
                return false;
        }

        if (remainder == 0)
            return true;

        byte finalByte = (byte)(subnetBytes[mask] << (8 - remainder));
        return (addressBytes[mask] & finalByte) == finalByte;
    }

    /// <summary>
    /// Splits the IP address with a given subnet mask length.
    /// </summary>
    /// <param name="ipAddress">The IP address to split.</param>
    /// <param name="subnetMaskLength">The length of the subnet mask.</param>
    /// <returns>A tuple containing the subnet address and host address.</returns>
    public static (IPAddress, IPAddress) SplitSubnet(this IPAddress ipAddress, int subnetMaskLength)
    {
        if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
        {
            byte[] ipBytes = ipAddress.GetAddressBytes();
            byte[] maskBytes = new byte[ipBytes.Length];

            for (int i = 0; i < ipBytes.Length; i++)
            {
                if (subnetMaskLength >= 8)
                {
                    maskBytes[i] = 0xFF;
                    subnetMaskLength -= 8;
                }
                else if (subnetMaskLength > 0)
                {
                    maskBytes[i] = (byte)(0xFF << (8 - subnetMaskLength));
                    subnetMaskLength = 0;
                }
                else
                {
                    maskBytes[i] = 0x00;
                }
            }

            IPAddress subnetAddress = new IPAddress(ipBytes.Zip(maskBytes, (b1, b2) => (byte)(b1 & b2)).ToArray());
            IPAddress hostAddress = new IPAddress(ipBytes.Zip(maskBytes, (b1, b2) => (byte)(b1 & ~b2)).ToArray());

            return (subnetAddress, hostAddress);
        }
        throw new ArgumentException("IPv4 address expected.");
    }
}
