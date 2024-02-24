namespace Core.QuickExtend.Extensions;

public static partial class IPAddressExtensions {

        public static bool IsIPv4Address(this IPAddress ipAddress)
        {
            return ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork;
        }

        public static bool IsIPv4Address(this string input)
        {
            IPAddress ipAddress;
            return IPAddress.TryParse(input, out ipAddress) && ipAddress.IsIPv4Address();
        }

        public static bool IsIPv6Address(this IPAddress ipAddress)
        {
            return ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6;
        }

        public static bool IsIPv6Address(this string input)
        {
            IPAddress ipAddress;
            return IPAddress.TryParse(input, out ipAddress) && ipAddress.IsIPv6Address();
        }


 }
