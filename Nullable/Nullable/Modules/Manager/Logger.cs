using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable.Modules.Manager
{
    internal sealed class Logger
    {
        public static void Log(string message)
        {
            File.AppendAllText(Config.LogPath + "\\Log.txt", "\n" + DateTime.Now.ToLongTimeString() + ": " + message);         
        }
    }
}
