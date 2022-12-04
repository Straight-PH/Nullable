using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable.Modules.Manager
{
    internal sealed class Command
    {
        public static string Run(string cmd, bool wait)
        {
            string output = "";
            using (var process = new Process())
            {
                process.StartInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    FileName = "cmd.exe",
                    Arguments = cmd,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true
                };
                process.Start();
                output = process.StandardOutput.ReadToEnd();
                if (wait) process.WaitForExit();
            }
            return output;
        }
    }
}
