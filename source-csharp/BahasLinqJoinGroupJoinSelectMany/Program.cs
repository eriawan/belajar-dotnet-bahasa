using BahasLinqJoinGroupJoinSelectMany.DataClass;
using System.Reflection.Metadata;

namespace BahasLinqJoinGroupJoinSelectMany
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, LINQ!");
            // Fokus bahas LINQ Join dan method di LINQ yang berhubungan dengan LINQ Join.
            // Termasuk default Join yang inner join, dan hutang dari video sebelumnya: 
            // GroupJoin, dan GroupJoin yang memanggil SelectMany.
            // Sample data akan memakai sample data dari project KumpulanFiturGagasanDibalikLinq (Mahasiswa dan MstKota) 
            // dan diupdate lebih lanjut, sesuai kebutuhan bahasan GroupJoin.

            // Pertama-tama, sample data yang ada harus kita siapkan dahulu.
            List<MasterKota> listMasterKota = InitializeListMasterKota();
            List<Mahasiswa> listMhs = InitializeListMahasiswa();

            // Dengan melihat kondisi data yang ada, data kota terdapat pada data mahasiswa. 
            // Dalam data mahasiswa, bisa satu atau lebih mahasiswa yang menempati kota yang sama.

            // Tambahan sejak Episode 12:
            // Ada data master mata kuliah di listMataKuliah.
            // Dalam data mahasiswa, mahasiswa dapat mengambil lebih dari 1 mata kuliah.
            // Oleh karena itu mahasiswa merupakan child table (atau child collection) dari matakuliah.
            List<MataKuliah> listMataKuliah = InitializeListMataKuliah();

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
            DisplaySimpleJoin(listDataJoinMhsDenganMstKota);
            var dataJoinMhsDenganMstKotaVerbose = Enumerable.Join(listMasterKota, listMhs,
                (mstKota) => mstKota.KotaId,
                (mhs) => mhs.KotaId,
                (mstKota, mhs) => new SimpleJoinMhsMstKota
                {
                    NamaDepan = mhs.NamaDepan,
                    NamaBelakang = mhs.NamaBelakang,
                    KotaId = mhs.KotaId,
                    Kota = mstKota.Kota
                });
            DisplaySimpleJoin(listDataJoinMhsDenganMstKota);
            Console.WriteLine("Contoh implementasi Distinct Kota di kumpulan mahasiswa yang dijoin");
            var dataJoinMhsDenganMstKotaVerboseDistinct = 
                dataJoinMhsDenganMstKotaVerbose.Distinct(new EqualityComparerKotaInSimpleJoinMhsMstKota());
            foreach (var item in dataJoinMhsDenganMstKotaVerboseDistinct)
            {
                Console.WriteLine($"{item.NamaDepan} {item.NamaBelakang}, Kota = {item.Kota}");
            }
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

            // Untuk Join yang ada into dan "from" ada lebih dari satu, maka ditransform menjadi GroupJoin dan SelectMany.
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
            //foreach (var dataGroupJoinSelectMany in dataGroupJoinMhsDenganMstKotaSelectMany)
            //{
            //    Console.Write($"Nama = \"{dataGroupJoinSelectMany.ChildMhs.NamaDepan} {dataGroupJoinSelectMany.ChildMhs.NamaBelakang}\", ");
            //    Console.WriteLine($"kota = {dataGroupJoinSelectMany.Kota}");
            //}

            Console.WriteLine("\r\nTampilan GroupJoin + SelectMany memakai extension method");
            var dataGroupJoinMhsDenganMstKotaSelectManyExplained =
                listMasterKota.GroupJoin(listMhs,
                (mstKota) => mstKota.KotaId, (mhs) => mhs.KotaId,
                (mstKota, groupMhsKota) => new { mstKota, groupMhsKota })
                .SelectMany((groupedMhsAndMstKota) => groupedMhsAndMstKota.groupMhsKota,
                (groupedMhsAndMstKota, childMhsUnderKota) => new { ChildMhs = childMhsUnderKota, Kota = groupedMhsAndMstKota.mstKota.Kota });
            //foreach (var dataGroupJoinSelectMany in dataGroupJoinMhsDenganMstKotaSelectManyExplained)
            //{
            //    Console.Write($"Nama = \"{dataGroupJoinSelectMany.ChildMhs.NamaDepan} {dataGroupJoinSelectMany.ChildMhs.NamaBelakang}\", ");
            //    Console.WriteLine($"kota = {dataGroupJoinSelectMany.Kota}");
            //}

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
            //foreach (var dataGroupJoinSelectMany in listDataLeftOuterJoinMhsDenganMstKota)
            //{
            //    Console.Write($"Nama = \"{dataGroupJoinSelectMany.ChildMhs.NamaDepan} {dataGroupJoinSelectMany.ChildMhs.NamaBelakang}\", ");
            //    Console.WriteLine($"kota = {dataGroupJoinSelectMany.Kota}");
            //}

            // Episode 12: Lebih detail dengan implementasi LINQ SelectMany selain memakai GroupJoin
            // Sesuai dengan materi video tentang GroupJoin sebelumnya, SelectMany menghasilkan
            // mapping/projection collection source dan collection lain yang hasil projectionnya sifatnya flat,
            // yaitu tidak ada hirarki data. 
            // Di dalam konsep database ini secara konsep sama dengan data yang tidak di normalisasi.
            // SelectMany di .NET 9.0 mempunyai 4 overload:
            // 1. SelectMany<TSource,TCollection,TResult>(this IEnumerable<TSource> source,
            // Func<TSource,IEnumerable<TCollection>> collectionSelector,
            // Func<TSource,TCollection,TResult> resultSelector)
            // 2. SelectMany<TSource,TCollection,TResult>(this IEnumerable<TSource> source,
            // Func<TSource,Int32,IEnumerable<TCollection>> collectionSelector,
            // Func<TSource,TCollection,TResult> resultSelector)
            // 3. SelectMany<TSource,TResult>(this IEnumerable<TSource> source,
            // Func<TSource,IEnumerable<TResult>> selector)
            // 4. SelectMany<TSource,TResult>(this IEnumerable<TSource> source,
            // Func<TSource,Int32,IEnumerable<TResult>> selector)
            // 
            // Overload bentuk ke 1 adalah method overload yang dipakai di GroupJoin yang pseudo syntaxnya memakai from lebih dari 1 
            // seperti yang sudah dibahas di Episode 11.

            // Contoh SelectMany pertama adalah SelectMany yang selain source juga selector,
            // di mana kita bisa "cross join" dua collection yang berbeda atau tidak berhubungan, 
            // dan yang sama jumlah elemennnya.
            // Berikut ini kita akan SelectMany dari mahasiswa yang mengambil mata kuliah lebih dari satu.
            // Secara semantic, SelectMany akan membuat flat dua collection ini.
            // Karena matakuliah yang diambil ada pada mahasiswa, kita akan ambil koleksi mata kuliah yang diambil
            // dari property MataKuliahYangDiambil di class Mahasiswa.
            // Overload yang kita pakai adalah bentuk ke 3 SelectMany.
            var dataMataKuliahYangDiambil = 
                listMhs.SelectMany((mhs) => mhs.MataKuliahYangDiambil);
            Console.WriteLine("Id mata kuliah yang diambil");
            foreach (var IdMataKuliahYangDiambil in dataMataKuliahYangDiambil)
            {
                Console.WriteLine(IdMataKuliahYangDiambil);
            }
            //var maxKodeMataKuliah = dataMataKuliahYangDiambil.Max();
            //var minKodeMataKuliah = dataMataKuliahYangDiambil.Min();
            //var averageKodeMataKuliah = dataMataKuliahYangDiambil.Average();

            // Contoh SelectMany kedua kita kembangkan dari sebelumnya, kita tampilkan imformasi dari mhs dan matakuliahnya
            // Kita mengambil informasi nama mahasiswa dan mata kuliah yang diambil
            var dataMataKuliahYangDiambilVerbose =
                listMhs.SelectMany(mhs => mhs.MataKuliahYangDiambil,
                (mhs, matkul) => new { mhs.NamaDepan, mhs.NamaBelakang, IdMataKuliah = matkul });
            foreach (var mhsDanMatakuliah in dataMataKuliahYangDiambilVerbose)
            {
                Console.Write($"Nama mahasiswa = {mhsDanMatakuliah.NamaDepan} {mhsDanMatakuliah.NamaBelakang}, "); 
                Console.WriteLine($"Id Matakuliah = {mhsDanMatakuliah.IdMataKuliah}");
            }
            // Kita kembangkan lagi pemakaian SelectMany ini dengan join, dan kita memakai bantuan Join secara langsung.
            // Data yang kita joinkan dijoin dengan property MataKuliahYangDiambil dengan list MataKuliah,
            // dan join ini diimplementasikan langsung pada saat pembentukan anonymous class.
            var dataMhsDanMataKuliahYangDiambil =
                listMhs.Select((mhs) =>
                    new
                    {
                        mhs,
                        DataMataKuliahYangDiambil =
                            listMataKuliah.Join(mhs.MataKuliahYangDiambil,
                                (mstMatkul) => mstMatkul.KuliahId,
                                (mhsMatkulId) => mhsMatkulId,
                                (mstMatKul, joinedMatkul) =>
                                    new { mstMatKul.NamaMataKuliah, KuliahIdJoined = joinedMatkul }).ToList()
                    });
            foreach (var dataMatkulDanMhs in dataMhsDanMataKuliahYangDiambil)
            {
                Console.Write($"Nama = {dataMatkulDanMhs.mhs.NamaDepan} {dataMatkulDanMhs.mhs.NamaBelakang}, ");
                Console.WriteLine($"Mata kuliah = {dataMatkulDanMhs.DataMataKuliahYangDiambil}");
            }
            Console.WriteLine("Join mhs dan matakuliah flattened:");
            var dataMhsDanMataKuliahYangDiambilFlat =
                dataMhsDanMataKuliahYangDiambil.SelectMany((mhsMatkulJoined) => mhsMatkulJoined.DataMataKuliahYangDiambil,
                    (mhsJoined, mhsMatkulFlatten) => new { Nama = $"{mhsJoined.mhs.NamaDepan} {mhsJoined.mhs.NamaBelakang}", 
                        mhsMatkulFlatten.NamaMataKuliah, mhsMatkulFlatten.KuliahIdJoined });

            //foreach (var dataMhsMatkulFlat in dataMhsDanMataKuliahYangDiambilFlat)
            //{
            //    Console.Write($"Nama = {dataMhsMatkulFlat.Nama}, "); 
            //    Console.WriteLine($"Nama mata kuliah = {dataMhsMatkulFlat.NamaMataKuliah}");
            //}

            var dataMhsDanMataKuliahYangDiambilFlatVerbose =
                listMhs.Select((mhs) =>
                    new
                    {
                        mhs,
                        DataMataKuliahYangDiambil =
                            listMataKuliah.Join(mhs.MataKuliahYangDiambil,
                                (mstMatkul) => mstMatkul.KuliahId,
                                (mhsMatkulId) => mhsMatkulId,
                                (mstMatKul, joinedMatkul) =>
                                    new { mstMatKul.NamaMataKuliah, KuliahIdJoined = joinedMatkul }).ToList()
                    })
                    .SelectMany((mhsMatkulJoined) => mhsMatkulJoined.DataMataKuliahYangDiambil,
                    (mhsJoined, mhsMatkulFlatten) => new
                    {
                        Nama = $"{mhsJoined.mhs.NamaDepan} {mhsJoined.mhs.NamaBelakang}",
                        mhsMatkulFlatten.NamaMataKuliah,
                        mhsMatkulFlatten.KuliahIdJoined
                    });
            Console.WriteLine("Select + Join + SelectMany digabung");
            //foreach (var dataMhsMatkulFlat in dataMhsDanMataKuliahYangDiambilFlatVerbose)
            //{
            //    Console.Write($"Nama = {dataMhsMatkulFlat.Nama}, ");
            //    Console.WriteLine($"Nama mata kuliah = {dataMhsMatkulFlat.NamaMataKuliah}");
            //}

            // contoh implementasi IComparer<T> yang dipakai di OrderBy
            Console.WriteLine("Contoh pemakaian comparer dengan class Mahasiswa");
            var orderedMahasiswa = listMhs.OrderByDescending((mhs) => mhs, new ComparerMahasiswa());
            foreach (var mhs in orderedMahasiswa)
            {
                string strTglLahir = mhs.TglLahir.HasValue ? mhs.TglLahir.Value.ToString() : "tgllahir = null";
                Console.WriteLine($"Nama = {mhs.NamaDepan} {mhs.NamaBelakang}, Kotaid = {mhs.KotaId}, Tanggal lahir = {strTglLahir}");
            }
        }

        private static void DisplaySimpleJoin(List<SimpleJoinMhsMstKota> listDataJoinMhsDenganMstKota)
        {
            listDataJoinMhsDenganMstKota.ForEach((mhsJoinKota) =>
            {
                Console.WriteLine($"Nama = \"{mhsJoinKota.NamaDepan + " " + mhsJoinKota.NamaBelakang}, kota = {mhsJoinKota.Kota}");
            });
        }

        private static List<MasterKota> InitializeListMasterKota()
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

        private static List<Mahasiswa> InitializeListMahasiswa()
        {
            List<Mahasiswa> listMhs = new();
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Eriawan",
                NamaBelakang = "Kusuma",
                KotaId = 3,
                TglLahir = new DateTime(1975, 1, 1),
                MataKuliahYangDiambil = { 1, 2, 4, 5 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Budi",
                NamaBelakang = "Susilo",
                KotaId = 6,
                TglLahir = new DateTime(1975, 1, 1),
                MataKuliahYangDiambil = { 1, 2, 3, 4, 5, 6 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Ani",
                NamaBelakang = "Wijaya",
                KotaId = 7,
                TglLahir = new DateTime(1978, 1, 1),
                MataKuliahYangDiambil = { 1, 2, 4, 7 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Joko",
                NamaBelakang = "Kusuma",
                KotaId = 9,
                TglLahir = new DateTime(1979, 1, 1),
                MataKuliahYangDiambil = { 2, 4, 5 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Kusno",
                NamaBelakang = "Adrianto",
                KotaId = 9,
                TglLahir = new DateTime(1978, 1, 1),
                MataKuliahYangDiambil = { 2, 3, 4, 5 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Yudi",
                NamaBelakang = "Kurniawan",
                KotaId = 8,
                TglLahir = new DateTime(1978, 1, 1),
                MataKuliahYangDiambil = { 3, 4, 5, 6 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Budi",
                NamaBelakang = "Santoso",
                KotaId = 7,
                TglLahir = new DateTime(1978, 1, 1),
                MataKuliahYangDiambil = { 1, 2, 4, 6 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Heru",
                NamaBelakang = "Budianto",
                KotaId = 9,
                TglLahir = new DateTime(1978, 1, 1),
                MataKuliahYangDiambil = { 2, 5, 6 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Anita",
                NamaBelakang = "Hadi",
                KotaId = 6,
                TglLahir = new DateTime(1977, 1, 1),
                MataKuliahYangDiambil = { 2, 3, 4, 5, 6, 7 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Anita",
                NamaBelakang = "Wijayanti",
                KotaId = 7,
                TglLahir = new DateTime(1978, 1, 1),
                MataKuliahYangDiambil = { 1, 2, 4, 5, 6, 7 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Christian",
                NamaBelakang = "Nugraha",
                KotaId = 10,
                TglLahir = new DateTime(1977, 1, 1),
                MataKuliahYangDiambil = { 1, 2, 3, 4, 5, 6, 7 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Christian",
                NamaBelakang = "Nugraha",
                KotaId = 10,
                TglLahir = new DateTime(1977, 1, 1),
                MataKuliahYangDiambil = { 1, 2, 3, 4, 5 }
            });
            listMhs.Add(new Mahasiswa
            {
                NamaDepan = "Anita",
                NamaBelakang = "Hadi",
                KotaId = 5,
                TglLahir = new DateTime(1977, 1, 1),
                MataKuliahYangDiambil = { 2, 3, 4, 5, 6, 7 }
            });

            return listMhs;
        }

        private static List<MataKuliah> InitializeListMataKuliah()
        {
            List<MataKuliah> listMatKul = new();
            int idCounter = 1;
            listMatKul.Add(new MataKuliah
            {
                KuliahId = idCounter++,
                NamaMataKuliah = "Dasar Pemrograman Berbasis Objek",
                SksTiapSemester = 3
            });
            listMatKul.Add(new MataKuliah
            {
                KuliahId = idCounter++,
                NamaMataKuliah = "Struktur Data",
                SksTiapSemester = 3
            });
            listMatKul.Add(new MataKuliah
            {
                KuliahId = idCounter++,
                NamaMataKuliah = "Matematika Diskrit",
                SksTiapSemester = 2
            });
            listMatKul.Add(new MataKuliah
            {
                KuliahId = idCounter++,
                NamaMataKuliah = "Logika dan Algoritma",
                SksTiapSemester = 3
            });
            listMatKul.Add(new MataKuliah
            {
                KuliahId = idCounter++,
                NamaMataKuliah = "Pemrograman web",
                SksTiapSemester = 3
            });
            listMatKul.Add(new MataKuliah
            {
                KuliahId = idCounter++,
                NamaMataKuliah = "Manajemen Basis Data",
                SksTiapSemester = 3
            });
            listMatKul.Add(new MataKuliah
            {
                KuliahId = idCounter++,
                NamaMataKuliah = "Kalkulus I",
                SksTiapSemester = 3
            });
            listMatKul.Add(new MataKuliah
            {
                KuliahId = idCounter++,
                NamaMataKuliah = "Kalkulus II",
                SksTiapSemester = 3
            });
            listMatKul.Add(new MataKuliah
            {
                KuliahId = idCounter++,
                NamaMataKuliah = "Rekayasa Perangkat Lunak",
                SksTiapSemester = 3
            });
            listMatKul.Add(new MataKuliah
            {
                KuliahId = idCounter++,
                NamaMataKuliah = "Teori Automata dan Kompilasi",
                SksTiapSemester = 3
            });

            return listMatKul;
        }
    }
}
