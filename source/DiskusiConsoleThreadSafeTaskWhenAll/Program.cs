namespace DiskusiConsoleThreadSafeTaskWhenAll
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, Contoh pemakaian ImmutableList di dalamTask.WhenAll selalu thread-safe!");
            int exceptionOccurrence = 0;
            for (int i = 1; i <= 40; i++)
            {
                Console.WriteLine($"iteration number {i}");
                //await MiscelanousComputeProcessSimplified.TaskWhenAll_ProcessIterateFor();
                try
                {
                    await MiscelanousComputeProcessSimplified.TaskWhenAll_ProcessIterateFor_UsingImmutableList();
                }
                catch (Exception exc)
                {
                    exceptionOccurrence++;
                    Console.WriteLine($"Exception thrown! Exception type = {exc.GetType().FullName},{Environment.NewLine}Message = {exc.Message}");
                }
            }
            Console.WriteLine($"number of exceptions = {exceptionOccurrence}");

        }
    }
}
