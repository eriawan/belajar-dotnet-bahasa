namespace DiskusiTestArrayExceptionDiTaskWhenAll
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Test Array Exception in Task.WhenAll!");
            int exceptionOccurrence = 0;
            for (int i = 1; i <= 40; i++)
            {
                Console.WriteLine($"iteration number {i}");
                //await MiscelanousComputeProcessSimplified.TaskWhenAll_ProcessIterateFor();
                try
                {
                    await MiscelanousComputeProcessSimplified.TaskWhenAll_ProcessIterateFor_WithLock();
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
