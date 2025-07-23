using System.ComponentModel.DataAnnotations;

namespace WebApiAkademic.Data.POCO
{
    public abstract class AbstractTableAuditTrail
    {
        [Required]
        public DateTime DateEntry { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
