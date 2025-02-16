using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleNetFramework48Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Kode di bawah ini tidak akan jalan di .NET Framework yang runtimenya versi 2.0
            // Di .NET Framework runtime v4.0 bisa
            IEnumerable<Bird> birdsEnumerable = new List<Chicken>();
        }
    }
}
