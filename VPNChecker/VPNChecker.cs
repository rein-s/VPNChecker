using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace VPNChecker
{
    public class VPNChecker
    {
        public static bool IsBehindVPN()
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();

            foreach (NetworkInterface adapter in interfaces)
            {
                if (adapter.OperationalStatus == OperationalStatus.Up)
                {
                    if (IsVPNInterface(adapter.Description) || IsVPNInterface(adapter.Name))
                    {
                        // This adapter is associated with a VPN
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsVPNInterface(string interfaceName)
        {
            // List recognizable VPN interface names or keywords here
            string[] vpnKeywords = { "vpn", "openvpn", "pptp", "l2tp", "wireguard", "proton" };

            return vpnKeywords.Any(keyword => interfaceName.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0);
        }
    }
}
