using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nullable.Modules.Manager
{
    internal sealed class Clipboard_Manager
    {
        public static string GetString()
        {
            return Clipboard.GetText();
        }
        public static Image GetImage()
        {
            return Clipboard.GetImage();
        }
        public static System.IO.Stream GetAudio()
        {
            return Clipboard.GetAudioStream();
        }
        public static void Clear()
        {
            Clipboard.Clear();
        }

        public static void SetText(string Text)
        {
            Clipboard.SetText(Text);
        }
        public static void SetImage(Image img)
        {            
            Clipboard.SetImage(img);
        }
        public static void SetAudio(byte[] Data)
        {
            Clipboard.SetAudio(Data);
        }
    }
}
