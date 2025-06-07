using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskusiTestArrayExceptionDiTaskWhenAll
{
    public class MiscelanousComputeProcessSimplified
    {
        public static List<Double> ProcessIterateFor(int iteration)
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

        public static async Task TaskWhenAll_ProcessIterateFor()
        {
            List<Task> tasklist = new List<Task>();
            List<Double> randomResult = new List<Double>();
            for (int i = 1; i <= 50; i++)
            {
                tasklist.Add(Task.Run(() =>
                {
                    var iterationResult = ProcessIterateFor(60);
                    iterationResult.ForEach((resultItem) => randomResult.Add(resultItem));
                }));
            }
            await Task.WhenAll(tasklist);
        }

        public static async Task TaskWhenAll_ProcessIterateFor_WithLock()
        {
            object lockObject = new object();
            List<Task> tasklist = new List<Task>();
            List<Double> randomResult = new List<Double>();
            for (int i = 1; i <= 50; i++)
            {
                tasklist.Add(Task.Run(() =>
                {
                    lock (lockObject)
                    {
                        var iterationResult = ProcessIterateFor(60);
                        iterationResult.ForEach((resultItem) => randomResult.Add(resultItem)); 
                    }
                }));
            }
            await Task.WhenAll(tasklist);
        }
    }
}
