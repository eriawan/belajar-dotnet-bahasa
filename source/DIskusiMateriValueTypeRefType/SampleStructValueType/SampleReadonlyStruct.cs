using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIskusiMateriValueTypeRefType.SampleStructValueType
{
    public readonly struct SampleReadonlyStruct
    {
        public int Angka1 { get; } = 0;

        public SampleReadonlyStruct()
        {
            
        }

        public SampleReadonlyStruct(int angka1)
        {
            Angka1 = angka1;
        }
    }
}
