using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskusiSpanMemoryUnsafe
{
    internal class SamplesArraySegment
    {

        public static async Task ArraySegmentSampleInAsync()
        {
            const int segmentSize = 10;
            List<Task> tasks = new List<Task>();

            // Create array.
            int[] arr = new int[50];
            for (int ctr = 0; ctr <= arr.GetUpperBound(0); ctr++)
                arr[ctr] = ctr + 1;

            // Handle array in segments of 10.
            for (int ctr = 1; ctr <= Math.Ceiling(((double)arr.Length) / segmentSize); ctr++)
            {
                int multiplier = ctr;
                int elements = (multiplier - 1) * 10 + segmentSize > arr.Length ?
                                arr.Length - (multiplier - 1) * 10 : segmentSize;
                ArraySegment<int> segment = new ArraySegment<int>(arr, (ctr - 1) * 10, elements);
                tasks.Add(Task.Run(() => {
                    IList<int> list = (IList<int>)segment;
                    for (int index = 0; index < list.Count; index++)
                        list[index] = list[index] * multiplier;
                }));
            }
            try
            {
                await Task.WhenAll(tasks.ToArray());
                int elementsShown = 0;
                foreach (var value in arr)
                {
                    Console.Write("{0,3} ", value);
                    elementsShown++;
                    if (elementsShown % 18 == 0)
                        Console.WriteLine();
                }
                // cek apakah asyncnya adalah async operation atau tidak
                Console.WriteLine("Cek apakah setiap task itu execute asynchronously");
                int counter = 1;
                foreach (var item in tasks)
                {
                    bool IsRunningAsync = ((IAsyncResult)item).CompletedSynchronously;
                    Console.WriteLine($"task {counter} is completed sync? = {IsRunningAsync}");
                    counter++;
                }
            }
            catch (AggregateException e)
            {
                Console.WriteLine("Errors occurred when working with the array:");
                foreach (var inner in e.InnerExceptions)
                    Console.WriteLine("{0}: {1}", inner.GetType().Name, inner.Message);
            }
        }

        public static void DisplayArraySegmentSamples()
        {

            // Create and initialize a new string array.
            String[] myArr = { "The", "quick", "brown", "fox", "jumps", "over", "the", "lazy", "dog" };

            // Display the initial contents of the array.
            Console.WriteLine("The original array initially contains:");
            PrintIndexAndValues(myArr);

            // Define an array segment that contains the entire array.
            ArraySegment<string> myArrSegAll = new ArraySegment<string>(myArr);

            // Display the contents of the ArraySegment.
            Console.WriteLine("The first array segment (with all the array's elements) contains:");
            PrintIndexAndValues(myArrSegAll);

            // Define an array segment that contains the middle five values of the array.
            ArraySegment<string> myArrSegMid = new ArraySegment<string>(myArr, 2, 5);

            // Display the contents of the ArraySegment.
            Console.WriteLine("The second array segment (with the middle five elements) contains:");
            PrintIndexAndValues(myArrSegMid);

            // Modify the fourth element of the first array segment myArrSegAll.
            myArrSegAll.Array[3] = "LION";

            // Display the contents of the second array segment myArrSegMid.
            // Note that the value of its second element also changed.
            Console.WriteLine("After the first array segment is modified, the second array segment now contains:");
            PrintIndexAndValues(myArrSegMid);
        }

        public static void PrintIndexAndValues(ArraySegment<string> arrSeg)
        {
            for (int i = arrSeg.Offset; i < (arrSeg.Offset + arrSeg.Count); i++)
            {
                Console.WriteLine("   [{0}] : {1}", i, arrSeg.Array[i]);
            }
            Console.WriteLine();
        }

        public static void PrintIndexAndValues(String[] myArr)
        {
            for (int i = 0; i < myArr.Length; i++)
            {
                Console.WriteLine("   [{0}] : {1}", i, myArr[i]);
            }
            Console.WriteLine();
        }
    }
}
