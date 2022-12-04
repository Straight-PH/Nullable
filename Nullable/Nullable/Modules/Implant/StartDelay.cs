using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nullable.Modules.Implant
{
    internal sealed class StartDelay
    {
        public static void Activate(int Decider)
        {
            try
            {
                int Min = 10;
                int Max = 1000;

                int SleepTimePre = (Min * Decider + (Max / 2) * Max - Min);

                if (SleepTimePre > 25000)
                {
                    SleepTimePre = SleepTimePre - 10000;
                }
                if (SleepTimePre > 25000)
                {
                    SleepTimePre = SleepTimePre - 10000;
                }
                if (SleepTimePre > 25000)
                {
                    SleepTimePre = Min * Max + Decider;
                }

                System.Threading.Thread.Sleep(SleepTimePre);
            }
            catch
            {
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
