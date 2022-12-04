using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace Nullable.Modules.Manager
{
    internal sealed class File_Manager
    {
        public static void CreateArchive(string directory, string newDir)
        {
            ZipFile.CreateFromDirectory(directory, newDir);
        }

    }
}
