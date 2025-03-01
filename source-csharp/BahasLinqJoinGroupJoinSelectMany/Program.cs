using BahasLinqJoinGroupJoinSelectMany.DataClass;
using System.Reflection.Metadata;

namespace BahasLinqJoinGroupJoinSelectMany
{
    internal class Program
    {
        class SimpleJoinMhsMstKota
        {
            public string NamaDepan { get; set; } = string.Empty;
            public string NamaBelakang { get; set; } = string.Empty;
            public int KotaId { get; set; }
            public string Kota { get; set; } = string.Empty;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, LINQ!");
            // Fokus bahas LINQ Join dan method di LINQ yang berhubungan dengan LINQ Join.
            // Termasuk default Join yang inner join, dan hutang dari video sebelumnya: 
            // GroupJoin, dan GroupJoin yang memanggil SelectMany.
            // Sample data akan memakai sample data dari project KumpulanFiturGagasanDibalikLinq (Mahasiswa dan MstKota) 
            // dan diupdate lebih lanjut, sesuai kebutuhan bahasan GroupJoin.

            // Pertama-tama, sample data yang ada harus kita siapkan dahulu.
            List<MasterKota> listMasterKota = InitializeMasterKota();
            List<Mahasiswa> listMhs = InitializeMahasiswa();

            // Dengan melihat kondisi data yang ada, data kota terdapat pada data mahasiswa. 
            // Dalam data mahasiswa, bisa satu atau lebih mahasiswa yang menempati kota yang sama.

            // Kita mulai dari LINQ Join yang sederhana, yang menghasilkan inner join dan 
            // yang hanya memanggil extension method Enumerable.Join().
            var dataJoinMhsDenganMstKota = from mstKota in listMasterKota
                                           join mhs in listMhs on mstKota.KotaId equals mhs.KotaId
                                           select new SimpleJoinMhsMstKota
                                           {
                                               NamaDepan = mhs.NamaDepan,
                                               NamaBelakang = mhs.NamaBelakang,
                                               KotaId = mhs.KotaId,
                                               Kota = mstKota.Kota
                                           };
            var listDataJoinMhsDenganMstKota = dataJoinMhsDenganMstKota.ToList();
            DisplaySimpleJoin(listDataJoinMhsDenganMstKota);
            // Syntax Pseudo code Join diatas ditransform oleh compiler C# menjadi seperti ini:
            var dataJoinMhsDenganMstKotaExplained = listMasterKota.Join(listMhs,
                (mstKota) => mstKota.KotaId,
                (mhs) => mhs.KotaId,
                (mstKota, mhs) => new
                {
                    NamaDepan = mhs.NamaDepan,
                    NamaBelakang = mhs.NamaBelakang,
                    KotaId = mhs.KotaId,
                    Kota = mstKota.Kota
                });
            //DisplaySimpleJoin(listDataJoinMhsDenganMstKota);
            //var dataJoinMhsDenganMstKotaVerbose = Enumerable.Join(listMasterKota, listMhs,
            //    (mstKota) => mstKota.KotaId,
            //    (mhs) => mhs.KotaId,
            //    (mstKota, mhs) => new {
            //        NamaDepan = mhs.NamaDepan,
            //        NamaBelakang = mhs.NamaBelakang,
            //        KotaId = mhs.KotaId,
            //        Kota = mstKota.Kota
            //    });
            //DisplaySimpleJoin(listDataJoinMhsDenganMstKota);
            // Perhatikan signature method Join:
            // public static IEnumerable<TResult> Join<TOuter,TInner,TKey,TResult>(this IEnumerable<TOuter> outer,
            // IEnumerable<TInner> inner, Func<TOuter,TKey> outerKeySelector, Func<TInner,TKey> innerKeySelector,
            // Func<TOuter,TInner,TResult> resultSelector)
            // Parameter resultSelector ini yang ditransform dari select <expression>. 
            // Jadi adanya "select new { mhs.NamaDepan, mhs.NamaBelakang, mhs.KotaId, mstKota.Kota }" merupakan
            // bagian dari extension method Join, bukan extension method Select.
            var listDataJoinMhsDenganMstKotaExplained = dataJoinMhsDenganMstKotaExplained.ToList();

            // LINQ Join ini jika pseudo syntaxnya join ditampung ke dalam variable dengan keyword "into", 
            // compiler mentransform menjadi GroupJoin.
            // Contoh: 
            // "join mhs in listMhs on mstKota.KotaId equals mhs.KotaId" akan menjadi Join(), sedangkan 
            // "join mhs in listMhs on mstKota.KotaId equals mhs.KotaId into groupMhsKota" akan menjadi GroupJoin().
            // Konsep GroupJoin ini tidak ada padanannya atau perbandingan langsung di SQL, dan 
            // Silakan cek referensi dokumentasinya: 
            // https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/join-operations#perform-grouped-joins
            // Perhatikan signature method GroupJoin:
            // public static IEnumerable<TResult> GroupJoin<TOuter, TInner, TKey, TResult>(this IEnumerable<TOuter> outer,
            // IEnumerable<TInner> inner, Func<TOuter, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector,
            // Func<TOuter, IEnumerable<TInner>, TResult> resultSelector)
            // Parameter resultSelector di GroupJoin adalah delegate yang parameternya TOuter dan collection IEnumerable<TInner>.
            // IEnumerable inilah yang merupakan kumpulan/collection dari TInner yang datanya sudah di-group.
            var dataGroupJoinMhsDenganMstKota = from mstKota in listMasterKota
                                                join mhs in listMhs on mstKota.KotaId equals mhs.KotaId into groupMhsKota
                                                select new { Kota = mstKota.Kota, groupMhsKota };
            var listdataGroupJoinMhsDenganMstKota = dataGroupJoinMhsDenganMstKota.ToList();
            foreach (var groupJoin in listdataGroupJoinMhsDenganMstKota)
            {
                Console.WriteLine($"Kota = {groupJoin.Kota}");
                foreach (var mhsKota in groupJoin.groupMhsKota)
                {
                    Console.WriteLine($"\tNama = {mhsKota.NamaDepan} {mhsKota.NamaBelakang}");
                }
            }
            // Untuk expression "select new { Kota = mstKota.Kota, groupMhsKota }" akan ditransform menjadi 
            // delegate Func parameter keempat dari GroupJoin, bukan method Select.
            var dataGroupJoinMhsDenganMstKotaExplained =
                listMasterKota.GroupJoin(listMhs, (mstKota) => mstKota.KotaId, (mhs) => mhs.KotaId,
                    (mstKota, groupMhsKota) => new { Kota = mstKota.Kota, groupMhsKota });
            var listDataGroupJoinMhsDenganMstKotaExplained = dataGroupJoinMhsDenganMstKotaExplained.ToList();
            Console.WriteLine("Display GroupJoin of calling extension method");
            foreach (var groupJoin in listDataGroupJoinMhsDenganMstKotaExplained)
            {
                Console.WriteLine($"Kota = {groupJoin.Kota}");
                foreach (var mhsKota in groupJoin.groupMhsKota)
                {
                    Console.WriteLine($"\tNama = {mhsKota.NamaDepan} {mhsKota.NamaBelakang}");
                }
            }

            // Untuk Join yang "from" ada lebih dari satu, maka ditransform menjadi GroupJoin dan SelectMany.
            // Contoh di dokumentasi: 
            // https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/join-operations#inner-join-by-using-grouped-join
            // Karena jika ada LINQ yang memakai pseudo syntax di mana ada from lebih dari 1x, maka sesuai 
            // dengan konvensi atau aturan compiler C#, akan ditransformasikan menjadi SelectMany.
            // Berikut contoh pseudo syntax LINQ Join yang berakibat ditransformasikan memakai GroupJoin dan SelectMany.
            // Kita pakai contoh GroupJoin sebelumnya tetapi jangan langsung diikuti oleh select new, 
            // melainkan diikuti from dari data yang diambil dari "into" sebelumnya.
            var dataGroupJoinMhsDenganMstKotaSelectMany =
                from mstKota in listMasterKota
                join mhs in listMhs on mstKota.KotaId equals mhs.KotaId into groupMhsKota
                from childMhsUnderKota in groupMhsKota
                select new
                {
                    ChildMhs = childMhsUnderKota,
                    Kota = mstKota.Kota
                };
            Console.WriteLine("\r\nTampilan GroupJoin + SelectMany");
            foreach (var dataGroupJoinSelectMany in dataGroupJoinMhsDenganMstKotaSelectMany)
            {
                Console.Write($"Nama = \"{dataGroupJoinSelectMany.ChildMhs.NamaDepan} {dataGroupJoinSelectMany.ChildMhs.NamaBelakang}\", ");
                Console.WriteLine($"kota = {dataGroupJoinSelectMany.Kota}");
            }

            Console.WriteLine("\r\nTampilan GroupJoin + SelectMany memakai extension method");
            var dataGroupJoinMhsDenganMstKotaSelectManyExplained =
                listMasterKota.GroupJoin(listMhs,
                (mstKota) => mstKota.KotaId, (mhs) => mhs.KotaId,
                (mstKota, groupMhsKota) => new { mstKota, groupMhsKota })
                .SelectMany((groupedMhsAndMstKota) => groupedMhsAndMstKota.groupMhsKota,
                (groupedMhsAndMstKota, childMhsUnderKota) => new { ChildMhs = childMhsUnderKota, Kota = groupedMhsAndMstKota.mstKota.Kota });
            foreach (var dataGroupJoinSelectMany in dataGroupJoinMhsDenganMstKotaSelectManyExplained)
            {
                Console.Write($"Nama = \"{dataGroupJoinSelectMany.ChildMhs.NamaDepan} {dataGroupJoinSelectMany.ChildMhs.NamaBelakang}\", ");
                Console.WriteLine($"kota = {dataGroupJoinSelectMany.Kota}");
            }

            // LINQ outer join (left outer join)
            Console.WriteLine($"{Environment.NewLine}Tampilan contoh outer join");
            var dataLeftOuterJoinMhsDenganMstKota = from mstKota in listMasterKota
                                           join mhs in listMhs on mstKota.KotaId equals mhs.KotaId into outerJoinKotaMhs
                                           from outerJoinKotaMhsItem in outerJoinKotaMhs.DefaultIfEmpty()
                                           select new 
                                           {
                                               ChildMhs = outerJoinKotaMhsItem ?? new Mahasiswa(),
                                               Kota = mstKota.Kota
                                           };
            var listDataLeftOuterJoinMhsDenganMstKota = dataLeftOuterJoinMhsDenganMstKota.ToList();
            foreach (var dataGroupJoinSelectMany in listDataLeftOuterJoinMhsDenganMstKota)
            {
                Console.Write($"Nama = \"{dataGroupJoinSelectMany.ChildMhs.NamaDepan} {dataGroupJoinSelectMany.ChildMhs.NamaBelakang}\", ");
                Console.WriteLine($"kota = {dataGroupJoinSelectMany.Kota}");
            }
        }

        private static void DisplaySimpleJoin(List<SimpleJoinMhsMstKota> listDataJoinMhsDenganMstKota)
        {
            listDataJoinMhsDenganMstKota.ForEach((mhsJoinKota) =>
            {
                Console.WriteLine($"Nama = \"{mhsJoinKota.NamaDepan + " " + mhsJoinKota.NamaBelakang}, kota = {mhsJoinKota.Kota}");
            });
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

        private static List<Mahasiswa> InitializeMahasiswa()
        {
            List<Mahasiswa> listMhs = new();
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

            return listMhs;
        }
    }
}
