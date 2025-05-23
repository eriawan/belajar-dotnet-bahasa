#if NETFRAMEWORK
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
#endif


using System.Diagnostics;

namespace DiskusiIntroParallelConsole
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            Console.WriteLine("Hello, parallel World!");

            // using parallel FOR
            //Parallel.For(1, 300, (iteration) =>
            //{
            //    MiscelanousComputeProcess.ProcessIterateFor(100);
            //    Console.WriteLine($"iteration = {iteration}");
            //});

            // using parallel FOR with max degree of parallelism specified
            //Parallel.For(1, 300, new ParallelOptions { MaxDegreeOfParallelism = 5 },
            //    (iteration) =>
            //    {
            //        MiscelanousComputeProcess.ProcessIterateFor(100);
            //        //Console.WriteLine($"iteration = {iteration}");
            //    });

            // using parallel FOR with max degree of parallelism specified and to use current TaskScheduler.
            //Parallel.For(1, 800,
            //    new ParallelOptions { MaxDegreeOfParallelism = 4, TaskScheduler = TaskScheduler.Current },
            //    (iteration) =>
            //    {
            //        MiscelanousComputeProcess.ProcessIterateFor(100);
            //        //Console.WriteLine($"iteration = {iteration}");
            //    });

            // using parallel FOREACH
            //var proclist = Process.GetProcesses();
            //Parallel.ForEach(proclist, (process) => Console.WriteLine(process.ProcessName));

            // Now we are trying to combine with async, while at the same time check the resulting actual execution.
            // Try using parallel FOR with max degree of parallelism specified, to execute async Action
            //Parallel.For(1, 300, new ParallelOptions { MaxDegreeOfParallelism = 5 },
            //    async (iteration) =>
            //    {
            //        await Task.Run(() => MiscelanousComputeProcess.ProcessIterateFor(100));
            //        Console.WriteLine($"iteration = {iteration}");
            //    });

            // Try to check for how many "SUCCESSFUL" parallel iterations are actually done.
            int cnt = 1;
            //Parallel.For(1, 200, new ParallelOptions { MaxDegreeOfParallelism = 5 },
            //    async (iteration) =>
            //    {
            //        cnt++;
            //        await Task.Run(() => MiscelanousComputeProcess.ProcessIterateFor(100));
            //        Console.WriteLine($"iteration = {cnt}");
            //    });
            Console.WriteLine($"Finished iterations = {cnt}");
            await Task.Delay(10);
#if NET8_0_OR_GREATER
            //Parallel.For(1, 300, new ParallelOptions { MaxDegreeOfParallelism = 5 },
            //    async (iteration) =>
            //    {
            //        cnt++;
            //        List<Task> tasks = new List<Task>();
            //        tasks.Add(Task.Run(() => MiscelanousComputeProcess.ProcessIterateFor(100)));
            //        await Task.WhenAll(tasks);
            //        Console.WriteLine($"iteration = {cnt}");
            //    });
            await Parallel.ForAsync(1, 150, new ParallelOptions { MaxDegreeOfParallelism = 5 },
                async (iteration, cancellationToken) =>
                {
                    cnt++;
                    await (Task.Run(() => MiscelanousComputeProcess.ProcessIterateFor(100), CancellationToken.None));
                    Debug.WriteLine($"iteration = {cnt}");
                    Console.WriteLine($"iteration = {cnt}");
                });
            Console.WriteLine($"total iteration ={cnt}");
#endif
            // Or, we could now create a list of 300 tasks and then call Task.WhenAll instead of using Parallel.ForAsync
            // Task.WhenAll static method is available since .NET Framework 4.5
            // See the official doc at: 
            // https://learn.microsoft.com/en-us/dotnet/api/system.threading.tasks.task.whenall?view=net-9.0
            //List<Task> tasklist = new List<Task>();
            //for (int i = 1; i <= 200; i++)
            //{
            //    tasklist.Add(Task.Run(() => MiscelanousComputeProcess.ProcessIterateFor(100)));
            //}
            //await Task.WhenAll(tasklist);

        }

    }
}
