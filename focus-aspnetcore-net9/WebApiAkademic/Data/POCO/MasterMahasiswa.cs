using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAkademic.Data.POCO
{
    public class MasterMahasiswa : AbstractTableAuditTrail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long MahasiswaId { get; set; }

        public string NamaDepan { get; set; } = string.Empty;
        public string? NamaBelakang { get; set; }
        public byte Gender { get; set; }

        [Required]
        public string AlamatEmail { get; set; } = string.Empty;

        public DateTime TglMendaftar { get; set; }

        public MasterJurusan Jurusan { get; set; }

    }
}
