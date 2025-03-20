using DIskusiMateriValueTypeRefType.SampleStructValueType;

namespace DIskusiMateriValueTypeRefType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, kita bahas lebih detil valuetype dan reference type!");
            // Contoh pemakaian valuetype
            // Contoh 1: Int16 (keyword C#: int)
            // 
            int counterCetak = 20;
            ContohScopeValueType.CetakJamSystem(counterCetak);
            Console.WriteLine($"Counter cetak = {counterCetak}");
            int counterCetak2 = 20;
            Console.WriteLine($"counterCetak referenceEquals counterCetak2 = {Object.ReferenceEquals(counterCetak, counterCetak2)}");
            // Contoh pemakaian ref type dengan pemakaian string
            string string1 = "string1";
            string string2 = string1;
            Console.WriteLine($"string1 referenceEquals string2 = {Object.ReferenceEquals(string1, string2)}");
            Console.WriteLine(string2);
            string1 = "ini string1";
            Console.WriteLine(string2);
            Console.WriteLine($"string1 referenceEquals string2 = {Object.ReferenceEquals(string1, string2)}");
            // Contoh pemakaian ref type dijadikan passing parameter
            string nama = "Eriawan";
            ContohReferenceType.SalamHormat(nama);
            Console.WriteLine(nama);
            // Contoh pemakaian ref type dijadikan passing parameter yang ditandai ref (referential)
            ContohReferenceType.SalamHormatRef(ref nama);
            Console.WriteLine(nama);
            // Contoh pemakaian value type dijadikan passing parameter yang ditandai ref (referential)
            int JamHariIni = 0;
            SetJamHariIni(ref JamHariIni);
            Console.WriteLine($"Jam hari ini = jam {JamHariIni}");
        }

        private static void SetJamHariIni(ref int jam)
        {
            jam = DateTime.Now.Hour;
        }
    }
}
