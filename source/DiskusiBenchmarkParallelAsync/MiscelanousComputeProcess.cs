using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskusiBenchmarkParallelAsync
{
    internal class MiscelanousComputeProcess
    {
        internal static List<Double> ProcessIterateFor(int iteration)
        {
            List<Double> result = new List<Double>();
            Random random = new Random(255);
            for (int i = 0; i < iteration; i++)
            {
                double anycalc = Math.Pow(2.1, random.NextDouble());
                result.Add(anycalc);
                //Debug.WriteLine(anycalc);
                //Console.WriteLine(anycalc);
                Thread.Sleep(20);
            }
            return result;
        }
    }
}
