using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApiAkademic.Data.POCO;

namespace WebApiAkademic.Data
{
    public class AcademicRegistrationDbContext : DbContext
    {
        public AcademicRegistrationDbContext()
        {
        }

        public AcademicRegistrationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<GeoIndoProvince> GeoIndoProvinces { get; set; } = default!;
        public DbSet<MasterMahasiswa> Mahasiswas { get; set; } = default!;
        public DbSet<MasterJurusan> Jurusans { get; set; } = default!;
        public DbSet<TrnJurusanMahasiswa> TrnJurusanMahasiswas { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GeoIndoProvince>().ToTable("GeoIndoProvince");
            modelBuilder.Entity<MasterMahasiswa>().ToTable("MasterMahasiswa");
            modelBuilder.Entity<MasterJurusan>().ToTable("MasterJurusan");
            modelBuilder.Entity<TrnJurusanMahasiswa>().ToTable("TrnJurusanMahasiswa");
        }
    }
}
