using BenchmarkDotNet.Running;

namespace DiskusiContohSkenarioValueTask
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //Console.WriteLine("Sample ValueTask<T>");
            //SimpleWebContentReader reader = new SimpleWebContentReader();
            //// call fisrt time...
            //string webKompasContent = await reader.GetWebContentUsingTask();
            ////Console.WriteLine(webKompasContent.Substring(200));
            //Thread.Sleep(200);
            //// call again
            //webKompasContent = await reader.GetWebContentUsingTask();
            //Console.WriteLine("second run");

            //Benchmark Task and ValueTask
            BenchmarkRunner.Run<SimpleWebContentReader>();
        }
    }
}
