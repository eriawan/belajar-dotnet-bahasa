using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiAkademic.Data.POCO
{
    public class GeoIndoProvince
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProvinceId { get; set; }

        public string ProvinceName { get; set; } = "";

        public string? Remarks { get; set; }

        public DateTime DateEntry { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
