using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiskusiIntroParallelConsole
{
    internal class MiscelanousComputeProcess
    {
        internal static void ProcessIterateFor(int iteration)
        {
            Random random = new Random(255);
            for (int i = 0; i < iteration; i++)
            {
                double anycalc = Math.Pow(2.1,random.NextDouble());
                Debug.WriteLine(anycalc);
                Console.WriteLine(anycalc);
                Thread.Sleep(10);
            }
        }
    }
}
