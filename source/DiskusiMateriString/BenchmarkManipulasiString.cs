using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiskusiMateriString
{
    [MemoryDiagnoser(true)]
    public class BenchmarkManipulasiString
    {
        //[Params(200, 800, 1_500)] <-- This is the original Params attribute.
        [Params(200, 700, 1_200)]
        public int JumlahLoop;

        private const string sampleStringWithNumeric = "Eriawan1975";

        [Benchmark]
        public void Substring_Biasa()
        {
            for (int i = 0; i < JumlahLoop; i++)
            {
                string anystring = "Halo Eriawan".Substring(5); 
            }
        }

        [Benchmark]
        public void Substring_ReadOnlySpan_AsSpan_StringConstructor()
        {
            for (int i = 0; i < JumlahLoop; i++)
            {
                string anystring = new string("Halo Eriawan".AsSpan(5));
            }
        }

        [Benchmark]
        public void Substring_ReadOnlySpan_AsSpan_ToString()
        {
            for (int i = 0; i < JumlahLoop; i++)
            {
                string anystring = "Halo Eriawan".AsSpan(5).ToString();
            }
        }

        [Benchmark]
        public void Substring_ReadOnlySpan_AsSpan_TanpaToString()
        {
            for (int i = 0; i < JumlahLoop; i++)
            {
                _ = "Halo Eriawan".AsSpan(5);
            }
        }

        [Benchmark]
        public void IntParse_Subtring()
        {
            for (int i = 0; i < JumlahLoop; i++)
            {
                int parsed = int.Parse(sampleStringWithNumeric.Substring(7));
            }
        }

        [Benchmark]
        public void IntParse_AsSpan()
        {
            for (int i = 0; i < JumlahLoop; i++)
            {
                int parsed = int.Parse(sampleStringWithNumeric.AsSpan(7));
            }
        }
    }
}
