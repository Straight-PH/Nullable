using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Nullable.Modules.Manager
{
    internal sealed class String
    {
        public static string[] RandomString =
        {
            "QKZCRDAFLLI665HT8VZF4EBUZM",
            "P4LM0S7CA4HPR4E",
            "O5JJA401IQGCEBU",
            "YDV2PP8JEUUC11A",
            "YJWDRUW1G9M313T",
            "2VJ86TI81668DUM",
            "1Z8X1MK2A4T71AA",
            "7FCQ8ECL7JU341S",
            "Y6A09DNX5Y6A09DNX5"
        };

        public static int[] Randomnum =
        {
            2,
            6,
            8,
            0,
            4,
            50,
            62,
            3,
            9,
            5,
            12
        };

        public static string PasswordGen(string Key, int Length)
        {
            string Chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXY";
            string Elements = "!@#$%^&*";

            string intSalt = "DLFkjdi0X0ERO95JI";

            Random r = new Random();
            string Hashed = "";
            string Final = "";

            try
            {
                string CurrentTime = DateTime.Now.ToLongTimeString();
                string Lang = System.Globalization.CultureInfo.CurrentCulture.ToString();
                string Machine_Name = Environment.MachineName;
                string Rando_String = RandomString[r.Next(0, RandomString.Length)];

                char[] TimeArray = CurrentTime.ToCharArray();
                char[] LangArray = Lang.ToCharArray();
                char[] MachName = Machine_Name.ToCharArray();
                char[] RandString = Rando_String.ToCharArray();

                int Randoint = Randomnum[r.Next(0, Randomnum.Length)];

                if (Randoint > 10 & Randoint < 62)
                {
                    Array.Reverse(RandString);
                    Array.Reverse(TimeArray);
                    intSalt = intSalt + "nbme";
                }
                else if (Randoint == 62)
                {
                    Array.Reverse(MachName);
                    intSalt = intSalt + "4t=zX";
                }
                else if (Randoint < 10)
                {
                    intSalt = intSalt + "etef";
                }
                else
                {

                }
                string TIME = new string(TimeArray);
                string MACHINENAME = new string(MachName);
                string LANGUAGE = new string(LangArray);
                string RANDOMSTRING = new string(RandString);

                string PreMesh = TIME + RANDOMSTRING + LANGUAGE + MACHINENAME + intSalt;
                string Mesh = Key + PreMesh;

                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(Mesh));
                    var sb = new StringBuilder(hash.Length * 2);

                    foreach (byte b in hash)
                    {
                        // can be "x2" if you want lowercase
                        sb.Append(b.ToString("X2"));
                    }
                    Hashed = sb.ToString();
                }

                string base64 = Convert.ToBase64String(Encoding.UTF8.GetBytes(Hashed));
                char[] Base64 = base64.ToCharArray();
                Array.Reverse(Base64);
                string Reversed = new string(Base64);
                Reversed = Reversed.Substring(3);

                string Mixed = Elements + Chars + Reversed;
                char[] MixedArray = Mixed.ToCharArray();

                for (int x = 0; x <= Length; x++)
                {
                    Final = Final + MixedArray[r.Next(0, MixedArray.Length)];
                }

                if (Final.Length != Length)
                {
                    for (int x = Final.Length; x <= Length; x++)
                    {
                        Final = Final + MixedArray[r.Next(0, MixedArray.Length)];
                    }
                }

            }
            catch
            {
                Final = "Error";
            }
            return Final;
        }
        public static string GenerateRandomHash(int value, string Key)
        {
            string ReversedRandString = "";
            string ReversedMachString = "";

            int prevalue = value;

            Random r = new Random();

            string Final = "";

            if (value == 0)
            {
                value = 0;
            }

            try
            {
                value = value * (value + 3) / 2;

                string CurrentTime = DateTime.Now.ToLongTimeString();
                string Lang = System.Globalization.CultureInfo.CurrentCulture.ToString();
                string Machine_Name = Environment.MachineName;
                string Rando_String = Config.RandomString[r.Next(0, Config.RandomString.Length)];

                char[] TimeArray = CurrentTime.ToCharArray();
                char[] LangArray = Lang.ToCharArray();
                char[] MachName = Machine_Name.ToCharArray();
                char[] RandString = Rando_String.ToCharArray();

                if (value < 20)
                {
                    for (int x = 0; x < value; x++)
                    {
                        Array.Reverse(RandString);
                        ReversedRandString = new string(RandString);
                    }
                    for (int x = 0; x < value; x++)
                    {
                        Array.Reverse(MachName);
                        ReversedMachString = new string(MachName);
                    }
                }
                else
                {
                    value = prevalue;
                }

                Array.Reverse(LangArray);
                string ReversedLang = new string(LangArray);

                Array.Reverse(TimeArray);
                string ReversedTime = new string(TimeArray);

                string NotFinalMesh = ReversedTime + Key.Substring(Key.Length / 2) + ReversedMachString + ReversedLang + "0x" + ReversedRandString;
                int NotFinalMeshLen = NotFinalMesh.Length;

                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(NotFinalMesh));
                    var sb = new StringBuilder(hash.Length * 2);

                    foreach (byte b in hash)
                    {
                        // can be "x2" if you want lowercase
                        sb.Append(b.ToString("X2"));
                    }
                    Final = sb.ToString();
                }
            }

            catch
            {
                Final = "0305929295";
            }
            return Final;
        }

        public static string GenerateHash(string ToHash)
        {
            string Final = "";
            try
            {
                using (SHA1Managed sha1 = new SHA1Managed())
                {
                    var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(ToHash));
                    var sb = new StringBuilder(hash.Length * 2);

                    foreach (byte b in hash)
                    {
                        // can be "x2" if you want lowercase
                        sb.Append(b.ToString("X2"));
                    }
                    Final = sb.ToString();
                }

            }
            catch
            {
                Final = "Error";
            }

            return Final;
        }

        public static string Nue(string Key, int Length)
        {
            Random r = new Random();
            string Chars = "AbcdefghijklmnopqrstuvwyxyABICRHGNERGEHG1291394";
            char[] e = Chars.ToCharArray();
            Array.Reverse(e);
            string Rev = new string(e);

            string FinalChars = Rev.Substring(0, 9);
            char[] Append = FinalChars.ToCharArray();

            string Final = "";

            for (int x = 0; x <=Length; x++)
            {
                Final = Final + Append[r.Next(0, Append.Length)];
            }
            return Final;
        }
    }
}
