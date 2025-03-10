using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BahasLinqJoinGroupJoinSelectMany.DataClass
{
    class SimpleJoinMhsMstKota
    {
        public string NamaDepan { get; set; } = string.Empty;
        public string NamaBelakang { get; set; } = string.Empty;
        public int KotaId { get; set; }
        public string Kota { get; set; } = string.Empty;
    }
}
