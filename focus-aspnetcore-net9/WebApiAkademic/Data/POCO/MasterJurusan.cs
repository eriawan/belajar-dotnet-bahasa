using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.Design.Serialization;

namespace WebApiAkademic.Data.POCO
{
    public class MasterJurusan : AbstractTableAuditTrail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int JurusanId { get; set; }

        public string NamaJurusan { get; set; } = string.Empty;
        public string JenjangStudi { get; set; } = string.Empty;

        //public List<TrnJurusanMahasiswa> TrnJurusanMahasiswas { get; set; } = new();

    }
}
