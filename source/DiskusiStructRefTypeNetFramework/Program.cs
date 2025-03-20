using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskusiStructRefTypeNetFramework
{
    public class Program
    {
        static void Main(string[] args)
        {
            // Contoh pemakaian valuetype
            // Contoh 1: Int16 (keyword C#: int)
            // 
            int counterCetak = 20;
            Console.WriteLine($"Counter cetak = {counterCetak}");
            int counterCetak2 = 20;
            bool referenceEqualsInt32 = object.ReferenceEquals(counterCetak, counterCetak2);
        }
    }
}
