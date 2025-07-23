using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApiAkademic.Data.POCO;

namespace WebApiAkademic.Data
{
    public static class AcademicRegistrationDbUtils
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            using var scope = host.Services.CreateScope();

            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<AcademicRegistrationDbContext>();
            bool DbCreated = context.Database.EnsureCreated();
            InitializeData(context);
        }

        private static void InitializeData(AcademicRegistrationDbContext context)
        {
            DateTime date20250101 = new DateTime(2025, 1, 1);
            List<GeoIndoProvince> provinces;
            if (!context.GeoIndoProvinces.Any())
            {
                provinces = new List<GeoIndoProvince>
                {
                    new() { ProvinceId = 1, ProvinceName = "Aceh", DateEntry = date20250101, Remarks = "", DateModified = null },
                    new() { ProvinceId = 2, ProvinceName = "Sumatera Utara", DateEntry = date20250101, Remarks = "", DateModified = null },
                    new() { ProvinceId = 3, ProvinceName = "Sumatera Barat", DateEntry = date20250101, Remarks = "", DateModified = null },
                    new() { ProvinceId = 4, ProvinceName = "Riau", DateEntry = date20250101, Remarks = "", DateModified = null },
                    new() { ProvinceId = 5, ProvinceName = "Kepulauan Riau", DateEntry = date20250101, Remarks = "", DateModified = null },
                    new() { ProvinceId = 6, ProvinceName = "Jambi", DateEntry = date20250101, Remarks = "", DateModified = null },
                    new() { ProvinceId = 7, ProvinceName = "Bangka Belitung", DateEntry = date20250101, Remarks = "", DateModified = null },
                    new() { ProvinceId = 8, ProvinceName = "Bengkulu", DateEntry = date20250101, Remarks = "", DateModified = null },
                    new() { ProvinceId = 9, ProvinceName = "Lampung", DateEntry = date20250101, Remarks = "", DateModified = null },
                    new() { ProvinceId = 10, ProvinceName = "DKI Jakarta", DateEntry = date20250101,
                        Remarks = "Nama provinsi akan berubah menjadi Daerah Istimewa Jakarta setelah pembangunan IKN selesai.", DateModified = null },
                };
                context.AddRange(provinces);
                context.SaveChanges();
            }
            else
            {
                provinces = context.GeoIndoProvinces.ToList();
            }

            List<MasterJurusan> jurusans = new();
            if (!context.Jurusans.Any())
            {
                jurusans = new List<MasterJurusan>
                {
                    new() { JurusanId = 101, JenjangStudi = "S1", NamaJurusan= "Manajemen Informatika", DateEntry=date20250101, DateModified = null },
                    new() { JurusanId = 201, JenjangStudi = "S2", NamaJurusan= "Manajemen Informatika dalam Rekayasa Perangkat Lunak", DateEntry=date20250101, DateModified = null },
                    new() { JurusanId = 102, JenjangStudi = "S1", NamaJurusan= "Ilmu Komputer", DateEntry = date20250101, DateModified = null }
                };
                context.AddRange(jurusans);
                context.SaveChanges();
            }
            var jurusan_S1Informatika = jurusans[0];
            var jurusan_S1IlmuKomputer = jurusans[2];

            List<MasterMahasiswa> mahasiswas;
            if (!context.Mahasiswas.Any())
            {
                mahasiswas = new List<MasterMahasiswa>
                {
                    new() { MahasiswaId = 2501, NamaDepan="Budi", NamaBelakang ="Suyono", Gender = 1,
                        AlamatEmail ="email@email.com", TglMendaftar = date20250101, DateEntry=date20250101,
                        DateModified = null, Jurusan = jurusan_S1IlmuKomputer },
                    new() { MahasiswaId = 2502, NamaDepan="Muhammad", NamaBelakang ="Karsono", Gender = 1,
                        AlamatEmail ="email@email.com", TglMendaftar = date20250101, DateEntry = date20250101,
                        DateModified = null, Jurusan = jurusan_S1Informatika },
                    new() { MahasiswaId = 2503, NamaDepan="Dian", NamaBelakang ="Yuliani", Gender = 2,
                        AlamatEmail ="email@email.com", TglMendaftar = date20250101, DateEntry = date20250101,
                        DateModified = null, Jurusan = jurusan_S1Informatika }
                };
                context.AddRange(mahasiswas);
                context.SaveChanges();
            }
        }
    }
}
