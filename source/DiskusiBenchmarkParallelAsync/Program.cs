using BenchmarkDotNet.Running;

namespace DiskusiBenchmarkParallelAsync
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Parallel and Async World!");
            BenchmarkRunner.Run<BenchmarkParallelAsync>();
        }
    }
}
