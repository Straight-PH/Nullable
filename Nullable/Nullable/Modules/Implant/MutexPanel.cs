using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nullable.Modules.Implant
{
    internal sealed class MutexPanel
    {
        public static void MutexCheck()
        {
            bool createdNew = false;
            Mutex currentApp = new Mutex(false, Config.Mutex, out createdNew);
            if (!createdNew)
                Environment.Exit(1);
        }
    }
}
