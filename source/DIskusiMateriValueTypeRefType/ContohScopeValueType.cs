using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIskusiMateriValueTypeRefType
{
    class ContohScopeValueType
    {
        internal static void CetakJamSystem(int counterCetak)
        {
            DateTime dtBefore = DateTime.Now;
            for (int i = 0; i < counterCetak; i++)
            {
                DateTime dtNow = DateTime.Now;
                Console.WriteLine($"Time = {dtNow.ToString("HH:mm:ss.fff")}");
                Thread.Sleep(100);
            }
            counterCetak = (DateTime.Now - dtBefore).Microseconds;
        }
    }
}
