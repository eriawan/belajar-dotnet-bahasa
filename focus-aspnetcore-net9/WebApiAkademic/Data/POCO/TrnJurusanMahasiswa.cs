using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAkademic.Data.POCO
{
    /// <summary>
    /// Intermediate table for many-to-many relationship between MasterJurusan and MasterMahasiswa
    /// </summary>
    public class TrnJurusanMahasiswa : AbstractTableAuditTrail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long JurusanMahasiswaId { get; set; }

        public required MasterJurusan Jurusan { get; set; }

        public required MasterMahasiswa Mahasiswa { get; set; }
    }
}
