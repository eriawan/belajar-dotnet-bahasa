using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIskusiMateriValueTypeRefType.SampleStructValueType
{
    public class ContohReferenceType
    {
        public static void SalamHormat(string nama)
        {
            nama = "Hallo " + nama;
        }

        public static void SalamHormatRef(ref string nama)
        {
            nama = "Hallo " + nama;
        }
    }
}
