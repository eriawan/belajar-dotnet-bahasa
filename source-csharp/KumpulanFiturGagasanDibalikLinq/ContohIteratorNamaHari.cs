using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KumpulanFiturGagasanDibalikLinq
{
    public static class ContohIteratorNamaHari
    {
        static ContohIteratorNamaHari()
        {
        }

        public static IEnumerable<NamaHariSeminggu> GetEnumNamaHari(int numberOfDays)
        {
            List<NamaHariSeminggu> namahariList = new List<NamaHariSeminggu>(numberOfDays);
            int lengthNamaHariSeminggu = Enum.GetValues<NamaHariSeminggu>().Length;
            for (int i = 0; i < numberOfDays; i++)
            {
                yield return (NamaHariSeminggu)(i % lengthNamaHariSeminggu);
            }
        }
    }
}
