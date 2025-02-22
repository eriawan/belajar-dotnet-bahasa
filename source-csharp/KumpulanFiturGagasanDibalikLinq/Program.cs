using KumpulanFiturGagasanDibalikLinq.DataType;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace KumpulanFiturGagasanDibalikLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Process[] processes = Process.GetProcesses();
            //for (int i = 0; i < processes.Length; i++)
            //{
            //    Console.WriteLine($"Process name = {processes[i].ProcessName}, workingset = {processes[i].WorkingSet64}");
            //}
            var largeProcesses = new List<Process>();
            for (int i = 0; i < processes.Length; i++)
            {
                if (processes[i].WorkingSet64 >= 1_000_000_000)
                {
                    largeProcesses.Add(processes[i]);
                }
            }
            //for (int i = 0; i < largeProcesses.Count; i++)
            //{
            //    Console.WriteLine($"Process name = {largeProcesses[i].ProcessName}, workingset = {largeProcesses[i].WorkingSet64}");
            //}
            List<int> listInteger = new int[] { 1, 2, 3 }.ToList();
            var linqresult = (from proc in processes
                              where proc.WorkingSet64 >= 1_000_000_000
                              select new { ProcessName = proc.ProcessName, WorkingSet64 = proc.WorkingSet64 });
            var largeProcessesCustomized = linqresult.ToList();
            foreach (var item in largeProcessesCustomized)
            {
                Console.WriteLine($"Name = {item.ProcessName}, workingset = {item.WorkingSet64}");
            }

            // Contoh iterator yield return
            // Iterate nama-nama hari dalam sebulan (memakai yield return)
            //var namaharidalamSebulan = ContohIteratorNamaHari.GetEnumNamaHari(30);
            //int counter = 0;
            //foreach (var valuenamaHari in namaharidalamSebulan)
            //{
            //    Console.WriteLine($"Hari ke: {counter} Nama hari = {valuenamaHari}");
            //    counter++;
            //}

            List<Mahasiswa> listMhs = new();
            InitializeListMhs(listMhs);

            //var mhsLahirTahun75 = (from mhs in listMhs
            //                       where (mhs.TglLahir != null) && (mhs.TglLahir.Value.Year == 1975)
            //                       select new
            //                       {
            //                           NamaDepan = mhs.NamaDepan,
            //                           NamaBelakang = mhs.NamaBelakang,
            //                           TglLahir = mhs.TglLahir!
            //                       });
            //var listMhs1975 = mhsLahirTahun75.ToList();
            //foreach (var item in listMhs1975)
            //{
            //    Console.WriteLine($"Nama : {item.NamaDepan + " " + item.NamaBelakang}, Tgl lahir = {item.TglLahir!.Value.ToString()}");
            //}

            // OrderBy
            //var mhsUrutNamaDepan = (from mhs in listMhs
            //                        orderby mhs.NamaDepan
            //                        select mhs);
            var mhsUrutNamaDepan = listMhs.OrderByDescending((mhs) => (mhs.NamaDepan));
            var listMhsUrutNamaDepan = mhsUrutNamaDepan.ToList();
            listMhsUrutNamaDepan.ForEach((mhs) =>
            {
                Console.WriteLine($"Nama depan = {mhs.NamaDepan}, Nama belakang = {mhs.NamaBelakang}, Kota = {mhs.Kota}");
            });
            //var mhsUrutNamaDepanBelakang = (from mhs in listMhs
            //                        orderby mhs.NamaDepan,mhs.NamaBelakang
            //                        select mhs);
            //var mhsUrutNamaDepanBelakang = listMhs.OrderBy((mhs) => (mhs.NamaDepan))
            //    .ThenBy((mhs) => (mhs.NamaBelakang));
            //var listMhsUrutNamaDepanBelakang = mhsUrutNamaDepanBelakang.ToList();
            //var mhsUrutDescemdingNamaDepanBelakang = listMhs.OrderByDescending((mhs) => (mhs.NamaDepan))
            //    .ThenByDescending((mhs) => (mhs.NamaBelakang));
            // Group By
            //var mhsGroupByKotaPseudo = from mhs in listMhs
            //                           group mhs by mhs.Kota
            var mhsGroupByKota = listMhs.GroupBy((mhs) => mhs.Kota);
            foreach (var itemGroup in mhsGroupByKota)
            {
                Console.WriteLine($"Kota = {itemGroup.Key} ");
                foreach (var itemData in itemGroup)
                {
                    Console.WriteLine($"\tNama depan = {itemData.NamaDepan}, Nama belakang = {itemData.NamaBelakang}");
                }
            }

        }

        private static void InitializeListMhs(List<Mahasiswa> listMhs)
        {
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Eriawan",
                NamaBelakang = "Kusuma",
                Kota = KonstantaNamaKota.JAKARTA,
                TglLahir = new DateTime(1975, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Budi",
                NamaBelakang = "Susilo",
                Kota = KonstantaNamaKota.SURABAYA,
                TglLahir = new DateTime(1975, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Ani",
                NamaBelakang = "Wijaya",
                Kota = KonstantaNamaKota.SEMARANG,
                TglLahir = new DateTime(1978, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Joko",
                NamaBelakang = "Kusuma",
                Kota = KonstantaNamaKota.YOGYAKARTA,
                TglLahir = new DateTime(1979, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Kusno",
                NamaBelakang = "Adrianto",
                Kota = KonstantaNamaKota.YOGYAKARTA,
                TglLahir = new DateTime(1978, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Heru",
                NamaBelakang = "Budianto",
                Kota = KonstantaNamaKota.YOGYAKARTA,
                TglLahir = new DateTime(1978, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Anita",
                NamaBelakang = "Hadi",
                Kota = KonstantaNamaKota.SURABAYA,
                TglLahir = new DateTime(1977, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Christian",
                NamaBelakang = "Nugraha",
                Kota = KonstantaNamaKota.JAKARTA,
                TglLahir = new DateTime(1977, 1, 1)
            });
        }
    }
}
