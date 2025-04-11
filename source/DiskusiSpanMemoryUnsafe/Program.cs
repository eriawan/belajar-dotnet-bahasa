using System.Buffers;

namespace DiskusiSpanMemoryUnsafe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            //Span<int> numbers = stackalloc int[10];
            //for (var i = 0; i < 10; i++)
            //{
            //    numbers[i] = i;
            //}
            //var numbersInt = new Int32[] { 10, 1, 2, 15, 2, 2, 2, 2, 2 };
            ////ReadOnlySpan<int> numbersReadOnly = stackalloc int[10];
            //ReadOnlySpan<int> numbersReadOnly = numbersInt.AsSpan();
            //for (var i = 0; i < numbersReadOnly.Length; i++)
            //{
            //    Console.Write($"{numbersReadOnly[i]} ");
            //}

            // Contoh pemakaian Memory<T> sesuai doc resmi
            // link: https://learn.microsoft.com/en-us/dotnet/standard/memory-and-spans/memory-t-usage-guidelines
            //IMemoryOwner<char> owner = MemoryPool<char>.Shared.Rent();

            //Console.Write("Enter a number: ");
            //try
            //{
            //    string? s = Console.ReadLine();

            //    if (s is null)
            //        return;

            //    var value = Int32.Parse(s);

            //    var memory = owner.Memory;

            //    WriteInt32ToBuffer(value, memory);

            //    DisplayBufferToConsole(owner.Memory.Slice(0, value.ToString().Length));
            //}
            //catch (FormatException)
            //{
            //    Console.WriteLine("You did not enter a valid number.");
            //}
            //catch (OverflowException)
            //{
            //    Console.WriteLine($"You entered a number less than {Int32.MinValue:N0} or greater than {Int32.MaxValue:N0}.");
            //}
            //finally
            //{
            //    owner?.Dispose();
            //}

            unsafe
            {
                int length = 3;
                int* numbers = stackalloc int[length];
                for (var i = 0; i < length; i++)
                {
                    numbers[i] = i;
                } 
            }
        }

        static void WriteInt32ToBuffer(int value, Memory<char> buffer)
        {
            var strValue = value.ToString();

            var span = buffer.Span;
            for (int ctr = 0; ctr < strValue.Length; ctr++)
                span[ctr] = strValue[ctr];
        }

        static void DisplayBufferToConsole(Memory<char> buffer) =>
            Console.WriteLine($"Contents of the buffer: '{buffer}'");
    }
}
