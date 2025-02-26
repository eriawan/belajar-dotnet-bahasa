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
            //listMhsUrutNamaDepan.ForEach((mhs) =>
            //{
            //    Console.WriteLine($"Nama depan = {mhs.NamaDepan}, Nama belakang = {mhs.NamaBelakang}, Kota = {mhs.Kota}");
            //});
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
            //var mhsGroupByKota = listMhs.GroupBy((mhs) => mhs.Kota);
            //foreach (var itemGroup in mhsGroupByKota)
            //{
            //    Console.WriteLine($"Kota = {itemGroup.Key} ");
            //    foreach (var itemData in itemGroup)
            //    {
            //        Console.WriteLine($"\tNama depan = {itemData.NamaDepan}, Nama belakang = {itemData.NamaBelakang}");
            //    }
            //}
            // LINQ Join
            // Untuk demo join, kita membutuhkan 2 collection. Di mana 1 adalah master data, ke 2 adalah child data.
            // Initialize sample data master kota
            List<MasterKota> listMasterKota = InitializeMasterKota();
            listMasterKota.ForEach((mstkota) =>
            {
                Console.WriteLine($"KotaId = {mstkota.KotaId}, Kota=\"{mstkota.Kota}\"");
            });
            // Join di LINQ secara default (by default) adalah INNER JOIN
            var dataJoinMhsDenganMstKota = from mstKota in listMasterKota
                                           join mhs in listMhs on mstKota.KotaId equals mhs.KotaId
                                           select new { mhs.NamaDepan, mhs.NamaBelakang, mhs.KotaId, mstKota.Kota };
            var listDataJoinMhsDenganMstKota = dataJoinMhsDenganMstKota.ToList();
            listDataJoinMhsDenganMstKota.ForEach((mhsJoinKota) =>
            {
                Console.WriteLine($"Nama = \"{mhsJoinKota.NamaDepan + " " + mhsJoinKota.NamaBelakang}, kota = {mhsJoinKota.Kota}");
            });
            var dataJoinMhsDenganMstKota02 =
                listMasterKota.Join(listMhs, (mstKota) => mstKota.KotaId,
                    (mhs) => mhs.KotaId,
                    (mstKota, mhs) => new { mhs.NamaDepan, mhs.NamaBelakang, mhs.KotaId, mstKota.Kota });
            var listDataJoinMhsDenganMstKota02 = dataJoinMhsDenganMstKota02.ToList();
            listDataJoinMhsDenganMstKota02.ForEach((mhsJoinKota) =>
            {
                Console.WriteLine($"Nama = \"{mhsJoinKota.NamaDepan + " " + mhsJoinKota.NamaBelakang}, kota = {mhsJoinKota.Kota}");
            });
            // Contoh Join yang memakai variable untuk menampung hasil join untuk diproses/diolah lagi
            // Dalam bentuk extension method, akan memanggil method LINQ bukan Join lagi, tapi memakai method GroupJoin
            var dataGroupJoinMhsDenganMstKota = from mstKota in listMasterKota
                                                join mhs in listMhs on mstKota.KotaId equals mhs.KotaId into listgroupMhsJoinMstKota
                                                select new
                                                {
                                                    KumpulanMahasiswa = listgroupMhsJoinMstKota,
                                                    Kota = mstKota.Kota
                                                };
            //var listDataGroupJoinMhsDenganMstKota = dataGroupJoinMhsDenganMstKota.ToList();
            foreach (var dataGroupJoin in dataGroupJoinMhsDenganMstKota.ToList())
            {
                Console.WriteLine(dataGroupJoin.Kota);
                foreach (var itemMhs in dataGroupJoin.KumpulanMahasiswa)
                {
                    Console.WriteLine($"\t{itemMhs.NamaDepan} {itemMhs.NamaBelakang}");
                }
            }
            ;
            // Contoh GroupJoin yang memanggil SelectMany, karena memakai "from" lebih dari satu di dalam 
            // satu evaluasi pseudo expression
            //Console.WriteLine("GroupJoin dengan SelectMany");
            //var dataGroupJoinMhsDenganMstKotaSelectMany = from mstKota in listMasterKota
            //                                              join mhs in listMhs on mstKota.KotaId equals mhs.KotaId into listgroupMhsJoinMstKota
            //                                              from groupMhsJoinMstKota in listgroupMhsJoinMstKota
            //                                              select new
            //                                              {
            //                                                  KumpulanMahasiswa = listgroupMhsJoinMstKota,
            //                                                  Kota = mstKota.Kota
            //                                              };
            //dataGroupJoinMhsDenganMstKotaSelectMany.ToList().ForEach((dataGroupJoin) => {
            //    Console.WriteLine($"kota = {dataGroupJoin.Kota}");
            //    foreach (var itemdata in dataGroupJoin.KumpulanMahasiswa)
            //    {
            //        Console.WriteLine($"{itemdata.NamaDepan} {itemdata.NamaBelakang} Kota = {dataGroupJoin.Kota}");
            //    }
            //});
            //var dataGroupJoinMhsDenganMstKotaSelectMany02 = listMasterKota.GroupJoin(listMhs,
            //    (mstKota) => mstKota.KotaId,
            //    (mhs) => mhs.KotaId,
            //    (mstKota, listgroupMhsJoinMstKota) => new { mstKota, listgroupMhsJoinMstKota })
            //    .SelectMany((kumpulanKotaDanMahasiswanya) => kumpulanKotaDanMahasiswanya.listgroupMhsJoinMstKota,
            //    (kumpulanKotaMhs, groupMhsJoinMstKota) => new
            //    {
            //        kumpulanKotaMhs.mstKota.Kota,
            //        KumpulanMahasiswa = kumpulanKotaMhs.listgroupMhsJoinMstKota
            //    });
            // Contoh LEFT OUTER JOIN di LINQ. 
            // Untuk mensimulasikan "OUTER JOIN", kita memakai method LINQ DefaultIfEmpty
        }

        private static List<MasterKota> InitializeMasterKota()
        {
            List<MasterKota> listKota = new();
            int idCounter = 1;
            listKota.Add(new MasterKota
            {
                KotaId = idCounter++,
                Kota = KonstantaNamaKota.JAKARTA_PUSAT
            });
            listKota.Add(new MasterKota
            {
                KotaId = idCounter++,
                Kota = KonstantaNamaKota.JAKARTA_UTARA
            });
            listKota.Add(new MasterKota
            {
                KotaId = idCounter++,
                Kota = KonstantaNamaKota.JAKARTA_SELATAN
            });
            listKota.Add(new MasterKota
            {
                KotaId = idCounter++,
                Kota = KonstantaNamaKota.JAKARTA_TIMUR
            });
            listKota.Add(new MasterKota
            {
                KotaId = idCounter++,
                Kota = KonstantaNamaKota.JAKARTA_BARAT
            });
            listKota.Add(new MasterKota
            {
                KotaId = idCounter++,
                Kota = KonstantaNamaKota.SURABAYA
            });
            listKota.Add(new MasterKota
            {
                KotaId = idCounter++,
                Kota = KonstantaNamaKota.SEMARANG
            });
            listKota.Add(new MasterKota
            {
                KotaId = idCounter++,
                Kota = KonstantaNamaKota.BANDUNG
            });
            listKota.Add(new MasterKota
            {
                KotaId = idCounter++,
                Kota = KonstantaNamaKota.YOGYAKARTA
            });
            listKota.Add(new MasterKota
            {
                KotaId = idCounter++,
                Kota = KonstantaNamaKota.BEKASI
            });
            listKota.Add(new MasterKota
            {
                KotaId = idCounter++,
                Kota = KonstantaNamaKota.KAB_BEKASI
            });
            return listKota;
        }

        private static void InitializeListMhs(List<Mahasiswa> listMhs)
        {
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Eriawan",
                NamaBelakang = "Kusuma",
                KotaId = 3,
                TglLahir = new DateTime(1975, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Budi",
                NamaBelakang = "Susilo",
                KotaId = 6,
                TglLahir = new DateTime(1975, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Ani",
                NamaBelakang = "Wijaya",
                KotaId = 7,
                TglLahir = new DateTime(1978, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Joko",
                NamaBelakang = "Kusuma",
                KotaId = 9,
                TglLahir = new DateTime(1979, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Kusno",
                NamaBelakang = "Adrianto",
                KotaId = 9,
                TglLahir = new DateTime(1978, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Yudi",
                NamaBelakang = "Kurniawan",
                KotaId = 8,
                TglLahir = new DateTime(1978, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Budi",
                NamaBelakang = "Santoso",
                KotaId = 7,
                TglLahir = new DateTime(1978, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Heru",
                NamaBelakang = "Budianto",
                KotaId = 9,
                TglLahir = new DateTime(1978, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Anita",
                NamaBelakang = "Hadi",
                KotaId = 6,
                TglLahir = new DateTime(1977, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Anita",
                NamaBelakang = "Wijayanti",
                KotaId = 7,
                TglLahir = new DateTime(1978, 1, 1)
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Christian",
                NamaBelakang = "Nugraha",
                KotaId = 10,
                TglLahir = new DateTime(1977, 1, 1)
            });
        }
    }
}
