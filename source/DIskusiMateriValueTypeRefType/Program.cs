﻿using DIskusiMateriValueTypeRefType.SampleReferenceType;
using DIskusiMateriValueTypeRefType.SampleStructValueType;

namespace DIskusiMateriValueTypeRefType
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, kita bahas lebih detil valuetype dan reference type!");
            // Contoh pemakaian valuetype
            // Contoh 1: Int32 (keyword C#: int)
            int counterCetak = 20;
            //ContohScopeValueType.CetakJamSystem(counterCetak);
            //Console.WriteLine($"Counter cetak = {counterCetak}");
            //int counterCetak2 = 20;
            //Console.WriteLine($"counterCetak referenceEquals counterCetak2 = {Object.ReferenceEquals(counterCetak, counterCetak2)}");
            // Contoh pemakaian ref type dengan pemakaian string
            string string1 = "string1";
            string string2 = string1;
            Console.WriteLine($"string1 referenceEquals string2 = {Object.ReferenceEquals(string1, string2)}");
            Console.WriteLine(string2);
            string1 = "ini string1";
            Console.WriteLine(string2);
            Console.WriteLine($"string1 referenceEquals string2 = {Object.ReferenceEquals(string1, string2)}");

            // Jika value type dan reference type ini dijadikan parameter dalam method, 
            // reference type by default akan selalu by ref, 
            // sedangkan value type (struct) yang dijadikan parameter selalu by value.
            // Contoh pemakaian ref type dijadikan passing parameter
            string nama = "Eriawan";
            ContohReferenceType.SalamHormat(nama);
            Console.WriteLine(nama);
            // Contoh pemakaian ref type dijadikan passing parameter yang ditandai ref (referential)
            ContohReferenceType.SalamHormatRef(ref nama);
            Console.WriteLine(nama);
            // contoh pemakaian ref type dijadikan passing parameter selain string
            Mahasiswa mhs = new Mahasiswa
            {
                NamaDepan = "Eriawan",
                NamaBelakang = "Kusuma",
                KotaId = 1,
                TglLahir = new DateTime(1980, 1, 1)
            };
            // Coba set property namadepan
            Console.WriteLine($"Nama mahasiswa = {mhs.NamaDepan} {mhs.NamaBelakang}");
            SetJulukan(mhs);
            Console.WriteLine($"Nama mahasiswa = {mhs.NamaDepan} {mhs.NamaBelakang}");
            // Coba set property KotaId
            Console.WriteLine($"KotaId mahasiswa = {mhs.KotaId}");
            SetKotaId(mhs, 10);
            Console.WriteLine($"KotaId mahasiswa = {mhs.KotaId}");

            // Contoh pemakaian parameter value type
            StructMahasiswa structmhs = new StructMahasiswa
            {
                NamaDepan = "Eriawan",
                NamaBelakang = "Kusuma",
                KotaId = 1,
                TglLahir = new DateTime(1980, 1, 1)
            };
            Console.WriteLine($"Nama mahasiswa = {structmhs.NamaDepan} {structmhs.NamaBelakang}");
            SetJulukanStructMhs(structmhs);
            Console.WriteLine($"Nama mahasiswa = {structmhs.NamaDepan} {structmhs.NamaBelakang}");

            // Contoh pemakaian value type dijadikan passing parameter yang ditandai ref (referential)
            int JamHariIni = 0;
            SetJamHariIni(ref JamHariIni);
            Console.WriteLine($"Jam hari ini = jam {JamHariIni}");

        }

        private static void SetJulukan(Mahasiswa mhs)
        {
            mhs.NamaDepan = "Mr./Mrs." + mhs.NamaDepan;
        }

        private static void SetJulukanStructMhs(StructMahasiswa mhs)
        {
            mhs.NamaDepan = "Mr./Mrs." + mhs.NamaDepan;
        }

        private static void SetKotaId(Mahasiswa mhs, int kotaId)
        {
            mhs.KotaId = kotaId;
        }

        private static void SetJamHariIni(ref int jam)
        {
            jam = DateTime.Now.Hour;
        }
    }
}
