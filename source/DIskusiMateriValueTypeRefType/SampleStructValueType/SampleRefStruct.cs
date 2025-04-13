using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIskusiMateriValueTypeRefType.SampleStructValueType
{
    public ref struct SampleRefStruct
    {
        public ReadOnlySpan<char> ContohReadOnlySpanProperty { get; set; }

        public Span<char> ContohSpanProperty { get; set; }
    }
}
