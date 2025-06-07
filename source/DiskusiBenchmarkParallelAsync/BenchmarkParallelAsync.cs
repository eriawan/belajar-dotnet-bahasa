using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskusiBenchmarkParallelAsync
{
    [MemoryDiagnoser(true)]
    public class BenchmarkParallelAsync
    {
        [Params(50, 100, 500, 1000)]
        //[Params(50, 100 )]
        public int NumberOfLoops;

        [Benchmark]
        public async Task ParallelForAsync()
        {
            await Parallel.ForAsync(1, NumberOfLoops, async (index, cancelToken) =>
            {
                await Task.Run(() =>
                {
                    _ = MiscelanousComputeProcess.ProcessIterateFor(60);
                }, cancelToken);
            });
        }

        [Benchmark]
        public async Task TaskWhenAll()
        {
            List<Task> tasklist = new List<Task>();
            for (int i = 1; i <= NumberOfLoops; i++)
            {
                tasklist.Add(Task.Run(() =>
                {
                    _ = MiscelanousComputeProcess.ProcessIterateFor(60);
                }));
            }
            await Task.WhenAll(tasklist);
        }

        [Benchmark]
        public void ParallelFor()
        {
            Parallel.For(1, NumberOfLoops, (iteration) =>
            {
                _ = MiscelanousComputeProcess.ProcessIterateFor(60);
            });
        }
    }
}
