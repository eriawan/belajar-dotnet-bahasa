using BenchmarkDotNet.Running;

namespace DiskusiMateriString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Halo, teman-teman!");
            //string string01 = "string1";
            //string string02 = "string2";
            //// string concat sederhana
            //string string03 = string01 + string02;
            //// string concat dengan string interpolation
            //string string04 = $"{string01}{string02}";
            //// string concat antara string dengan non string (contoh: Int16)
            //short contohInt16 = (short)-12345;
            //// string concat antara string dengan non string (contoh: Int16) 
            //// memakai string interpolation
            //string string05 = $"{string04}{contohInt16}";
            //// string concat antara string dengan non string (contoh: Int16) 
            //// tidak memakai string interpolation
            //string string06 = string04 + contohInt16;
            //// coba cetak hasilnya dari di atas
            //Console.WriteLine($"string05 ={string05}");
            //Console.WriteLine($"string06 ={string06}");
            //// contoh substring
            //string string07 = "nama: Eriawan Kusumawardhono".Substring(6);
            //Console.WriteLine($"string07 = {string07}");
            string anystring = "Eriawan 😊👍ドページを切り替える方法";
            Console.WriteLine(anystring);
            //BenchmarkRunner.Run<BenchmarkManipulasiString>();
        }
    }
}
