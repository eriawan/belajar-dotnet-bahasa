using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIskusiMateriValueTypeRefType.SampleReferenceType
{
    public struct StructMahasiswa
    {
        public string NamaDepan { get; set; } = string.Empty;

        public string NamaBelakang { get; set; } = string.Empty;

        public DateTime? TglLahir { get; set; }

        public int KotaId { get; set; }

        public StructMahasiswa()
        {
            
        }

    }
}
