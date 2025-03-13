using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskusiMateriString
{
    [MemoryDiagnoser]
    public class BenchmarkManipulasiString
    {
        [Params(100, 1_000, 4_000)]
        public int JumlahLoop;

        [Benchmark]
        public void SubstringBiasa()
        {
            for (int i = 0; i < JumlahLoop; i++)
            {
                string anystring = "Halo Eriawan".Substring(5); 
            }
        }

        [Benchmark]
        public void SubstringPakaiSpan()
        {
            for (int i = 0; i < JumlahLoop; i++)
            {
                string anystring = new string("Halo Eriawan".AsSpan(5)); 
            }
        }
    }
}
